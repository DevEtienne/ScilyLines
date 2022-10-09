using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Data;

namespace ScilyLines
{
    public class ConnexionSql
    {
        private static ConnexionSql connexion = null;
        private static readonly object padLock = new object();
        private MySqlConnection mySqlCn;

        // Connection à la base de données
        private ConnexionSql(string unProvider, string uneDatabase, string unUid, string unMdp)
        {
            try
            {
                string connexionString = String.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};", unProvider, uneDatabase, unUid, unMdp);
                mySqlCn = new MySqlConnection(connexionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Non Connecté");
                throw (ex);
            }

        }
        public static ConnexionSql getInstance(string unProvider, string uneDatabase, string unUid, string unMdp)
        {
            lock (padLock)
            {
                try
                {
                    if (connexion == null)
                    {
                        ConnexionSql connexion = new ConnexionSql(unProvider, uneDatabase, unUid, unMdp);
                        return connexion;
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                return connexion;
            }
        }

        public void openConnection()
        {
            try
            {
                mySqlCn.Open();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void closeConnection()
        {
            mySqlCn.Close();
        }
        public List<Secteur> findSecteur()
        {
            string req = "select * from secteur";
            MySqlCommand mySqlCom = new MySqlCommand(req, mySqlCn);
            MySqlDataReader reader =  mySqlCom.ExecuteReader();
            List<Secteur> listeSecteur = new List<Secteur>();

            while (reader.Read())
            {
                int idSecteur = Convert.ToInt32(reader["id"].ToString());
                string nomSecteur = reader["nom"].ToString();
                Secteur secteur = new Secteur(idSecteur, nomSecteur);
                listeSecteur.Add(secteur);
            }
            
            reader.Close();
            return listeSecteur;
        }
    }
}
