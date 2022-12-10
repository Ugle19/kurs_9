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
        }
    }
}
