using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ScilyLines.Controleur;

namespace ScilyLines
{
    public partial class FormConnexion : Form
    {
        const string DATABASE = "db-scilylines";
        const string PROVIDER = "localhost";
        public FormConnexion()
        {
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(480, 280) ;
        }
        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            //Récupérer les données pour la connexion (login,MDP)
            string uid = textBoxUtilisateur.Text;
            string mdp = textBoxMotDePasse.Text;
            
            // Accès au menu si le login est validé
            if (Verification.login(PROVIDER, DATABASE, uid, mdp))
            {
                // Chiffrement du mot de passe
                string hashPassword = Verification.MD5Encryption(mdp);
                FormMenu formMenu = new FormMenu(PROVIDER, DATABASE, uid, hashPassword);
                this.Hide();
                formMenu.ShowDialog();
                this.Close();
            };
        }
    }
}
