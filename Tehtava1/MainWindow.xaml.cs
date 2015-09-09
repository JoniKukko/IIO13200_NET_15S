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

namespace IIO13200_15S
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

            double WindowHeight, WindowWidth, HolderWidth;


            // validations
            if (!Double.TryParse(txtWindowHeight.Text, out WindowHeight))
            {
                txtWindowHeight.Text = "0";
                WindowHeight = 0;
            }

            if (!Double.TryParse(txtWindowWidth.Text, out WindowWidth))
            {
                txtWindowWidth.Text = "0";
                WindowWidth = 0;
            }

            if (!Double.TryParse(txtWindowHolderWidth.Text, out HolderWidth))
            {
                txtWindowHolderWidth.Text = "0";
                HolderWidth = 0;
            }
            
            
            // Window area
            blcWindowArea.Text = "" + (WindowHeight * WindowWidth);


            // Window holder 
            blcHolderPerimeter.Text = "" + (WindowHeight * 2 + WindowWidth * 2 + HolderWidth * 8);
            blcHolderArea.Text = "" + ((WindowHeight * 2 + WindowWidth * 2 + HolderWidth * 4) * HolderWidth);


        }
    }
}
