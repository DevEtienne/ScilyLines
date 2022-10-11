using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScilyLines
{
    public class Liaison
    {
        private string duree;
        private Port portDepart;
        private Port portArrive;
        private Secteur secteur;
        public Liaison(string duree, Port portDepart, Port portArrive, Secteur secteur)
        {
            this.duree = duree;
            this.portDepart = portDepart;
            this.portArrive = portArrive;
            this.secteur = secteur;
        }
        public string Duree { get => duree; }
        public Port PortDepart { get => portDepart; }
        public Port PortArrive { get => portArrive; }
        public Secteur Secteur { get => secteur; }
    }
}
