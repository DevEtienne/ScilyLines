using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScilyLines
{
    public class Port
    {
        int id;
        string nom;

        public Port(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public int Id { get => id; }
        public string Nom { get => nom; }
    }
}
