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
    /// Логика взаимодействия для Page_Home.xaml
    /// </summary>
    public partial class Page_Home : Page
    {
        Users user;
        public Page_Home(Users user)
        {
            InitializeComponent();
            this.user = user;
            tbUserName.Text = tbUserName.Text + user.LastName + " " + user.FirstName + " " + user.MiddleName;
            tbUserRole.Text = tbUserRole.Text + user.Roles.Kind;
            tbUserPost.Text = tbUserPost.Text + user.Positions.Kind;
            tbUserScore.Text = tbUserScore.Text + user.Score;
        }

        private void btnDailytasks_Click(object sender, RoutedEventArgs e) // Переход на ежедневные задачи
        {
            ClassFrame.MainF.Navigate(new Page_Dailytasks());
        }

        private void btnAchievement_Click(object sender, RoutedEventArgs e) // Переход на достижения
        {
            ClassFrame.MainF.Navigate(new Page_Achievement());
        }
    }
}
