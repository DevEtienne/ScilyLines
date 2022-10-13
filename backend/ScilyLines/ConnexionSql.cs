using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ScilyLines
{
    public class ConnexionSql
    {
        private static ConnexionSql connexion = null;
        private static readonly object padLock = new object();
        private MySqlConnection mySqlCn;

        // Connexion à la base de données
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
            // Test un thread à la fois
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
        // Ouverture de la connexion
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
        // Fermeture de la connexion
        public void closeConnection()
        {
            mySqlCn.Close();
        }
        // Récupération d'une liste de secteur via la base de données
        public List<Secteur> findSecteur()
        {
            this.openConnection();
            string req = "select * from secteur";
            MySqlCommand mySqlCom = new MySqlCommand(req, mySqlCn);
            MySqlDataReader reader =  mySqlCom.ExecuteReader();
            List<Secteur> listeSecteur = new List<Secteur>();

            while (reader.Read())
            {
                int idSecteur = (int) reader["id"];
                string nomSecteur = (string) reader["nom"];
                Secteur secteur = new Secteur(idSecteur, nomSecteur);
                listeSecteur.Add(secteur);
            }
            
            reader.Close();
            this.closeConnection();
            return listeSecteur;
        }
        // Récupération d'une liste de port via la base de données
        public List<Port> findPort()
        {
            this.openConnection();
            string req = "select * from port";
            MySqlCommand mySqlCom = new MySqlCommand(req, mySqlCn);
            MySqlDataReader reader = mySqlCom.ExecuteReader();
            List<Port> listePort = new List<Port>();

            //Conversion des variables appartenant au Port, en int (ToString) pour la stoker
            while (reader.Read())
            {
                int idPort = (int) reader["id"];
                string nomPort = (string) reader["nom"];
                Port port = new Port(idPort, nomPort);
                listePort.Add(port);
            }
            
            reader.Close();
            this.closeConnection();
            return listePort;
        }
        // Récupération d'une liste de liaison via la base de données
        public List<Liaison> findLiaison(List<Secteur> listeSecteur, List<Port> listePort)
        {
            this.openConnection();
            string req = "select * from liaison";
            MySqlCommand mySqlCom = new MySqlCommand(req, mySqlCn);
            MySqlDataReader reader = mySqlCom.ExecuteReader();
            List<Liaison> listeLiaison = new List<Liaison>();

            while (reader.Read())
            {
                //Récupération des attributs de liaison
                int idLiaison = (int) reader["id"];
                string dureeLiaison = (string) reader["duree"];
                int idPortDepart = (int) reader["portDepart"];
                int idPortArrivee = (int) reader["portArrivee"];
                int idSecteur = (int) reader["idSecteur"];
                Port portDepart = this.findPortById(idPortDepart, listePort);
                Port portArrivee = this.findPortById(idPortArrivee, listePort);
                Secteur secteur = this.findSecteurById(idSecteur, listeSecteur);
                Liaison liaison = new Liaison(dureeLiaison, portDepart, portArrivee, secteur);
                liaison.Id = idLiaison;
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
        public List<Liaison> findListeLiaisonBySecteur(Secteur secteur, List<Liaison> listeLiaison)
        {
            List<Liaison> listeLiaisonBySecteurId = new List<Liaison>();

            foreach (Liaison liaison in listeLiaison)
            {
                if (liaison.Secteur == secteur)
                {
                    listeLiaisonBySecteurId.Add(liaison);
                }
            }
            return listeLiaisonBySecteurId;
        }
        //Ajouter toutes les données du trajet dans la liaision
        public void ajouterLiaison(Liaison liaison)
        {
            this.openConnection();
            string req = "insert into liaison(duree, portDepart, portArrivee, idSecteur) values (?duree, ?portDepart, ?portArrivee, ?idSecteur)";
            MySqlCommand mySqlCom = new MySqlCommand(req, mySqlCn);
            mySqlCom.Parameters.Add("duree", MySqlDbType.VarChar).Value = liaison.Duree;
            mySqlCom.Parameters.Add("portDepart", MySqlDbType.Int32).Value = liaison.PortDepart.Id;
            mySqlCom.Parameters.Add("portArrivee", MySqlDbType.Int32).Value = liaison.PortArrive.Id;
            mySqlCom.Parameters.Add("idSecteur", MySqlDbType.Int32).Value = liaison.Secteur.Id;
            mySqlCom.ExecuteNonQuery();

            req = "select id from liaison order by id desc limit 1";
            mySqlCom = new MySqlCommand(req, mySqlCn);
            int idLiaison = (int) mySqlCom.ExecuteScalar();
            liaison.Id = idLiaison;
            this.closeConnection();
        }
        //Supprimer une liaison
        public void supprimerLiaison(Liaison liaison)
        {
            this.openConnection();
            string req = "delete from liaison where id=?id";
            MySqlCommand mySqlCom = new MySqlCommand(req, mySqlCn);
            mySqlCom.Parameters.Add("id", MySqlDbType.Int32).Value = liaison.Id;
            mySqlCom.ExecuteNonQuery();
            this.closeConnection();
        }
        // Modifier une liaison
        public void modifierLiaison(Liaison liaison, string duree, Port portArrivee, Port portDepart)
        {
            this.openConnection();
            string req = "update liaison set duree=?duree, portDepart=?portDepart, portArrivee=?portArrivee where id=?id";
            MySqlCommand mySqlCom = new MySqlCommand(req, mySqlCn);

            mySqlCom.Parameters.Add("duree", MySqlDbType.VarChar).Value = liaison.Duree;
            mySqlCom.Parameters.Add("portDepart", MySqlDbType.Int32).Value = liaison.PortDepart.Id;
            mySqlCom.Parameters.Add("portArrivee", MySqlDbType.Int32).Value = liaison.PortArrive.Id;
            mySqlCom.Parameters.Add("id", MySqlDbType.Int32).Value = liaison.Id;
            mySqlCom.ExecuteNonQuery();
            this.closeConnection();
        }
    }
}
