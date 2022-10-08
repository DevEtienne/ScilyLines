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
        public FormMenu()
        {
            InitializeComponent();
        }

        private void listBoxSecteur_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            string req = "select * from secteur";
            List<string> listeSecteur = ConnexionSql.findSecteur(req, ConnexionSql.connexion) ;

            foreach (string secteur in listeSecteur)
            {
                listBoxSecteur.Items.Add(secteur);
            }
        }
    }
}
