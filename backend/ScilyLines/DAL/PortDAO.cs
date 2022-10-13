using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace ScilyLines.DAL
{
    public class PortDAO
    {
        string provider;
        string database;
        string uid;
        string mdp;

        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;

        public PortDAO(string provider, string database, string uid, string mdp)
        {
            this.provider = provider;
            this.database = database;
            this.uid = uid;
            this.mdp = mdp;
        }

        // Récupération d'une liste de port via la base de données
        public List<Port> getPorts()
        {
            maConnexionSql = ConnexionSql.getInstance(provider, database, uid, mdp);
            maConnexionSql.openConnection();
            string req = "select * from port";
            Ocom = maConnexionSql.reqExec(req);
            MySqlDataReader reader = Ocom.ExecuteReader();
            List<Port> listePort = new List<Port>();

            //Conversion des variables appartenant au Port, en int (ToString) pour la stoker
            while (reader.Read())
            {
                int idPort = (int)reader["id"];
                string nomPort = (string)reader["nom"];
                Port port = new Port(idPort, nomPort);
                listePort.Add(port);
            }
            reader.Close();
            maConnexionSql.closeConnection();
            return listePort;
        }
    }
}
