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
    /// Логика взаимодействия для BronPage.xaml
    /// </summary>
    public partial class BronPage : Page
    {
        DateBase.Model3 db3 = new DateBase.Model3();
        public BronPage()
        {
            InitializeComponent();
            db3.bron.Load();
            List<string> a = new List<string>();
            a.Add("одноместная");
            a.Add("двуместная");
            a.Add("трехместная");
            if (Admin.admin == true)
            {
                addBt.Visibility = Visibility.Visible;
                deleteBT.Visibility = Visibility.Visible;
                refresh.Visibility = Visibility.Visible;
            }
            else { addBt.Visibility = Visibility.Hidden; deleteBT.Visibility = Visibility.Hidden; refresh.Visibility = Visibility.Hidden; }
            // textB2.ItemsSource = a;
            dtgBron.ItemsSource = db3.bron.Local;
         //   textB1.ItemsSource = db3.bron.Local;
           // textB2.ItemsSource = db3.bron.Local;
        }
        bron br1 = new bron();
        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            bool q = false;
            //   string asd = (string)textB1.SelectedItem;
            // string dsa = (string)textB2.SelectedItem;
            string nebr = "Не забронировано";
            string zbr = "Забронировано";
            br1 = (bron)dtgBron.SelectedItem;
            if (br1 != null)
            {

                if (db3.bron.Local.Where(z => z.hotel == br1.hotel && z.Room == br1.Room && z.Bron1 == nebr).FirstOrDefault() != null)
                {
                    bron bron = new bron();
                    bron.id = br1.id;
                    bron.hotel = br1.hotel;
                    bron.Room = br1.Room;
                    bron.Bron1 = zbr;
                    db3.bron.Remove(br1);
                    db3.bron.Add(bron);
                    db3.SaveChanges();
                    q = true;
                }
                else { MessageBox.Show("-----------------------"); }
                if (q == true)
                {
                    MessageBox.Show("ВСЕ УСПЕШНО");
                }
                else if (q == false)
                {
                    MessageBox.Show("ЧТО-ТО НЕ ТАК");
                }
            }
            else { MessageBox.Show("Вы ничего не выбрали"); }
        }

        private void backBT_Click(object sender, RoutedEventArgs e)
        {
            GlavStrPage glavStrPage = new GlavStrPage();
            this.NavigationService.Navigate(glavStrPage);
            //FrameName.Navigate(new GlavStrPage());
        }

        bron selectEnt = new bron();
        private void deleteBT_Click(object sender, RoutedEventArgs e)
        {
            selectEnt = (bron)dtgBron.SelectedItem;
            string nebr = "Не забронировано";
            string zbr = "Забронировано";
            if (selectEnt != null)
            {
                try
                {
                    if (db3.bron.Local.Where(z => z.Bron1 == zbr).FirstOrDefault() != null)
                    {
                        if (MessageBox.Show("Вы действительно хотите убрать запись ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            bron bron = new bron();
                            bron.id = selectEnt.id;
                            bron.hotel = selectEnt.hotel;
                            bron.Room = selectEnt.Room;
                            bron.Bron1 = nebr;
                            db3.bron.Remove(selectEnt);
                            db3.bron.Add(bron);
                            db3.SaveChanges();
                           // dtgBron.ItemsSource = db3.bron.Local.OrderBy(x => x.id);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("----------------");
                }
            }
        }

        private void addBt_Click(object sender, RoutedEventArgs e)
        {
            AddBronAdmin addBronAdmin = new AddBronAdmin();
            addBronAdmin.Show();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            db3.bron.Load();
            dtgBron.ItemsSource = db3.bron.Local;
        }
    }
}
