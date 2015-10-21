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
using System.Xml.Linq;
using System.Configuration;

namespace Tehtava8Valipalaute
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private XElement feedbackFile;
        private List<Feedback> feedbacks;
        



        public MainWindow()
        {
            InitializeComponent();

            // yritetään ladata tiedostoa ja sen jälkeen parsitaan elementit
            if (this.loadXMLfile())
            {
                this.parseFeedbacks();
            }

        }




        // xml tiedoston lataaminen
        private bool loadXMLfile ()
        {
            try
            {
                // tiedoston sisältö xelement tiedostoon
                this.feedbackFile = XElement.Load(ConfigurationManager.AppSettings["XMLFilePath"]);
            }
            catch (Exception)
            {
                MessageBox.Show("XML tiedostoa ei voitu aukaista!");
                return false;
            }
            return true;
        }





        // Haetaan palautteet xelement tiedostosta
        private bool parseFeedbacks()
        {
            // haetaan elementit xml filestä
            IEnumerable<Feedback> feedbackQuery = 
                (from feedback in this.feedbackFile.Elements("palaute")
                    select new Feedback(
                        feedback.Element("pvm").Value,
                        feedback.Element("tekija").Value,
                        feedback.Element("opittu").Value,
                        feedback.Element("haluanoppia").Value,
                        feedback.Element("hyvaa").Value,
                        feedback.Element("parannettavaa").Value,
                        feedback.Element("muuta").Value
                    )
                );
            
            // muodostetaan siitä lista
            this.feedbacks = feedbackQuery.ToList();
            return true;
        }






        // palautteen tallennus
        private bool saveFeedback (Feedback newFeedback)
        {
            
            // lisätään xelement tiedostoon
            this.feedbackFile.Add(
                    new XElement("palaute",
                        new XElement("pvm", newFeedback.Date),
                        new XElement("tekija", newFeedback.Name),
                        new XElement("opittu", newFeedback.Learned),
                        new XElement("haluanoppia", newFeedback.WantToLearn),
                        new XElement("hyvaa", newFeedback.Good),
                        new XElement("parannettavaa", newFeedback.Bad),
                        new XElement("muuta", newFeedback.Other)
                    )
                );
            // lisätään listaan
            this.feedbacks.Add(newFeedback);
            // edellä mainitut tehdään vaikkei tiedostoa voitaisikaan tallentaa!
            // tässä on kehitysversion paikka, erillinen nappi "yritä tallentamista uudestaan" tai jotain semmoista
            // koska data kuitenkin säilyy ohjelman sisällä

            try
            {
                // yritetään tallentaa xelement tiedostoa
                this.feedbackFile.Save(ConfigurationManager.AppSettings["XMLFilePath"]);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }





        // tallenna nappi
        private void button_send_Click(object sender, RoutedEventArgs e)
        {

            // rakennetaan olio
            Feedback newFeedback = new Feedback(
                textbox_date.Text,
                textbox_name.Text,
                textbox_learned.Text,
                textbox_wanttolearn.Text,
                textbox_good.Text,
                textbox_bad.Text,
                textbox_other.Text
                );


            // tarkistetaan se
            if (newFeedback.SanityCheck()) {

                // tallennetaan se
                if (this.saveFeedback(newFeedback))
                {
                    MessageBox.Show("Palaute tallennettu!");
                } else
                {
                    MessageBox.Show("Tiedostoa ei voitu avata. Muutokset eivät ole pysyviä!");
                }

                // tyhjennetään nätisti lootat..
                textbox_date.Text = textbox_name.Text = textbox_learned.Text = textbox_wanttolearn.Text = textbox_good.Text = textbox_bad.Text = textbox_other.Text = "";

            } else
            {
                MessageBox.Show("Kaikki kohdat ovat pakollisia!");
            }
            
        }



        // nappi palauteikkunan aukaisuun
        private void feedbackListbutton_Click(object sender, RoutedEventArgs e)
        {
            // luodaan ikkuna ja näytetään se
            FeedbackWindow feedWindow = new FeedbackWindow(this.feedbacks);
            feedWindow.ShowDialog();
        }


    }
}
