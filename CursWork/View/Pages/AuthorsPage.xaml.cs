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
    /// Логика взаимодействия для AuthorsPage.xaml
    /// </summary>
    public partial class AuthorsPage : Page
    {
        public AuthorsPage()
        {
            InitializeComponent();
            
            AuthorsLb.ItemsSource = App.context.User.Where(u=>u.role_id==2).ToList();
        }

        private void AuthorsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User author = AuthorsLb.SelectedItem as User;

            if (author != null)
            {
                
                App.selectedAuthor = author;

                if (App.selectedAuthor==App.enteredUser)
                {
                    NavigationService.Navigate(new AuthorsProfilePage());
                    BasicWindow basicWindow = new BasicWindow();
                    basicWindow.PageTextTbl.Text = "Профиль";
                }
                else
                {
                    NavigationService.Navigate(new SelectedAuthorPage());
                }
                    
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTb.Text != string.Empty)
            {
                AuthorsLb.ItemsSource = App.context.User.Where(u => u.role_id == 2).ToList().Where(x => x.nickname.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            }
            else
            {
                AuthorsLb.ItemsSource = App.context.User.Where(u => u.role_id == 2).ToList().ToList();
            }
        }
    }
}
