using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScilyLines
{
    public class Secteur
    {
        int id;
        string nom;

        public Secteur(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public int Id { get => id;}
        public string Nom { get => nom;}
    }
}
