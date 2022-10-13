using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ScilyLines.Controleur;
using ScilyLines.DAL;

namespace ScilyLines
{
    public partial class FormMenu : Form
    {
        private string provider;
        private string database;
        private string uid;
        private string mdp;
        Manager manager;
        private static ConnexionSql connexion;
        List<Secteur> listeSecteur;
        List<Port> listePort;
        List<Liaison> listeLiaison;
        List<Liaison> listeLiaisonBySecteur;

        public FormMenu(string provider, string database, string uid, string mdp)
        {
            InitializeComponent();
            this.provider = provider;
            this.database = database;
            this.uid = uid;
            this.mdp = mdp;
            manager = new Manager(provider, database, uid, mdp);
            this.MaximumSize = new System.Drawing.Size(560, 350);
        }
        // Actualise listBoxSecteur
        public void refreshListBoxSecteur()
        {
            // Génération des listes
            listeSecteur = manager.chargementSecteur();
            listePort = manager.chargementPort();
            listeLiaison = manager.chargementLiaison(listeSecteur, listePort);
            // Liaison de listBoxSecteur à listeSecteur
            listBoxSecteur.DataSource = listeSecteur;
        }
        // Format de l'affichage de listBoxSecteur
        private void listBoxSecteur_Format(object sender, ListControlConvertEventArgs e)
        {
            int idSecteur = ((Secteur)e.ListItem).Id;
            string nomSecteur = ((Secteur)e.ListItem).Nom;
            e.Value = String.Format("{0}. {1}", idSecteur, nomSecteur);
        }
        // Actualise listBoxLiaiosn
        public void refreshListBoxLiaison()
        {
            labelNoLiaison.Text = "";
            Secteur secteur = listBoxSecteur.SelectedItem as Secteur;
            listeLiaisonBySecteur = LiaisonDAO.findListeLiaisonBySecteur(secteur, listeLiaison);
            // Liaison de listBoxLiaison à listeLiaisonBySecteur
            listBoxLiaison.DataSource = listeLiaisonBySecteur;

            // Affichage du texte lorsque listeLiaisonBySecteur est vide
            bool isEmpty = !listeLiaisonBySecteur.Any();
            if (isEmpty) labelNoLiaison.Text = "Aucune Liaison";
        }
        // Format de l'affichage de listBoxSecteur
        private void listBoxLiaison_Format(object sender, ListControlConvertEventArgs e)
        {
            int index = listeLiaisonBySecteur.IndexOf((Liaison)e.ListItem) + 1;
            string nomPortDepart = ((Liaison)e.ListItem).PortDepart.Nom;
            string nomportArrivee = ((Liaison)e.ListItem).PortArrive.Nom;
            string dureeLiaison = ((Liaison)e.ListItem).Duree;
            e.Value = String.Format("{0}. {1} - {2} : {3}", index, nomPortDepart, nomportArrivee, dureeLiaison);
        }
        // Actualise les comboBoxPort
        public void refreshComboBoxPort()
        {
            // Ajout des ports dans les comboBox
            foreach (Port port in listePort)
            {
                comboBoxPortDepart.Items.Add(port);
                comboBoxPortArrivee.Items.Add(port);
            }

            // Affichage du nom de chaque port
            comboBoxPortDepart.DisplayMember = "nom";
            comboBoxPortArrivee.DisplayMember = "nom";
        }
        // Connexion à la base de données + rechargement des box au chargement du formulaire
        private void FormMenu_Load(object sender, EventArgs e)
        {
            this.refreshListBoxSecteur();
            this.refreshComboBoxPort();
        }
        // Rechargement de listboxSecteur lors du clique sur un secteur
        private void listBoxSecteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.refreshListBoxLiaison();
        }
        //Ajouter une liaison en appuyant sur le bouton Ajouter
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            // Récuération des données
            string duree = textBoxDuree.Text;
            Port portDepart = comboBoxPortDepart.SelectedItem as Port;
            Port portArrivee = comboBoxPortArrivee.SelectedItem as Port;
            Secteur secteur = listBoxSecteur.SelectedItem as Secteur;

            // Ajout d'une liaison lorsque les données sont remplies
            if (portDepart != null && portArrivee != null && secteur != null & duree != "")
            {
                Liaison liaison = new Liaison(duree, portDepart, portArrivee, secteur);
                listeLiaison.Add(liaison);
                manager.ajouterLiaison(liaison);
                this.refreshListBoxLiaison();
            }
            else
            {
                MessageBox.Show("Données invalides");
            }
        }
        //Supprimer la liaison en appuyant sur le bouton Supprimer
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            // Récupération de la liaison
            Liaison liaison = listBoxLiaison.SelectedItem as Liaison;

            // Suppression de la liaison si une liaison est séléctionnée
            if (liaison != null)
            {
                listeLiaison.Remove(liaison);
                manager.supprimerLiaison(liaison);
                this.refreshListBoxLiaison();
            }
        }
        // Modifier une liaison en appuyant sur le bouton Modifier
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // Récuération des données
            string duree = textBoxDureeModifier.Text;
            Liaison liaison = listBoxLiaison.SelectedItem as Liaison;

            // Suppression de la liaison si une liaison est séléctionnée et que la durée est indiquée
            if (liaison != null)
            {
                if (duree != "")
                {
                    liaison.Duree = duree;
                    manager.modifierLiaison(liaison, duree);
                    this.refreshListBoxLiaison();
                }
                else
                {
                    MessageBox.Show("Veuillez rentrer une durée");
                }
            }
        }
    }
}