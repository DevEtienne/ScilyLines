using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScilyLines
{
    public partial class FormConnexion : Form
    {
        const string DATABASE = "db-scilylines";
        const string PROVIDER = "localhost";
        public FormConnexion()
        {
            InitializeComponent();
        }

        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            string uid = textBoxUtilisateur.Text;
            string mdp = textBoxMotDePasse.Text;
            ConnexionSql.login(PROVIDER, DATABASE, uid, mdp);
        }
    }
}
