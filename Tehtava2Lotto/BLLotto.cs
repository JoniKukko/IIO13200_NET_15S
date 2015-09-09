using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava2Lotto
{
    
    class BLLotto
    {
        public 
            int Tyyppi;

        private
            int PieninNumero,
                SuurinNumero,
                LkmNumero;

        // ilman staattisuutta random tuotti samoja numeroita pyydettäessä useampaa riviä kerralla
        static private 
            Random Satunnainen;




        public BLLotto()
        {
            // alustetaan pelitiedot vaikkapa lottoon
            Satunnainen = new Random();
            this.Tyyppi = 0;
            this.TarkistaPeli();
        }




        // Vaihtaa instanssimuuttujiin sopivat arvot pelityypin mukaan
        private void TarkistaPeli()
        {
            switch (this.Tyyppi)
            {
                case 1: // VikingLotto
                    this.PieninNumero = 1;
                    this.SuurinNumero = 48;
                    this.LkmNumero = 6;
                    break;
                case 2: // Eurojackpot
                    this.PieninNumero = 1;
                    this.SuurinNumero = 50;
                    this.LkmNumero = 5;
                    break;
                default: // Lottopeli = 0
                    this.PieninNumero = 1;
                    this.SuurinNumero = 39;
                    this.LkmNumero = 7;
                    break;
            }
        }



        // luo yhden rivin pelityypin mukaan
        public List<int> ArvoRivi()
        {
            // tarkitetaan pelin säännöt
            this.TarkistaPeli();
            
            List<int> Numerot = new List<int>();
            
            // luodaan satunnaislukuja listaan
            for (int i=0; i<this.LkmNumero; i++)
            {
                Numerot.Add(Satunnainen.Next(this.PieninNumero, this.SuurinNumero));
            }
            
            // palautetaan lista
            return Numerot;

        }



    }
}
