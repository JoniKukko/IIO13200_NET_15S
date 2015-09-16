using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

/// <summary>
/// Tehtävä 3
///     Kaikki muut toimii paitsi tiedostoon tallentamista ei ole.
/// </summary>


namespace Tehtava3
{
    public partial class MainWindow : Window
    {


        private List<string> Seurat = new List<string>(new string[] {
                "TPS", "Lukko", "Ässät","HIFK", "Blues", "HPK",
                "Tappara", "Ilves", "Sport","Pelicans", "KooKoo",
                "SaiPa", "Kärpät", "JYP", "KalPa"
            });

        private ObservableCollection<Pelaaja> Pelaajat = new ObservableCollection<Pelaaja>();





        public MainWindow()
        {
            InitializeComponent();
            cmbClub.ItemsSource = this.Seurat;
            lsbPlayers.ItemsSource = this.Pelaajat;
        }





        // tarkistetaan syötteet
        private bool checkInputs ()
        {
            int intTransferPrice;

            // onko jokin syöte tyhjä tai onko hinta muu kuin numero
            return (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtTransferPrice.Text) ||
                    string.IsNullOrWhiteSpace(cmbClub.Text)) ||
                    !int.TryParse(txtTransferPrice.Text, out intTransferPrice);
            
        }




        // simppeli helpperi
        private void clearInputs ()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtTransferPrice.Text = "";
            cmbClub.Text = "";
        }





        private void btnNewPlayer_Click(object sender, RoutedEventArgs e)
        { // lisää uuden pelaajan listaan tarkistuksien onnistuttua
            

            // onko virheitä
            if (this.checkInputs())
            {
                txtError.Text = "Virhe! Kaikki tiedot on pakollisia ja hinnan on oltava numero.";
                
            } // onko saman nimistä jo
            else if (this.Pelaajat.Any(x=> x.Etunimi==txtFirstName.Text && x.Sukunimi==txtLastName.Text))
            {
                txtError.Text = "Virhe! Kyseinen jeppe on jo listalla.";
                
            } // kaikki ok, lisätään listaan
            else
            {

                Pelaaja uusiPelaaja = new Pelaaja();
                uusiPelaaja.Etunimi = txtFirstName.Text;
                uusiPelaaja.Sukunimi = txtLastName.Text;
                uusiPelaaja.SiirtoHinta = int.Parse(txtTransferPrice.Text);
                uusiPelaaja.Seura = cmbClub.Text;
                this.Pelaajat.Add(uusiPelaaja);

                this.clearInputs();
            
                txtError.Text = "Pelaaja lisätty!";

            }
            
            
        }




        // ohjelman sulkeminen napista
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // suljetaan rumasti
            Tehtava3.Close();
        }




        // pelaajan tietojen haku
        private void lsbPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            // tarkastetaan että jotain on valittu
            if (lsbPlayers.SelectedIndex != -1)
            {
                // haetaan tiedot
                Pelaaja valittuPelaaja = lsbPlayers.SelectedItem as Pelaaja;

                // vaihdetaan tiedot
                txtFirstName.Text = valittuPelaaja.Etunimi;
                txtLastName.Text = valittuPelaaja.Sukunimi;
                txtTransferPrice.Text = valittuPelaaja.SiirtoHinta + "";
                cmbClub.Text = valittuPelaaja.Seura;
                txtError.Text = "Pelaajan tiedot haettu.";

            }

        }





        // poistaa valitun pelaajan
        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            // super älykäs switch-case rakenne valinnan tarkastamiseen
            switch (lsbPlayers.SelectedIndex)
            {
                case -1: // mitään ei ole valittu
                    txtError.Text = "Virhe! Et ole valinnut pelaajaa";
                    break;

                default: // jotain on valittu
                    // tässä olisi hyvä olla myös indeksin olemassaolon tarkastus
                    this.Pelaajat.RemoveAt(lsbPlayers.SelectedIndex);
                    txtError.Text = "Pelaaja poistettu.";
                    break;
            }
            
        }





        // haettujen tietojen tallennus
        private void btnSavePlayer_Click(object sender, RoutedEventArgs e)
        {
            
            // tarkastetaan että jotain on valittu
            if (lsbPlayers.SelectedIndex == -1)
            {
                txtError.Text = "Virhe! Et ole valinnut mitään";


            } // onko virheitä
            else if (this.checkInputs())
            {
                txtError.Text = "Virhe! Kaikki tiedot on pakollisia ja hinnan on oltava numero.";


            } // Löytyykö pelaaja
            else if (this.Pelaajat.Any(x => x.Etunimi == txtFirstName.Text && x.Sukunimi == txtLastName.Text))
            {
                Pelaaja valittuPelaaja = this.Pelaajat.FirstOrDefault(x => x.Etunimi == txtFirstName.Text && x.Sukunimi == txtLastName.Text) as Pelaaja;
                valittuPelaaja.SiirtoHinta = int.Parse(txtTransferPrice.Text);
                valittuPelaaja.Seura = cmbClub.Text;

                this.clearInputs();

                txtError.Text = "Pelaaja päivitetty!";
                
                // super hack
                lsbPlayers.ItemsSource = "";
                lsbPlayers.ItemsSource = this.Pelaajat;


            } // Jos pelaajaa ei löydy
            else
            {
                txtError.Text = "Virhe! Kyseistä jeppeä ei löytynyt";
                    

            }
                
        }




    }
}
