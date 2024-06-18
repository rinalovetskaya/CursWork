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
    /// Логика взаимодействия для SubAuthorPage.xaml
    /// </summary>
    public partial class SubAuthorPage : Page
    {
        public SubAuthorPage()
        {
            InitializeComponent();

            AuthorsLb.ItemsSource = App.context.User.Where(u => App.context.Subscriber.Any(s => s.author_id == u.id && s.user_id == App.enteredUser.id)).ToList();
        }

        private void AuthorsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Author = AuthorsLb.SelectedItem as User;

            if (Author != null)
            {
                App.selectedAuthor = Author;
                var selectedAuthorPage = new SelectedAuthorPage();
                var mainWindow = Window.GetWindow(this) as BasicWindow;
                mainWindow.BasicFrm.Content = selectedAuthorPage;
            }
        }
    }
}
