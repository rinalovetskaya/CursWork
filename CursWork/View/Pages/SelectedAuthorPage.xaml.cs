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
    /// Логика взаимодействия для SelectedAuthorPage.xaml
    /// </summary>
    public partial class SelectedAuthorPage : Page
    {
        
        public SelectedAuthorPage()
        {
            InitializeComponent();
            NickTbl.DataContext = App.selectedAuthor;
            UserImg.DataContext = App.selectedAuthor;
            StatTbl.DataContext = App.selectedAuthor;

            bool IfTrue = App.context.Subscriber.Any(x => x.user_id == App.enteredUser.id && x.author_id == App.selectedAuthor.id);
            if (IfTrue == true)
            {
                UnSubBtn.Visibility = Visibility.Visible;
            }


            MainFrm.NavigationService.Navigate(new AuthorsRefPage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AuthorRefBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.NavigationService.Navigate(new AuthorsRefPage());
        }

        private void AuthorPackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.NavigationService.Navigate(new AuthorsPackPage());
        }

        private void FavourBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.NavigationService.Navigate(new FavourAuthorPage());
        }

        private void SubBtn_Click(object sender, RoutedEventArgs e)
        {

            Subscriber subscriber = new Subscriber()
            {
                user_id = App.enteredUser.id,
                author_id = App.selectedAuthor.id
            };
            App.context.Subscriber.Add(subscriber);
            App.context.SaveChanges();

            UnSubBtn.Visibility = Visibility.Visible;

        }

        private void UnSubBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UnSubBtn.Visibility == Visibility.Visible) 
            {
                var sub = App.context.Subscriber.FirstOrDefault(x=>x.user_id==App.enteredUser.id && x.author_id == App.selectedAuthor.id);
                App.context.Subscriber.Remove(sub);
                App.context.SaveChanges();
                UnSubBtn.Visibility = Visibility.Hidden;
            }
        }
    }
}
