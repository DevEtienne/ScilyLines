using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ScilyLines
{
    internal class Verification
    {
        // Méthode de chiffrement du mot de passe
        public static string MD5Encryption(string encryptionText)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            // Conversion de la chaîne de caractères en tableau de byte.
            byte[] array = Encoding.UTF8.GetBytes(encryptionText);
            //Calcul du hash du tableau
            array = md5.ComputeHash(array);
            //Création d'un objet StringBuilder pour stocker le hash.
            StringBuilder sb = new StringBuilder();

            //Conversion de tout les byte en une chaîne de caractères
            foreach (byte ba in array)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //Retourne une chaîne hexadécimal.
            return sb.ToString();
        }

        // Vérification des identifiants de la base de données
        public static bool login(string unProvider, string uneDatabase, string unUid, string unMdp)
        {
            string connexionString = String.Format("Data Source={0};port=3306; Initial Catalog={1}; User Id=root;password=''", unProvider, uneDatabase);
            MySqlConnection mySqlCn = new MySqlConnection(connexionString);
            mySqlCn.Open();
            MySqlCommand cmd = mySqlCn.CreateCommand();
            string hashPassword = Verification.MD5Encryption(unMdp);
            string req = String.Format("select * from login where username='{0}' and password='{1}'", unUid, hashPassword);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = req;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            mySqlCn.Close();
            int nbLignes = dt.Rows.Count;

            if (nbLignes == 1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Identifiants invalides");
                return false;
            }
        }
    }
}
