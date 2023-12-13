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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private bool isEdit;
        public IMP_UP07_Client Client { get; set; }
        public Window1(IMP_UP07_Client client = null)
        {
            InitializeComponent();
            GenderComboBox.ItemsSource = DBContext.GetContext().IMP_UP07_Gender.ToList();
            if (client == null)
            {
                Client = new IMP_UP07_Client();
                this.Title = "Добавление данных";
                isEdit = false;
            }
            else
            {
                Client = client;
                this.Title = "Редактирование данных";
                isEdit = true;
            }
            HeaderTextBlock.Text = this.Title;
            this.DataContext = Client;
        }

        private void SaveEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isEdit)
                    DBContext.GetContext().IMP_UP07_Client.Add(Client);
                DBContext.GetContext().SaveChanges();
                ((MainWindow)this.Owner).UpdateClients();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
    }
}
