using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace ScilyLines.DAL
{
    public class SecteurDAO
    {

        string provider;
        string database;
        string uid;
        string mdp;

        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;

        public SecteurDAO(string provider, string database, string uid, string mdp)
        {
            this.provider = provider;
            this.database = database;
            this.uid = uid;
            this.mdp = mdp;
        }

        // Récupération d'une liste de secteur via la base de données
        public List<Secteur> getSecteurs()
        {
            maConnexionSql = ConnexionSql.getInstance(provider, database, uid, mdp);
            maConnexionSql.openConnection();
            string req = "select * from secteur";
            Ocom = maConnexionSql.reqExec(req);
            MySqlDataReader reader = Ocom.ExecuteReader();
            List<Secteur> listeSecteur = new List<Secteur>();

            while (reader.Read())
            {
                int idSecteur = (int)reader["id"];
                string nomSecteur = (string)reader["nom"];
                Secteur secteur = new Secteur(idSecteur, nomSecteur);
                listeSecteur.Add(secteur);
            }

            reader.Close();
            maConnexionSql.closeConnection();
            return listeSecteur;
        }
    }
}
