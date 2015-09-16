using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3
{
    class Pelaaja
    {

        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string KokoNimi { get { return Etunimi + " " + Sukunimi + ", " + Seura; } }
        public string Seura { get; set; }
        public int SiirtoHinta { get; set; }
        
    }
}
