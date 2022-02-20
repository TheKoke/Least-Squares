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

namespace LeastSquare.Pages
{
    public partial class Worktop : Page
    {
        public Worktop()
        {
            InitializeComponent();
        }

        private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddingButton.Visibility = Visibility.Visible;
            AddingButton.IsEnabled = true;

            Point coordinates = Mouse.GetPosition(MainGrid);
            AddingButton.Margin = new Thickness(coordinates.X * 2 - (573 - AddingButton.Width), 
                coordinates.Y * 2 - (530 - AddingButton.Height), 0, 0);
        }

        private void MainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AddingButton.IsEnabled)
            {
                AddingButton.IsEnabled = false;
                AddingButton.Visibility = Visibility.Hidden;
            }
        }
    }
}

