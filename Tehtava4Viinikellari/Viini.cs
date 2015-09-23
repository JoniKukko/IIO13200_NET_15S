using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava4Viinikellari
{
    class Viini
    {
        public string nimi { get; set; }
        public string maa { get; set; }
        public string arvio { get; set; }

        public Viini(string nimi, string maa, string arvio)
        {
            this.nimi = nimi;
            this.maa = maa;
            this.arvio = arvio;
        }
        
    }
}
