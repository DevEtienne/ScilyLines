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

        public FormMenu(string provider, string database, string uid, string mdp)
        {
            InitializeComponent();
            this.provider = provider;
            this.database = database;
            this.uid = uid;
            this.mdp = mdp;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            connexion = ConnexionSql.getInstance(provider, database, uid, mdp);
            listeSecteur = connexion.findSecteur();
            listePort = connexion.findPort();
            listeLiaison = connexion.findLiaison(listeSecteur, listePort);

            foreach (Secteur secteur in listeSecteur)
            {
                listBoxSecteur.Items.Add(String.Format("{0}. {1}", secteur.Id, secteur.Nom));
            }
        }

        private void listBoxSecteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxLiaison.Items.Clear();
            labelNoLiaison.Text = "";
            int indexSecteur = listBoxSecteur.SelectedIndex;
            int id = 0;

            foreach (Liaison liaison in listeLiaison)
            {
                if (liaison.Secteur.Id == indexSecteur)
                {
                    id++;
                    listBoxLiaison.Items.Add(String.Format("{0}. {1} - {2} : {3}", id, liaison.PortDepart.Nom, liaison.PortArrive.Nom, liaison.Duree));
                }
            }
            
            if (id == 0) labelNoLiaison.Text = "Aucune Liaison";
        }
    }
}