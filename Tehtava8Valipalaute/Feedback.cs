using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tehtava8Valipalaute
{
    class Feedback
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public string Learned { get; set; }
        public string WantToLearn { get; set; }
        public string Good { get; set; }
        public string Bad { get; set; }
        public string Other { get; set; }
        

        public Feedback(string Date, string Name, string Learned, string WantToLearn, string Good, string Bad, string Other)
        {
            this.Date = Date;
            this.Name = Name;
            this.Learned = Learned;
            this.WantToLearn = WantToLearn;
            this.Good = Good;
            this.Bad = Bad;
            this.Other = Other;
        }


        // tarkistetaan ilmentymän tiedot
        public bool SanityCheck()
        {
            // rumaa lujaa ja nopeesti
            return !(
                    (this.Date.Length == 0) ||
                    (this.Name.Length == 0) ||
                    (this.Learned.Length == 0) ||
                    (this.WantToLearn.Length == 0) ||
                    (this.Good.Length == 0) ||
                    (this.Bad.Length == 0) ||
                    (this.Other.Length == 0)
                );
        }
        

    }
}
