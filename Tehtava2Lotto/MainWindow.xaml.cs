using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtava2Lotto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BLLotto lottokone;



        public MainWindow()
        {
            // laitetaan lottokone pyörimään!
            this.lottokone = new BLLotto();
            InitializeComponent();
        }



        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            int Tyyppi, Lkm;

            // tarkistetaan syötteet, pitäisiköhän olla jossain muualla..
            if (int.TryParse(cmbChooseGame.SelectedIndex.ToString(), out Tyyppi) && int.TryParse(txtDrawnCount.Text, out Lkm))
            {

                // vaihdetaan lottokoneen tyyppi
                this.lottokone.Tyyppi = Tyyppi;

                // loopataan haluttu määrä rivejä
                for (int i=0; i< Lkm; i++)
                {
                    // pyydetään lottokoneelta uutta riviä
                    List<int> Numerot = lottokone.ArvoRivi();

                    // tulostetaan rivit
                    foreach (int Numero in Numerot)
                    {
                        txtRivit.Text += Numero + " ";
                    }
                    txtRivit.Text += "\r\n";
                }
            } else
            {
                txtRivit.Text += "VIRHE!!\r\n";
            }
        }



        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtRivit.Text = "";
        }


    }
}
