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

namespace LeastSquare
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            WelcomePanel.Visibility = Visibility.Hidden;
            StartButton.IsEnabled = false;
            FormulasButton.IsEnabled = false;

            Panel.SetZIndex(TableFrame, -1);
            TableFrame.Content = new pages.Worktop();

            CloseTableButton.IsEnabled = true;
            CloseTableButton.Visibility = Visibility.Visible;
        }

        private void CloseTableButton_Click(object sender, RoutedEventArgs e)
        {
            WelcomePanel.Visibility = Visibility.Visible;
            StartButton.IsEnabled = true;
            FormulasButton.IsEnabled = true;

            Panel.SetZIndex(TableFrame, -2);
            TableFrame.Content = null;

            CloseTableButton.IsEnabled = false;
            CloseTableButton.Visibility = Visibility.Hidden;
        }
    }
}
