using MySql.Data.MySqlClient.Memcached;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        DateBase.Model1 dbc = new DateBase.Model1();
        public Reg()
        {
            InitializeComponent();
            List<string> telef = new List<string>();
            telef.Add("+7");
            telef.Add("8");
            ComTel.ItemsSource = telef;
        }
        //написать поля для создания пароля и логина 
        //создать для них регекс
        //два поля для пароля 
        Regex InputID = new Regex(@"[0-9]"); // [а-яА-Я]
        private void VvodID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match matchID = InputID.Match(e.Text);
            if (!matchID.Success)
            {
                e.Handled = true;
            }
        }
        Regex InputSur = new Regex(@"[а-яА-Я]");
        private void FAM_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match matchSur = InputSur.Match(e.Text);
            if (!matchSur.Success)
            {
                e.Handled = true;
            }
        }

        Regex InputLogin = new Regex(@"[a-zA-Z0-9_\-\.]");
        private void VvodLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match login = InputLogin.Match(e.Text);
            InputLogin.Match(e.Text);
            if (!login.Success)
            {
                e.Handled = true;
            }
        }
        bool qwe = false;
        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            dbc.Clientt.Load();
            int i = int.Parse(VvodID.Text);
            MessageBox.Show($"{i}");
            StringBuilder errors = new StringBuilder();
            if (dbc.Clientt.Local.Where(z => z.id == int.Parse(VvodID.Text)).FirstOrDefault() != null)
            {
                errors.AppendLine("ID занят");
            }
            else { MessageBox.Show("ID не занят");  }

            if (VvodPas.Text.Length != 4 || VvodPasID.Text.Length != 6)
            {
                errors.AppendLine("Данные паспорта не верны");
            }
            if (VvodNomer.Text.Length != 10)
            {
                errors.AppendLine("Данные номера не корректны");
            }
            if (VvodFAM.Text == "" || NAmeVvod.Text == "" || VvodOt.Text == "" || VvodPas.Text == "" || VvodPasID.Text == "" || VvodNomer.Text == "")
            {
                errors.AppendLine("Есть пустые ячейки");

            }
            if (char.IsLetter(VvodLogin.Text, 0) == true)
            {
                if (char.IsLetter(VvodPas.Text, 0) == true)
                {
                        MessageBox.Show("Пароль и логин верны");
                }
            }
            else { errors.AppendLine("Некорректно указан логин или пароль\n"); }

            if ((dbc.Clientt.Local.Where(y => y.login == VvodLogin.Text || y.password == VvodPar.Text).FirstOrDefault() != null))
            {
                errors.AppendLine("логин или пароль совпадают\n");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                dbc.Clientt.Load();
                Clientt client = new Clientt();
                client.id = int.Parse(VvodID.Text);
                client.surname = VvodFAM.Text;
                client.name = NAmeVvod.Text;
                client.second_surname = VvodOt.Text;
                client.seria = int.Parse(VvodPas.Text);
                client.nomer = int.Parse(VvodPasID.Text);
                client.phone = (ComTel.SelectedItem + VvodNomer.Text);
                client.login = VvodLogin.Text;
                client.password = VvodPar.Text;
                dbc.Clientt.Add(client);
                dbc.SaveChanges();
                qwe = true;
            }
            if (qwe == true)
            {
                MessageBox.Show("ВСЕ ОК");
            }
            else if (qwe == false)
            {
                MessageBox.Show("ЧТО-ТО НЕ ТАК ");
            }
        }

        private void BT2_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void BT3_Click(object sender, RoutedEventArgs e)
        {
            VvodFAM.Text = "";
            NAmeVvod.Text = "";
            VvodOt.Text = "";
            VvodPas.Text = "";
            VvodPasID.Text = "";
            ComTel.SelectedIndex = 0;
            VvodNomer.Text = "";
            VvodID.Text = "";
            VvodLogin.Text = "";
            VvodPas.Text = "";
        }
        public int n = 0;
        private void VvodFAM_TextChanged(object sender, TextChangedEventArgs e)
        {
            n++;
            if (n == 1)
            {
                VvodFAM.Text = VvodFAM.Text[0].ToString().ToUpper();
            }
            else
            {
                VvodFAM.SelectionStart = VvodFAM.Text.Length;
            }
            if (VvodFAM.Text.Length == 0)
            {
                n = 0;
            }
        }
        public int p = 0;
        private void NAmeVvod_TextChanged(object sender, TextChangedEventArgs e)
        {
            p++;
            if (p == 1)
            {
                NAmeVvod.Text = NAmeVvod.Text[0].ToString().ToUpper();
            }
            else
            {
                NAmeVvod.SelectionStart = NAmeVvod.Text.Length;
            }
            if (NAmeVvod.Text.Length == 0)
            {
                p = 0;
            }
        }
        public int t = 0;
        private void VvodOt_TextChanged(object sender, TextChangedEventArgs e)
        {
            t++;
            if (t == 1)
            {
                VvodOt.Text = VvodOt.Text[0].ToString().ToUpper();
            }
            else
            {
                VvodOt.SelectionStart = VvodOt.Text.Length;
            }
            if (VvodOt.Text.Length == 0)
            {
                t = 0;
            }
        }


    }
}
