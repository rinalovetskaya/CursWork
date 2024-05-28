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
    /// Логика взаимодействия для AuthorsProfilePage.xaml
    /// </summary>
    public partial class AuthorsProfilePage : Page
    {
        public AuthorsProfilePage()
        {
            InitializeComponent();
            NickTbl.DataContext = App.enteredUser;
            UserImg.DataContext = App.enteredUser;
            StatTbl.DataContext = App.enteredUser;
            MainFrm.Navigate(new RefAuthorProfilePage());
        }

        private void SunBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new SubAuthorPage());
        }

        private void SavedPackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new SavedPackAuthorPage());
        }

        private void EditProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new EditAuthorProfilePage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window is BasicWindow)
                {
                    window.Close();
                    break;
                }
            }
        }

        private void AuthorRefBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new RefAuthorProfilePage());
        }

        private void AuthorPackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new PackAuthorProfilePage());
        }

        private void FavourBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new FavAuthorProfilePage());
        }

        private void NewPackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new NewPackPage());
        }

        private void NewRefBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new NewRefPage());
        }
    }
}
