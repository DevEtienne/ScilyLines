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
            this.openConnection();
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
            this.closeConnection();
            return listeSecteur;
        }
        
        public List<Port> findPort()
        {
            this.openConnection();
            string req = "select * from port";
            MySqlCommand mySqlCom = new MySqlCommand(req, mySqlCn);
            MySqlDataReader reader = mySqlCom.ExecuteReader();
            List<Port> listePort = new List<Port>();

            while (reader.Read())
            {
                int idPort = Convert.ToInt32(reader["id"].ToString());
                string nomPort = reader["nom"].ToString();
                Port port = new Port(idPort, nomPort);
                listePort.Add(port);
            }
            
            reader.Close();
            this.closeConnection();
            return listePort;
        }

        public List<Liaison> findLiaison(List<Secteur> listeSecteur, List<Port> listePort)
        {
            this.openConnection();
            string req = "select * from liaison";
            MySqlCommand mySqlCom = new MySqlCommand(req, mySqlCn);
            MySqlDataReader reader = mySqlCom.ExecuteReader();
            List<Liaison> listeLiaison = new List<Liaison>();

            while (reader.Read())
            {
                int idLiaison = Convert.ToInt32(reader["id"].ToString());
                string dureeLiaison = reader["duree"].ToString();
                int idPortDepart = Convert.ToInt32(reader["port-depart"].ToString());
                int idPortArrivee = Convert.ToInt32(reader["port-arrivee"].ToString());
                int idSecteur = Convert.ToInt32(reader["idSecteur"].ToString());
                Port portDepart = this.findPortById(idPortDepart, listePort);
                Port portArrivee = this.findPortById(idPortArrivee, listePort);
                Secteur secteur = this.findSecteurById(idSecteur, listeSecteur);
                Liaison liaison = new Liaison(idLiaison, dureeLiaison, portDepart, portArrivee, secteur);
                listeLiaison.Add(liaison);
            }

            reader.Close();
            this.closeConnection();
            return listeLiaison;
        }

        public Secteur findSecteurById(int idSecteur, List<Secteur> listeSecteur)
        {
            foreach (Secteur secteur in listeSecteur)
            {
                if (secteur.Id == idSecteur)
                {
                    return secteur;
                }
            }
            return null;
        }
        public Port findPortById(int idPort, List<Port> listePort)
        {
            foreach (Port port in listePort)
            {
                if (port.Id == idPort)
                {
                    return port;
                }
            }
            return null;
        }
    }
}
