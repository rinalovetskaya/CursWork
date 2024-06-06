using CursWork.Model;
using CursWork.View.Windows;
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
    /// Логика взаимодействия для SubProfilePage.xaml
    /// </summary>
    public partial class SubProfilePage : Page
    {
        public SubProfilePage()
        {
            InitializeComponent();

            AuthorsLb.ItemsSource = App.context.User.Where(u => App.context.Subscriber.Any(s => s.author_id == u.id)).ToList();
        }

        private void AuthorsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User author = AuthorsLb.SelectedItem as User;

            if (author != null)
            {
                App.selectedAuthor = author;
                NavigationService.Navigate(new SelectedAuthorPage());
            }
        }
    }
}
