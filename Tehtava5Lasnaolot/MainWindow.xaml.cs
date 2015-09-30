using System.Windows;

namespace Tehtava5Lasnaolot
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

        private void buttonHae_Click(object sender, RoutedEventArgs e)
        {
            datagridLasnaolot.DataContext = ADODataReader.Program.GetDataReal(textboxUserId.Text);
        }
    }
}
