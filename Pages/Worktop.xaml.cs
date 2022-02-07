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

        private void Root_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                ColumnButton.IsEnabled = true;
                ColumnButton.Background = Brushes.Khaki;
                ColumnButton.Visibility = Visibility.Visible;
            }
        }
    }
}
