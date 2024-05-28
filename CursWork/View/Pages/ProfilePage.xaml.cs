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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            NickTbl.DataContext = App.enteredUser;
            UserImg.DataContext = App.enteredUser;
            StatTbl.DataContext = App.enteredUser;
            MainFrm.Navigate(new SubProfilePage());
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

        private void SavedPackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new SavedPackProfilePage());
        }

        private void FavBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new FavProfilePage());
        }

        private void SunBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new SubProfilePage());
        }

        private void EditProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new EditProfilePage());
        }
    }
}
