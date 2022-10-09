using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScilyLines
{
    internal class Liaison
    {
        int id;
        string duree;
        Port portDepart;
        Port portArrive;
        Secteur secteur;

        public Liaison(int id, string duree)
        {
            this.id = id;
            this.duree = duree;
        }
    }
}
