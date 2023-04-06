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
        List<Tickets> listFilter;
        Users user;
        public Page_Anything(Users user)
        {
            InitializeComponent();

            ListAnything.ItemsSource = DataBase.Base.Tickets.ToList();
            List<Tickets> ticket = DataBase.Base.Tickets.ToList();
            cbFilter.Items.Add("Все");
            foreach (Tickets tick in ticket)
            {
                //cbFilter.Items.Add(tick. );
            }
            cbFilter.SelectedIndex = 0;
            Filter();
            this.user = user;
            tbFIOUser.Text = user.LastName + " " + user.FirstName[0] + "." + user.MiddleName[0] + ".";
        }

        /// <summary>
        /// поиск, фильтрация
        /// </summary>
        public void Filter()
        {
            //listFilter = DataBase.Base.Tickets.ToList();
            //// Поиск
            //if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            //{
            //    listFilter = listFilter.Where(x => x.Title.ToLower().Contains(tbSearch.Text.ToLower())).ToList(); //поиск по наименованию
            //}

            //// Фильтрация
            //switch (cbFilter.SelectedIndex)
            //{

            //}

            //ListAnything.ItemsSource = listFilter;
            //if (listFilter.Count == 0)
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.MainF.Navigate(new Page_Authorization());
        }

        private void tbFIOUser_MouseDown(object sender, MouseButtonEventArgs e) // Переход в личный кабинет
        {
            ClassFrame.MainF.Navigate(new Page_Home(user));
        }
    }
}

