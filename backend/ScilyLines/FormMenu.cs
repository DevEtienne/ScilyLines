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
        string provider;
        string database;
        string uid;
        string mdp;

        public FormMenu(string provider, string database, string uid, string mdp)
        {
            InitializeComponent();
            this.provider = provider;
            this.database = database;
            this.uid = uid;
            this.mdp = mdp;
        }

        private void listBoxSecteur_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            ConnexionSql connexion = ConnexionSql.getInstance(provider, database, uid, mdp);
            connexion.openConnection();
            List<Secteur> listeSecteur = connexion.findSecteur();

            foreach (Secteur secteur in listeSecteur)
            {
                listBoxSecteur.Items.Add(String.Format("{0}. {1}", secteur.Id, secteur.Nom));
            }
        }
    }
}
