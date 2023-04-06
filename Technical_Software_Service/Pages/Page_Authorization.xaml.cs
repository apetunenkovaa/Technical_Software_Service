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

namespace Technical_Software_Service
{
    /// <summary>
    /// Логика взаимодействия для Page_Authorization.xaml
    /// </summary>
    public partial class Page_Authorization : Page
    {
        public Page_Authorization()
        {
            InitializeComponent();
            tbLogin.Focus();
            tbLogin.Text = "APotapin";
            pbPassword.Password = "admin";
        }

        private void cbShowPassword_Click(object sender, RoutedEventArgs e) // Показ пароля
        {
            if (cbShowPassword.IsChecked == true)
            {
                tbPassword.Text = pbPassword.Password;

                pbPassword.Visibility = Visibility.Hidden;
                tbPassword.Visibility = Visibility.Visible;
            }
            else
            {
                pbPassword.Visibility = Visibility.Visible;
                tbPassword.Visibility = Visibility.Hidden;
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = pbPassword.Password;
            if (tbLogin.Text == "" || pbPassword.Password == "")
            {
                MessageBox.Show("Не все обязательные поля заполнены!");
            }
            else
            {
                Users user = DataBase.Base.Users.FirstOrDefault(z => z.UserName == login && z.Password == password);
                if (user == null)
                {
                    MessageBox.Show("Пользователя не существует!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    ClassFrame.MainF.Navigate(new Page_Anything(user));
                }
            }
        }
    }
}
