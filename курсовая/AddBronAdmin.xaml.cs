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
    /// Логика взаимодействия для AddBronAdmin.xaml
    /// </summary>
    public partial class AddBronAdmin : Window
    {
        DateBase.Model3 ds3 = new DateBase.Model3();
        public AddBronAdmin()
        {
            InitializeComponent();
        }

        private void BT2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BT3_Click(object sender, RoutedEventArgs e)
        {
            VvodID.Text = "";
            VvodName.Text = "";
            VvodNomer.Text = "";
            VvodStatus.Text = "";
        }


        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            bool w = false;
            string zbr = "Забронировано";
            string nezb = "Не забронировано";
            string n1 = "одноместная";
            string n2 = "двуместная";
            string n3 = "трехместная";
            StringBuilder errors = new StringBuilder();
            if (VvodStatus.Text == "" || VvodNomer.Text == "" || VvodName.Text == "" || VvodID.Text == "")
            {
                errors.Append("Есть пустые поля\n");
            }
            if (ds3.bron.Local.Where(x => x.id == int.Parse(VvodID.Text)).FirstOrDefault() != null)
            {
                errors.Append("ID занято\n");
            }
            if (ds3.bron.Local.Where(x => x.hotel == VvodName.Text && x.Room == VvodNomer.Text).FirstOrDefault() != null)
            {
                errors.Append("ОШИБКА\n");
            }
            if (zbr != VvodStatus.Text && nezb != VvodStatus.Text)
            {
                errors.Append("Не правильный формат для статуса\n");
            }
            if (VvodNomer.Text != n1 && VvodNomer.Text != n2 && VvodNomer.Text != n3)
            {
                errors.Append("Не правильный формат для номера\n");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                bron bron1 = new bron();
                bron1.id = int.Parse(VvodID.Text);
                bron1.hotel = VvodName.Text;
                bron1.Room = VvodNomer.Text;
                bron1.Bron1 = VvodStatus.Text;
                ds3.bron.Add(bron1);
                ds3.SaveChanges();
                w = true;
            }
            if (w == true)
            {
                MessageBox.Show("ВСЕ УСПЕШНО");
            }
            else if (w == false)
            {
                MessageBox.Show("ЧТО-ТО НЕ ТАК");
            }
        }
    }
}
