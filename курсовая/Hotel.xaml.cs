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
using System.Windows.Navigation;
using System.Windows.Shapes;
using курсовая.DateBase;

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для Hotel.xaml
    /// </summary>
    public partial class Hotel : Page
    {
        DateBase.Model2 ds = new DateBase.Model2();
        public Hotel()
        {
            InitializeComponent();
            ds.otel.Load();
            dtgHotel.ItemsSource = ds.otel.Local;
            if (Admin.admin == true)
            {
                addBT.Visibility = Visibility.Visible;
                deleteBT.Visibility = Visibility.Visible;
                refresh.Visibility = Visibility.Visible;
            }
            else { addBT.Visibility = Visibility.Hidden; deleteBT.Visibility = Visibility.Hidden; refresh.Visibility = Visibility.Hidden; }
        }

        private void addBT_Click(object sender, RoutedEventArgs e)
        {
            AdminAllHotelAdd adminAllHotelAdd = new AdminAllHotelAdd();
            adminAllHotelAdd.Show();
        }

        otel selectEnt = new otel();
        private void deleteBT_Click(object sender, RoutedEventArgs e)
        {
            selectEnt = (otel)dtgHotel.SelectedItem;
            if (selectEnt != null)
            {
                try
                {
                    if (MessageBox.Show("Вы действительно хотите удалить этот элемент из базы данных?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ds.otel.Remove(selectEnt);
                        ds.SaveChanges();
                        dtgHotel.ItemsSource = ds.otel.Local.OrderBy(x=>x.Adress);
                    }
                }
                catch
                {
                    MessageBox.Show("----------------");
                }
            }       
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            ds.otel.Load();
            dtgHotel.ItemsSource = ds.otel.Local;
        }

        private void backBT_Click(object sender, RoutedEventArgs e)
        {
            GlavStrPage glavStrPage = new GlavStrPage();
            this.NavigationService.Navigate(glavStrPage);
        }
    }
}
