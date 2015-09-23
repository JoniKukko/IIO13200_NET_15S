using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using System.Configuration;

namespace Tehtava4Viinikellari
{
    /// <summary>
    /// Kaikki toimii
    /// </summary>
    public partial class ViinikellariXelement : Window
    {


        private XElement wineFile;
        private List<Viini> wines;
        private HashSet<string> countries;




        public ViinikellariXelement()
        {
            InitializeComponent();

            // jaettuna useisiin pieniin metodeihin
            // ratkaisun helpottamiseksi

            this.loadXMLfile();

            this.parseCountries();
            this.drawCountries();

            this.parseWines();
            this.drawWines();
            
        }



        // lataa xml tiedoston
        private void loadXMLfile ()
        {
            // tiedostopolku haetaan configista.
            // tässä olisi hyvä olla failsafe mutta ei nyt ole koska tehtävänanto.
            this.wineFile = XElement.Load(ConfigurationManager.AppSettings["XMLFilePath"]);
        }




        // hakee xml tiedostosta maat
        private void parseCountries ()
        {
            // maat tuupataan kätevästi hashsettiin jolloin ei tule samaa maata useampaan kertaan
            this.countries = new HashSet<string>(
                    from country in this.wineFile.Elements("wine").Elements("maa") select country.Value
                );
        }



        // "piirretään" maat comboboksiin
        private void drawCountries ()
        {
            comboboxCountries.ItemsSource = this.countries;
        }




        // Haetaan viinit xml tiedostosta
        private void parseWines (string country = null)
        {
            // apumuuttuja vain
            IEnumerable<Viini> wineQuery;

            // jos maata ei ole annettu (alkutilanne) niin haetaan kaikki viinit
            if (country == null) {

                wineQuery = (from wine in this.wineFile.Elements("wine")
                              select new Viini(
                                  wine.Element("nimi").Value,
                                  wine.Element("maa").Value,
                                  wine.Element("arvio").Value
                                  )
                              );

            } else
            { // jos maa on annettu haetaan sen mukaiset viinit

                wineQuery = (from wine in this.wineFile.Elements("wine").Where(
                                    wine => (string)wine.Element("maa") == country
                                )
                                  select new Viini(
                                      wine.Element("nimi").Value,
                                      wine.Element("maa").Value,
                                      wine.Element("arvio").Value
                                      )
                              );
            }
            
            this.wines = wineQuery.ToList();

        }



        // "Piirretään" viinit datagriddiin
        private void drawWines ()
        {
            datagridWines.ItemsSource = this.wines;
        }




        // hakunapin painallus
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            // tarkastetaan että edes jotain on valittuna
            if (comboboxCountries.SelectedIndex != -1)
            {
                // hakee viinit
                this.parseWines(comboboxCountries.SelectedValue.ToString());
                // piirtää viinit
                this.drawWines();
            }
        }




    }
}
