using CursWork.Model;
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

namespace CursWork.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();

            ThemeLb.ItemsSource = App.context.Tag.ToList();
        }

        private void ThemeLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Tag tag = ThemeLb.SelectedItem as Tag;

            if (tag != null)
            {
                App.selectedTag = tag;
                NavigationService.Navigate(new ThemeReferencePage());
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTb.Text != string.Empty)
            {
                ThemeLb.ItemsSource = App.context.Tag.Where(x => x.name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            }
            else
            {
                ThemeLb.ItemsSource = App.context.Tag.ToList();
            }
            
        }
    }
}
