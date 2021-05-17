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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для WindowSettShop.xaml
    /// </summary>
    public partial class WindowSettShop : Window
    {
        SettShopEntities context;
        public WindowSettShop(SettShopEntities context, Shopinformation currentinformation)
        {
            InitializeComponent();
            this.context = context;
            FirstName.ItemsSource = context.Owner_s.ToList();
            Name.ItemsSource = context.Shopinformation.ToList();

            this.DataContext = currentinformation;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEdit())
            {
                context.SaveChanges();
                this.Close();
            }
        
    }
        private bool CheckEdit()
        {
            var reg = this.DataContext as Shopinformation;
            if (reg.Name == null)
            {
                MessageBox.Show("Владелец не выбран");
                return false;
            }
            if (reg.Name == null)
            {
                MessageBox.Show("Название магазина не выбрано");
                return false;
            }
            if (reg.Adress == null)
            {
                MessageBox.Show("Адресс не записан");
                return false;
            }

            if (reg.Shopphone == null)
            {
                MessageBox.Show("Номер магазина не записан");
                return false;
            }
            return true;
        }
    }
}
