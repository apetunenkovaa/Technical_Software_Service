using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Users user;
        public MainWindow()
        {
            InitializeComponent();
            DataBase.Base = new HelpdeskEntities();
            ClassFrame.MainF = Mframe;
            ClassFrame.MainF.Navigate(new Page_Authorization());                       
        }
            //tbUserName.Text = tbUserName.Text + user.LastName + " " + user.FirstName + " " + user.MiddleName;
            //tbUserRole.Text = tbUserRole.Text + user.Roles.Kind;
            //tbUserPost.Text = tbUserPost.Text + user.Positions.Kind;
            //tbUserScore.Text = tbUserScore.Text + user.Score;
    }
}
