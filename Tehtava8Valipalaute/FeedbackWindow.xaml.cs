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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Tehtava8Valipalaute
{
    /// <summary>
    /// Interaction logic for FeedbackWindow.xaml
    /// </summary>
    public partial class FeedbackWindow : Window
    {

        // konstruktori ottaa vastaan listan palautteista ja näyttää ne samantien
        public FeedbackWindow(List<Feedback> feedbacks)
        {
            InitializeComponent();
            this.datagridFeedback.ItemsSource = feedbacks;
        }


        // nappi sulkee ikkunan.
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
