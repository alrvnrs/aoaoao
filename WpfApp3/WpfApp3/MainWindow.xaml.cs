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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SettShopEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new SettShopEntities();
            DataGridRegistration.ItemsSource = context.Shopinformation.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btnEdit = sender as Button;
            var currentinformation = btnEdit.DataContext as Shopinformation;
            var win = new WindowSettShop(context, currentinformation);
            win.ShowDialog();

        }

        private void BtnAddClic_Click(object sender, RoutedEventArgs e)
        {
            var newEdit = new Shopinformation();
            context.Shopinformation.Add(newEdit);
            WindowSettShop win = new WindowSettShop(context, newEdit);
            win.ShowDialog();
            DataGridRegistration.ItemsSource = context.Shopinformation.ToList();
        }

        private void BtnDeleteClic_Click(object sender, RoutedEventArgs e)
        {
            var row = DataGridRegistration.SelectedItem as Shopinformation;
            if (row == null)
            {
                MessageBox.Show("Строка не выбрана");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы уверены", "Вопрос", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context.Shopinformation.Remove(row);
                context.SaveChanges();
                DataGridRegistration.ItemsSource = context.Shopinformation.ToList();
            }
        }

        private void CmbSelectOwner_s_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                if (CmbSelectOwner_s.SelectedItem == null) return;
                var currentOwner_s = (Owner_s)CmbSelectOwner_s.SelectedItem;
                List<Owner_s> ListOwner_s = context.Owner_s.ToList();
                DataGridRegistration.ItemsSource = ListOwner_s.Where(x => x.FirstName == currentOwner_s).ToList();
           
        }
        
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DataGridRegistration.ItemsSource = context.Shopinformation.ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
      