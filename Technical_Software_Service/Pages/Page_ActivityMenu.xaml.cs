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
    /// Логика взаимодействия для Page_Anything.xaml
    /// </summary>
    public partial class Page_Anything : Page
    {
        Users user;
        public Page_Anything(Users user)
        {
            InitializeComponent();
            this.user = user;
            ListFild();
            Filter();
            ListAnything.ItemsSource = DataBase.Base.Tickets.ToList();
            ListHistory.ItemsSource = DataBase.Base.HistoryEntries.ToList();
            dgUsers.ItemsSource = DataBase.Base.Users.ToList();

            tbUserName.Text = tbUserName.Text + user.LastName + " " + user.FirstName + " " + user.MiddleName;
            tbUserRole.Text = tbUserRole.Text + user.Roles.Kind;
            tbUserPost.Text = tbUserPost.Text + user.Positions.Kind;
            tbUserScore.Text = tbUserScore.Text + user.Score;

            if(user.Roles.Kind == "Администратор")
            {
                tcUsers.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Заполнение ComboBox
        /// </summary>
        public void ListFild()
        {
            // Заполнение ComboBox с фильтрацией для заявок
            List<Tickets> ticket = DataBase.Base.Tickets.ToList();
            cbFilter.Items.Add("Все");
            foreach (Tickets tick in ticket)
            {
                //cbFilter.Items.Add(tick. );
            }
            cbFilter.SelectedIndex = 0;

            // Заполнение ComboBox с фильтрацией для истории заявок
            List<HistoryEntries> history = DataBase.Base.HistoryEntries.ToList();
            cboxFilter.Items.Add("Все");
            foreach (Tickets tick in ticket)
            {
                //cbFilter.Items.Add(tick. );
            }
            cboxFilter.SelectedIndex = 0;
        }

        /// <summary>
        ///  Поиск и фильтрация страниц Заявки и История заявок
        /// </summary>
        public void Filter()
        {
            List<Tickets> listFilter = DataBase.Base.Tickets.ToList();
            // Поиск
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                listFilter = listFilter.Where(x => x.Title.ToLower().Contains(tbSearch.Text.ToLower())).ToList(); // Поиск по наименованию
            }

            List<HistoryEntries> listFilterhistory = DataBase.Base.HistoryEntries.ToList(); 
            // Поиск
            if (!string.IsNullOrWhiteSpace(tboxSearch.Text))
            {
                listFilterhistory = listFilterhistory.Where(x => x.Tickets.Title.ToLower().Contains(tboxSearch.Text.ToLower())).ToList(); // Поиск по наименованию заявки
            }
            else if (!string.IsNullOrWhiteSpace(tboxSearch.Text))
            {
                listFilterhistory = listFilterhistory.Where(x => x.Users.LastName.ToLower().Contains(tboxSearch.Text.ToLower())).ToList(); // Поиск по фамилии пользователя
            }

            List<Users> listFilterUsers = DataBase.Base.Users.ToList();
            // Поиск
            if (!string.IsNullOrWhiteSpace(tbSearchUsers.Text))
            {
                listFilterUsers = listFilterUsers.Where(x => x.LastName.ToLower().Contains(tbSearchUsers.Text.ToLower())).ToList(); // Поиск по фамилии
            }
            else if (!string.IsNullOrWhiteSpace(tbSearchUsers.Text))
            {
                listFilterUsers = listFilterUsers.Where(x => x.FirstName.ToLower().Contains(tbSearchUsers.Text.ToLower())).ToList(); // Поиск по имени
            }

            // Присвоение 
            //ListAnything.ItemsSource = listFilter;
            //if (listFilter.Count == 0)
            //{
            //    MessageBox.Show("Нет записей");
            //}
            //ListHistory.ItemsSource = listFilterhistory;
            //if (listFilterhistory.Count == 0)
            //{
            //    MessageBox.Show("Нет записей");
            //}
            //dgUsers.ItemsSource = listFilterUsers;
            //if (listFilterUsers.Count == 0)
            //{
            //    MessageBox.Show("Нет записей");
            //}
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
        private void tboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void cboxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
        private void tbSearchUsers_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void btnAddTickets_Click(object sender, RoutedEventArgs e) // Добавление заявки
        {

        }
        private void btnDailytasks_Click(object sender, RoutedEventArgs e) // Переход к ежедневным задачам
        {

        }
        private void bntExit_Click(object sender, RoutedEventArgs e) //  Выход из учетной записи
        {
            ClassFrame.MainF.Navigate(new Page_Authorization());
        }
        private void btnAchievement_Click(object sender, RoutedEventArgs e) // Переход к достижениям
        {
            ClassFrame.MainF.Navigate(new Pages.Page_Achievment());
        }
        private void btnAddUser_Click(object sender, RoutedEventArgs e) // Добавление пользователя
        {
            Window_AddUsers users = new Window_AddUsers();
            users.ShowDialog();
        }
    }
}

