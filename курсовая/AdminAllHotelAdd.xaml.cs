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
using System.Windows.Shapes;
using курсовая.DateBase;

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для AdminAllHotelAdd.xaml
    /// </summary>
    public partial class AdminAllHotelAdd : Window
    {
        DateBase.Model2 ds2 = new DateBase.Model2();
        public AdminAllHotelAdd()
        {
            InitializeComponent();
            List<string> telef = new List<string>();
            telef.Add("+7");
            telef.Add("8");
            ComTel.ItemsSource = telef;
        }
        public int n;
        private void VvodCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            n++;
            if (n == 1)
            {
                VvodCity.Text = VvodCity.Text[0].ToString().ToUpper();
            }
            else
            {
                VvodCity.SelectionStart = VvodCity.Text.Length;
            }
            if (VvodCity.Text.Length == 0)
            {
                n = 0;
            }
        }

        private void BT2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BT3_Click(object sender, RoutedEventArgs e)
        {
            VvodID.Text = "";
            VvodName.Text = "";
            VvodCity.Text = "";
            VvodAdress.Text = "";
            VvodNomer.Text = "";
        }

        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            bool u = false;
            StringBuilder errors = new StringBuilder();
            if (ds2.otel.Local.Where(z => z.Nomer_hotel == int.Parse(VvodID.Text)).FirstOrDefault() != null)
            {
                errors.AppendLine("ID занят");
            }
            if (VvodNomer.Text.Length <=5)
            {
                errors.AppendLine("Данные номера не корректны");
            }
            if (VvodName.Text == "" || VvodCity.Text == "" || VvodAdress.Text =="" || VvodNomer.Text == "")
            {
                errors.AppendLine("Есть пустые ячейки");
            }
            if(ds2.otel.Local.Where(z =>z.Adress == VvodAdress.Text || z.N == VvodCity.Text).FirstOrDefault()!=null)
            {
                errors.AppendLine("Ошибка в вводе данных");    
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                otel ot = new otel();
                ot.Nomer_hotel = int.Parse(VvodID.Text);
                ot.N = VvodName.Text;
                ot.Gorod = VvodCity.Text;
                ot.Adress = VvodAdress.Text;
                ot.Nomer_tel = (ComTel.SelectedItem + VvodNomer.Text);
                ds2.otel.Add(ot);
                ds2.SaveChanges();
                u = true;
            }
            if (u == true)
            {
                MessageBox.Show("ВСЕ УСПЕШНО");
            }
            else if (u==false)
            {
                MessageBox.Show("ЧТО-ТО НЕ ТАК");
            }
        }
    }
}
