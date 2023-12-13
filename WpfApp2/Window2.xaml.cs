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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(LoginTextBox.Text) && string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Заполните поля формы");
                return;
            }
            var user  = DBContext.GetContext().Users.FirstOrDefault(p=>p.Login ==  LoginTextBox.Text && p.Password = PasswordBox.Password);
            if (user != null)
            {
                DateTime dateTime = DateTime.Now;
                if(dateTime.Hour >=6 && dateTime.Hour <=12)
                    MessageBox.Show($"Доброе утро,{user.Name}");
                else if(dateTime.Hour >12 && dateTime.Hour <=6)
                    MessageBox.Show($"Добрый день,{user.Name}");
                Window1 window = new Window1();
                window.Show();
            }
            else MessageBox.Show("Неверный логин или пароль");

        }
    }
}
