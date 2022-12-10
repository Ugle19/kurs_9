using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для AllHotel.xaml
    /// </summary>
    public partial class AllHotel : Window
    {

        public AllHotel()
        {
            InitializeComponent();

        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
             FrameName.Navigate(new Hotel());
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
