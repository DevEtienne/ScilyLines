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
        private static string provider;
        private static string database;
        private static string uid;
        private static string mdp;

        private static ConnexionSql maConnexionSql = ConnexionSql.getInstance(provider, database, uid, mdp);
        private static MySqlCommand Ocom;

        public LiaisonDAO(string provider, string database, string uid, string mdp)
        {
            LiaisonDAO.provider = provider;
            LiaisonDAO.database = database;
            LiaisonDAO.uid = uid;
            LiaisonDAO.mdp = mdp;
        }
        // Récupération d'une liste de liaison via la base de données
        public List<Liaison> getLiaisons(List<Secteur> listeSecteur, List<Port> listePort)
        {
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
                Port portDepart = this.findPortById(idPortDepart, listePort);
                Port portArrivee = this.findPortById(idPortArrivee, listePort);
                Secteur secteur = this.findSecteurById(idSecteur, listeSecteur);
                Liaison liaison = new Liaison(dureeLiaison, portDepart, portArrivee, secteur);
                liaison.Id = idLiaison;
                listeLiaison.Add(liaison);
            }

            reader.Close();
            maConnexionSql.closeConnection();
            return listeLiaison;
        }


        //Ajouter toutes les données du trajet dans la liaision
        public void ajouterLiaison(Liaison liaison)
        {
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
            int idLiaison = (int) Ocom.ExecuteScalar();
            liaison.Id = idLiaison;
            maConnexionSql.closeConnection();
        }
        //Supprimer une liaison
        public void supprimerLiaison(Liaison liaison)
        {
            maConnexionSql.openConnection();
            string req = "delete from liaison where id=?id";
            Ocom = maConnexionSql.reqExec(req);
            Ocom.Parameters.Add("id", MySqlDbType.Int32).Value = liaison.Id;
            Ocom.ExecuteNonQuery();
            maConnexionSql.closeConnection();
        }
        // Modifier une liaison
        public void modifierLiaison(Liaison liaison, string duree, Port portArrivee, Port portDepart)
        {
            maConnexionSql.openConnection();
            string req = "update liaison set duree=?duree, portDepart=?portDepart, portArrivee=?portArrivee where id=?id";
            Ocom = maConnexionSql.reqExec(req);
            Ocom.Parameters.Add("duree", MySqlDbType.VarChar).Value = liaison.Duree;
            Ocom.Parameters.Add("portDepart", MySqlDbType.Int32).Value = liaison.PortDepart.Id;
            Ocom.Parameters.Add("portArrivee", MySqlDbType.Int32).Value = liaison.PortArrive.Id;
            Ocom.Parameters.Add("id", MySqlDbType.Int32).Value = liaison.Id;
            Ocom.ExecuteNonQuery();
            maConnexionSql.closeConnection();
        }
        
    }
}




    

