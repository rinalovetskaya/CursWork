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
    /// Логика взаимодействия для ThemeReferencePage.xaml
    /// </summary>
    public partial class ThemeReferencePage : Page
    {
        public ThemeReferencePage()
        {
            InitializeComponent();

            RefLb.DataContext = App.selectedTag;
            RefLb.ItemsSource = App.context.Reference.Where(s=>s.tag_id == App.selectedTag.id).ToList();
        }

        private void RefLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reference reference = RefLb.SelectedItem as Reference;

            if (reference != null)
            {
                App.selectedRef = reference;
                NavigationService.Navigate(new SelectedRefPage());
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTb.Text != string.Empty)
            {
                RefLb.ItemsSource = App.context.Reference.Where(s => s.tag_id == App.selectedTag.id).Where(x => x.name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            }
            else
            {
                RefLb.ItemsSource = App.context.Reference.Where(s => s.tag_id == App.selectedTag.id).ToList();
            }
        }
    }
}
