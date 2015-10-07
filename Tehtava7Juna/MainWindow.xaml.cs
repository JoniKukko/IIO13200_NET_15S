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
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace Tehtava7Juna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            // ladataan asemat
            LoadStations();
        }




        // asemien lataaminen
        private void LoadStations()
        {
            // käynnistetään uusi säie asemien lataamiseksi
            new Thread(() =>
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    // haetaan json string webistä
                    string stationJson = GetJsonFromUrl("http://rata.digitraffic.fi/api/v1/metadata/station");
                    // tehdään lista
                    List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(stationJson);
                    // tuupataan comboboksiin
                    combobox_Cities.ItemsSource = stations;

                }));

            }).Start(); // varsinainen säikeen "käynnistys"
        }




        // junien lataaminen
        private void LoadTrains(string stationCode = null)
        {
            // jos asemakoodi on annettu niin lisätään se urliin
            string url = (stationCode != null) 
                ? "http://rata.digitraffic.fi/api/v1/live-trains?station="+stationCode 
                : "http://rata.digitraffic.fi/api/v1/live-trains";

            // json stringin hakeminen palvelimelta
            string trainJson = GetJsonFromUrl(url);
            // tehdään junista lista
            List<Train> trains = JsonConvert.DeserializeObject<List<Train>>(trainJson);
            // tuupataan datagriddiin
            datagrid_Data.DataContext = trains;

        }


        
        // apumetodi jsonin lataamiseen
        private string GetJsonFromUrl(string url)
        {
            try
            {
                // käytetään webclienttia json stringin lataamiseen
                using (WebClient client = new WebClient())
                {
                    return client.DownloadString(url);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        // hakunapin klikkaus
        private void button_GetJson_Click(object sender, RoutedEventArgs e)
        {
            switch (combobox_Cities.SelectedIndex)
            {
                // jos mitään ei ole valittu
                case -1:
                    LoadTrains();
                    break;
                
                // jos jotain on valittuna haetaan sen itemin koodi
                default:
                    LoadTrains(((Station)combobox_Cities.SelectedItem).Koodi);
                    break;
            }
        }



    }
}
