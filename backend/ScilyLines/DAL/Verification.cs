using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Org.BouncyCastle.Ocsp;

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

            //Conversion des bytes en une chaîne de caractères
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
            // Connexion en tant que root pour exécuter la requête
            string connexionString = String.Format("Data Source={0};port=3306; Initial Catalog={1}; User Id=root;password=''", unProvider, uneDatabase);
            MySqlConnection mySqlCn = new MySqlConnection(connexionString);
            mySqlCn.Open();
            string req = "select * from login where username=?username and password=?password";
            MySqlCommand cmd = new MySqlCommand(req, mySqlCn);
            // Chiffrement du mot de passe
            string hashPassword = Verification.MD5Encryption(unMdp);
            cmd.Parameters.Add(new MySqlParameter("username", unUid));
            cmd.Parameters.Add(new MySqlParameter("password", hashPassword));
            MySqlDataReader dr = cmd.ExecuteReader();
            
            // Retourne true si le résultat de la requête comporte une ou plusieurs lignes
            if (dr.HasRows == true)
            {
                mySqlCn.Close();
                return true;
            }
            else
            {
                mySqlCn.Close();
                MessageBox.Show("Identifiants invalides");
                return false;
            }
        }
    }
}