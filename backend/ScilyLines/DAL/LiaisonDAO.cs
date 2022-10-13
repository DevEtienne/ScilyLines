using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace ScilyLines.DAL
{
    public class LiaisonDAO
    {
        string provider;
        string database;
        string uid;
        string mdp;

        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;

        public LiaisonDAO(string provider, string database, string uid, string mdp)
        {
            this.provider = provider;
            this.database = database;
            this.uid = uid;
            this.mdp = mdp;
        }
        // Récupération d'une liste de liaison via la base de données
        public List<Liaison> getLiaisons(List<Secteur> listeSecteur, List<Port> listePort)
        {
            maConnexionSql = ConnexionSql.getInstance(provider, database, uid, mdp);
            maConnexionSql.openConnection();
            string req = "select * from liaison";
            Ocom = maConnexionSql.reqExec(req);
            MySqlDataReader reader = Ocom.ExecuteReader();
            List<Liaison> listeLiaison = new List<Liaison>();

            while (reader.Read())
            {
                //Récupération des attributs de liaison
                int idLiaison = (int)reader["id"];
                string dureeLiaison = (string)reader["duree"];
                int idPortDepart = (int)reader["portDepart"];
                int idPortArrivee = (int)reader["portArrivee"];
                int idSecteur = (int)reader["idSecteur"];
                Port portDepart = LiaisonDAO.findPortById(idPortDepart, listePort);
                Port portArrivee = LiaisonDAO.findPortById(idPortArrivee, listePort);
                Secteur secteur = LiaisonDAO.findSecteurById(idSecteur, listeSecteur);
                Liaison liaison = new Liaison(dureeLiaison, portDepart, portArrivee, secteur);
                liaison.Id = idLiaison;
                listeLiaison.Add(liaison);
            }

            reader.Close();
            maConnexionSql.closeConnection();
            return listeLiaison;
        }


        //Ajouter toutes les données du trajet dans la liaision
        public void saveLiaison(Liaison liaison)
        {
            maConnexionSql = ConnexionSql.getInstance(provider, database, uid, mdp);
            maConnexionSql.openConnection();
            string req = "insert into liaison(duree, portDepart, portArrivee, idSecteur) values (?duree, ?portDepart, ?portArrivee, ?idSecteur)";
            Ocom = maConnexionSql.reqExec(req);
            Ocom.Parameters.Add("duree", MySqlDbType.VarChar).Value = liaison.Duree;
            Ocom.Parameters.Add("portDepart", MySqlDbType.Int32).Value = liaison.PortDepart.Id;
            Ocom.Parameters.Add("portArrivee", MySqlDbType.Int32).Value = liaison.PortArrive.Id;
            Ocom.Parameters.Add("idSecteur", MySqlDbType.Int32).Value = liaison.Secteur.Id;
            Ocom.ExecuteNonQuery();
            
            req = "select id from liaison order by id desc limit 1";
            Ocom = maConnexionSql.reqExec(req);
            int idLiaison = (int)Ocom.ExecuteScalar();
            liaison.Id = idLiaison;
            maConnexionSql.closeConnection();
        }
        //Supprimer une liaison
        public void deleteLiaison(Liaison liaison)
        {
            maConnexionSql = ConnexionSql.getInstance(provider, database, uid, mdp);
            maConnexionSql.openConnection();
            string req = "delete from liaison where id=?id";
            Ocom = maConnexionSql.reqExec(req);
            Ocom.Parameters.Add("id", MySqlDbType.Int32).Value = liaison.Id;
            Ocom.ExecuteNonQuery();
            maConnexionSql.closeConnection();
        }
        // Modifier une liaison
        public void updateLiaison(Liaison liaison, string duree)
        {
            maConnexionSql.openConnection();
            string req = "update liaison set duree=?duree where id=?id";
            Ocom = maConnexionSql.reqExec(req);
            Ocom.Parameters.Add("duree", MySqlDbType.VarChar).Value = liaison.Duree;
            Ocom.Parameters.Add("id", MySqlDbType.Int32).Value = liaison.Id;
            Ocom.ExecuteNonQuery();
            maConnexionSql.closeConnection();
        }
        public static Secteur findSecteurById(int idSecteur, List<Secteur> listeSecteur)
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
        public static Port findPortById(int idPort, List<Port> listePort)
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
        public static List<Liaison> findListeLiaisonBySecteur(Secteur secteur, List<Liaison> listeLiaison)
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
    }
}



    

