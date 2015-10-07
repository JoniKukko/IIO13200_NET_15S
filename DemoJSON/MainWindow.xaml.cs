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

namespace DemoJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public string json = "";
        

        public MainWindow()
        {
            InitializeComponent();
        }



        #region Methods


        private void Demo1()
        {
            // haetaan Json
            this.json = GetSimpleJson();
            // muunnetaan se olioiksi
            List<Person> persoonat = JsonConvert.DeserializeObject<List<Person>>(this.json);
            // näytetään UI:ssa
            textbox_Json.Text = this.json;
            datagrid_Data.DataContext = persoonat;

        }


        private void Demo2()
        {
            // haetaan Json
            this.json = GetJsonFromWeb();
            // muunnetaan se olioiksi
            List<Politic> poliitikot = JsonConvert.DeserializeObject<List<Politic>>(this.json);
            // näytetään UI:ssa
            textbox_Json.Text = this.json;
            datagrid_Data.DataContext = poliitikot;

        }




        private string GetSimpleJson()
        {
            return @"
                [
                    {'Name':'Olli Opiskelija','Gender':'Male','birthday':'1995-12-24'},
                    {'Name':'Matti Mainio','Gender':'Male','birthday':'1985-12-25'}
                ]";
        }



        private string GetJsonFromWeb()
        {
            try
            {
                using (WebClient client = new WebClient()) {
                    string url = String.Format("http://student.labranet.jamk.fi/~salesa/mat/JsonTest");
                    return client.DownloadString(url);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        

        #endregion


        private void button_GetJson_Click(object sender, RoutedEventArgs e)
        {
            Demo2();
        }
    }
}
