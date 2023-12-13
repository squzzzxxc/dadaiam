using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenderComboBox.ItemsSource = DBContext.GetContext().IMP_UP07_Gender.ToList();
            UpdateClients();
        }
        public void UpdateClients()
        {
            var clients = DBContext.GetContext().IMP_UP07_Client.ToList();
            if (GenderComboBox.SelectedIndex != -1)
            {
                IMP_UP07_Gender gender = GenderComboBox.SelectedItem as IMP_UP07_Gender;
                clients = clients.Where(p => p.GenderId == gender.Id).ToList();
            }
            if(!string.IsNullOrEmpty(SearchTextBox.Text))
                clients = clients.Where(p=>p.Name.Contains(SearchTextBox.Text) || p.LastName.Contains(SearchTextBox.Text)).ToList();
            if(SortComboBox.SelectedIndex != -1)
            {
                switch(SortComboBox.SelectedIndex)
                {
                    case 0:
                        clients = clients.OrderBy(p => p.Name).ToList();
                        break;
                    case 1:
                        clients = clients.OrderByDescending(p => p.Name).ToList();
                        break;
                    case 2:
                        clients = clients.OrderBy(p => p.LastName).ToList();
                        break;
                    case 3:
                        clients = clients.OrderByDescending(p => p.LastName).ToList();
                        break;
                }
            }
            if(clients.Count == 0)
            {
                MessageBox.Show("Ничего не найдено", "Результаты поиска");
            }
            dataGrid.ItemsSource = clients;
        }

        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateClients();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClients();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                var dialogResult = MessageBox.Show("Вы действительно хотите удалть данные?", "Удаление данных", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    try
                    {
                        IMP_UP07_Client client = dataGrid.SelectedItem as IMP_UP07_Client;
                        DBContext.GetContext().IMP_UP07_Client.Remove(client);
                        DBContext.GetContext().SaveChanges();
                        UpdateClients();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Произошла ошибка при выполнении запроса к БД", "Ошибка");
                    }
                }
                
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                DeleteButton.IsEnabled = true;
                EditButton.IsEnabled = true;
            }
            else
            {
                DeleteButton.IsEnabled = false;
                EditButton.IsEnabled = false;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Owner = this;
            window.Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1((IMP_UP07_Client)dataGrid.SelectedItem);
            window.Owner = this;
            window.Show();
        }
    }
}
