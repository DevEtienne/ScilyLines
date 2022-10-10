using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ScilyLines
{
    public partial class FormMenu : Form
    {
        private string provider;
        private string database;
        private string uid;
        private string mdp;
        private static ConnexionSql connexion;
        List<Secteur> listeSecteur;
        List<Port> listePort;
        List<Liaison> listeLiaison;
        List<Liaison> listeLiaisonBySecteur;

        public FormMenu(string provider, string database, string uid, string mdp)
        {
            InitializeComponent();
            this.provider = provider;
            this.database = database;
            this.uid = uid;
            this.mdp = mdp;
        }

        public void refreshListboxSecteur()
        {
            listeSecteur = connexion.findSecteur();
            listePort = connexion.findPort();
            listeLiaison = connexion.findLiaison(listeSecteur, listePort);

            foreach (Secteur secteur in listeSecteur)
            {
                listBoxSecteur.Items.Add(String.Format("{0}. {1}", secteur.Id, secteur.Nom));
            }

            foreach (Port port in listePort)
            {
                comboBoxPortDepart.Items.Add(port.Nom);
                comboBoxPortArrivee.Items.Add(port.Nom);
            }
        }
        public void refreshListboxLiaison()
        {
            listBoxLiaison.Items.Clear();
            labelNoLiaison.Text = "";
            int indexSecteur = listBoxSecteur.SelectedIndex + 1;
            int id = 0;
            listeLiaisonBySecteur = connexion.findListeLiaisonBySecteurId(indexSecteur, listeLiaison);

            foreach (Liaison liaison in listeLiaisonBySecteur)
            {
                id++;
                listBoxLiaison.Items.Add(String.Format("{0}. {1} - {2} : {3}", id, liaison.PortDepart.Nom, liaison.PortArrive.Nom, liaison.Duree));
            }

            if (id == 0) labelNoLiaison.Text = "Aucune Liaison";
        }
        private void FormMenu_Load(object sender, EventArgs e)
        {
            connexion = ConnexionSql.getInstance(provider, database, uid, mdp);
            this.refreshListboxSecteur();
        }

        private void listBoxSecteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.refreshListboxLiaison();
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            int idLiaison = listeLiaison.Count() + 1;
            string duree = textBoxDuree.Text;
            int idPortDepart = comboBoxPortDepart.SelectedIndex + 1;
            int idPortArrivee = comboBoxPortArrivee.SelectedIndex + 1;
            int idSecteur = listBoxSecteur.SelectedIndex + 1;
            Port portDepart = connexion.findPortById(idPortDepart, listePort);
            Port portArrivee = connexion.findPortById(idPortArrivee, listePort);
            Secteur secteur = connexion.findSecteurById(idSecteur, listeSecteur);
            
            if (portDepart != null && portArrivee != null && secteur != null & duree != "")
            {
                Liaison liaison = new Liaison(idLiaison, duree, portDepart, portArrivee, secteur);
                listeLiaison.Add(liaison);
                connexion.ajouterLiaison(liaison);
                this.refreshListboxLiaison();
            }
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            int indexSecteur = listBoxSecteur.SelectedIndex + 1;
            //Secteur secteur = listeSecteur[indexSecteur];
            listeLiaisonBySecteur = connexion.findListeLiaisonBySecteurId(indexSecteur, listeLiaison);
            int indexLiaison = listBoxLiaison.SelectedIndex;
            if (indexLiaison >= 0)
            {
                Liaison liaison = listeLiaisonBySecteur[indexLiaison];
                listeLiaison.Remove(liaison);
                connexion.supprimerLiaison(liaison);
                this.refreshListboxLiaison();
            }
        }
    }
}