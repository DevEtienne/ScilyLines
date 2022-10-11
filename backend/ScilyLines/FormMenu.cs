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
        // Actualise listBoxSecteur
        public void refreshListBoxSecteur()
        {
            // Génération des listes
            listeSecteur = connexion.findSecteur();
            listePort = connexion.findPort();
            listeLiaison = connexion.findLiaison(listeSecteur, listePort);
            // Liaison de listBoxSecteur à listeSecteur
            listBoxSecteur.DataSource = listeSecteur;
        }
        // Format de l'affichage de listBoxSecteur
        private void listBoxSecteur_Format(object sender, ListControlConvertEventArgs e)
        {
            int idSecteur = ((Secteur)e.ListItem).Id;
            string nomSecteur = ((Secteur)e.ListItem).Nom;
            e.Value = String.Format("{0}. {1}", idSecteur, nomSecteur);
        }
        // Actualise listBoxLiaiosn
        public void refreshListBoxLiaison()
        {
            labelNoLiaison.Text = "";
            Secteur secteur = listBoxSecteur.SelectedItem as Secteur;
            listeLiaisonBySecteur = connexion.findListeLiaisonBySecteur(secteur, listeLiaison);
            // Liaison de listBoxLiaison à listeLiaisonBySecteur
            listBoxLiaison.DataSource = listeLiaisonBySecteur;
            // Affichage du texte lorsque listeLiaisonBySecteur est vide
            bool isEmpty = !listeLiaisonBySecteur.Any();
            if (isEmpty) labelNoLiaison.Text = "Aucune Liaison";
        }
        // Format de l'affichage de listBoxSecteur
        private void listBoxLiaison_Format(object sender, ListControlConvertEventArgs e)
        {
            int index = listeLiaisonBySecteur.IndexOf((Liaison)e.ListItem) + 1;
            string nomPortDepart = ((Liaison)e.ListItem).PortDepart.Nom;
            string nomportArrivee = ((Liaison)e.ListItem).PortArrive.Nom;
            string dureeLiaison = ((Liaison)e.ListItem).Duree;
            e.Value = String.Format("{0}. {1} - {2} : {3}", index, nomPortDepart, nomportArrivee, dureeLiaison);
        }
        // Actualise les comboBoxPort
        public void refreshComboBoxPort()
        {
            // Ajout des ports dans les comboBox
            foreach (Port port in listePort)
            {
                comboBoxPortDepart.Items.Add(port);
                comboBoxPortArrivee.Items.Add(port);
            }
            // Affichage du nom de chaque port
            comboBoxPortDepart.DisplayMember = "nom";
            comboBoxPortArrivee.DisplayMember = "nom";
        }
        private void FormMenu_Load(object sender, EventArgs e)
        {
            connexion = ConnexionSql.getInstance(provider, database, uid, mdp);
            this.refreshListBoxSecteur();
            this.refreshComboBoxPort();
        }

        private void listBoxSecteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.refreshListBoxLiaison();
        }
        //Ajouter un nouveau trajet dans la liaison en appuyant sur le bouton Ajouter
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            //int idLiaison = listeLiaison.Count() + 1;
            string duree = textBoxDuree.Text;
            Port portDepart = comboBoxPortDepart.SelectedItem as Port;
            Port portArrivee = comboBoxPortArrivee.SelectedItem as Port;
            Secteur secteur = listBoxSecteur.SelectedItem as Secteur;

         //Lorsque les données ne sont pas remplies le bouton Ajouter ne marchera pas 
            if (portDepart != null && portArrivee != null && secteur != null & duree != "")
            {
                Liaison liaison = new Liaison(duree, portDepart, portArrivee, secteur);
                listeLiaison.Add(liaison);
                connexion.ajouterLiaison(liaison);
                this.refreshListBoxLiaison();
            }
        }
        //Supprimer la liaison en appuyant sur le bouton Supprimer
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            int indexLiaison = listBoxLiaison.SelectedIndex;
            if (indexLiaison >= 0)
            {
                Liaison liaison = listBoxLiaison.SelectedItem as Liaison;
                listeLiaison.Remove(liaison);
                connexion.supprimerLiaison(liaison);
                this.refreshListBoxLiaison();
            }
        }
    }
}