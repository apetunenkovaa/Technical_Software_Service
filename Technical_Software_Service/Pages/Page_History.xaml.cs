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
    /// Логика взаимодействия для Page_History.xaml
    /// </summary>
    public partial class Page_History : Page
    {
        List<HistoryEntries> listFilter;
        public Page_History()
        {
            InitializeComponent();
            ListHistory.ItemsSource = DataBase.Base.HistoryEntries.ToList();
            cbFilter.SelectedIndex = 0;
            Filter();
        }
        /// <summary>
        /// поиск, фильтрация
        /// </summary>
        public void Filter()
        {
            listFilter = DataBase.Base.HistoryEntries.ToList();
            // Поиск
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                //listFilter = listFilter.Where(x => x.Title.ToLower().Contains(tbSearch.Text.ToLower())).ToList(); //поиск по наименованию
            }

            // Фильтрация
            switch (cbFilter.SelectedIndex)
            {

            }

            ListHistory.ItemsSource = listFilter;
            if (listFilter.Count == 0)
            {
                MessageBox.Show("Нет записей");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //ClassFrame.MainF.Navigate(new );
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
