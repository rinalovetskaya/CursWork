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
    /// Логика взаимодействия для SelectedPackPage.xaml
    /// </summary>
    public partial class SelectedPackPage : Page
    {
        public SelectedPackPage()
        {
            InitializeComponent(); 
            NicknameTb.DataContext = App.selectedPack;
            NameTb.DataContext = App.selectedPack;

            RefLb.ItemsSource = App.context.PackRef.Join(App.context.Reference, pr => pr.ref_id, r => r.id, (pr, r) => new { PackRef = pr, Reference = r }).Where(joined => joined.PackRef.pack_id == App.selectedPack.id).ToList();
        }

        private void RefLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reference reference = RefLb.SelectedItem as Reference;

            if (reference != null)
            {
                App.selectedRef = reference;
                NavigationService.Navigate(new SelectedRefOnAuthorPage());
            }
        }
    }
}
