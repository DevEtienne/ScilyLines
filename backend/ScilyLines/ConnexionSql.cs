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
        private static MySqlCommand mySqlCn;

        // Connection à la base de données
        private ConnexionSql(MySqlConnection mySqlCn)
        {
            try
            {
                mySqlCn.Open();
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
                        string connexionString = String.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};", unProvider, uneDatabase, unUid, unMdp);
                        MySqlConnection mySqlCn = new MySqlConnection(connexionString);
                        ConnexionSql connexion = new ConnexionSql(mySqlCn);

                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                return connexion;
            }
        }

        public static List<string> findSecteur(string req, MySqlConnection connexion)
        {
            MySqlCommand cmd = connexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = req;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            int count = dt.Rows.Count;
            List<string> listSecteur = new List<string>();
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    listSecteur.Add(dt.Rows[i].ToString());
                }
                return listSecteur;
            }
            return null;
        }


    }
}
