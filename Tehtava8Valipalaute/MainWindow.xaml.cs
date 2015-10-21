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

namespace Tehtava8Valipalaute
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_send_Click(object sender, RoutedEventArgs e)
        {

            // rakennetaan olio
            Feedback palaute = new Feedback(
                textbox_date.Text,
                textbox_name.Text,
                textbox_learned.Text,
                textbox_wanttolearn.Text,
                textbox_good.Text,
                textbox_bad.Text,
                textbox_other.Text
                );


            // tarkistetaan se
            if (palaute.SanityCheck()) {
                MessageBox.Show("KYLLÄÄH!");
            } else
            {
                MessageBox.Show("EEEEIihh");
            }
            
        }

    }
}
