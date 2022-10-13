using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ScilyLines.DAL
{
    public class SecteurDAO
    {
        private static string provider ;
        private static string datebase;
        private static string uid;
        private static string mdp;

        private static ConnexionSql maConnexioSql;
        private static MySqlCommand Ocom;

        public SecteurDAO(string provider, string datebase, string uid, string mdp)
        {
            SecteurDAO.provider = provider;
            SecteurDAO.datebase = datebase;
            SecteurDAO.uid = uid;
            SecteurDAO.mdp = mdp;
        }

        public static void updateSecteur (Secteur )







    }
}
