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
    /// <summary>
    /// Логика взаимодействия для Worktop.xaml
    /// </summary>
    public partial class Worktop : Page
    {
        public Worktop()
        {
            InitializeComponent();
        }

        private void Root_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Button addbutton = new()
            {
                Width = 78,
                Height = 21,
                Background = new SolidColorBrush(Colors.Gainsboro),
                Foreground = new SolidColorBrush(Colors.Black),
                Content = "Добавить столбец",
                Cursor = Cursors.Hand,
            };

            if (!Root.Children.Contains(addbutton))
            {
                Root.Children.Add(addbutton);
            }

            Canvas.SetLeft(addbutton, Mouse.GetPosition(Root).X);
            Canvas.SetTop(addbutton, Mouse.GetPosition(Root).Y);
        }
    }
}
