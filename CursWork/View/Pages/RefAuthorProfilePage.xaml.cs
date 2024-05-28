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
    /// Логика взаимодействия для RefAuthorProfilePage.xaml
    /// </summary>
    public partial class RefAuthorProfilePage : Page
    {
        public RefAuthorProfilePage()
        {
            InitializeComponent();
            RefLb.ItemsSource = App.context.Reference.Where(s => s.author_id == App.enteredUser.id).ToList();
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
