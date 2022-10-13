using Org.BouncyCastle.Asn1.Cmp;
using ScilyLines.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScilyLines.Controleur
{
    public class Manager
    {
        SecteurDAO secteurDAO;
        PortDAO portDAO;
        LiaisonDAO liaisonDAO;

        private List<Secteur> listeSecteur;
        private List<Port> listePort;
        private List<Liaison> listeLiaison;

        public Manager(string provider, string database, string uid, string mdp)
        {
            portDAO = new PortDAO(provider, database, uid, mdp);
            secteurDAO = new SecteurDAO(provider, database, uid, mdp);
            liaisonDAO = new LiaisonDAO(provider, database, uid, mdp);

            listeSecteur = new List<Secteur>();
            listePort = new List<Port>();
            listeLiaison = new List<Liaison>();
        }

        public List<Secteur> chargementSecteur() { 
            listeSecteur = secteurDAO.getSecteurs();
            return listeSecteur;
        }

        public List<Port> chargementPort()
        {
            listePort = portDAO.getPorts();
            return listePort;
        }

        public List<Liaison> chargementLiaison(List<Secteur> listeSecteur, List<Port> listePort)
        {
            listeLiaison = liaisonDAO.getLiaisons(listeSecteur, listePort);
            return listeLiaison;
        }

        public void ajouterLiaison(Liaison liaison)
        {
            liaisonDAO.saveLiaison(liaison);
        }

        public void supprimerLiaison(Liaison liaison)
        {
            liaisonDAO.deleteLiaison(liaison);
        }

        public void modifierLiaison(Liaison liaison, string duree)
        {
            liaisonDAO.updateLiaison(liaison, duree);
        }
    }
}
