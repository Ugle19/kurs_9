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

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public bool admin = false; 
        DateBase.Model1 db = new DateBase.Model1();
        public MainWindow()
        {
            InitializeComponent();
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.Clientt.Load();
            if (db.Clientt.Local.Where(x => x.login == loginV.Text && x.password == passwordV.Password ).FirstOrDefault() != null)
            {
                if (db.Clientt.Local.Where(x => x.login == loginV.Text && x.password == passwordV.Password && x.admin == true).FirstOrDefault() != null)
                {
                    Admin.admin = true;
                }
                else { Admin.admin = false; }
                MessageBox.Show("Вход выполнен успешно");

                AllHotel allHotel = new AllHotel();
                allHotel.Show();
                this.Close();
            }
            else { MessageBox.Show("Что-то пошло не так"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Close();
        }
    }
}
