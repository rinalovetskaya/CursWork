using Diplom.Model;
using Diplom.View.Windows;
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

namespace Diplom.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = App.context.User.FirstOrDefault(u => u.login == LoginTb.Text && u.password == PasswordPb.Password);

            if (user != null)
            {
                App.enteredUser = user;
                BasicWindow basicWindow = new BasicWindow();
                basicWindow.Show();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is AuthRegWindow)
                    {
                        window.Close();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
                return;
            }
        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWindow = new GuestWindow();
            guestWindow.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window is AuthRegWindow)
                {
                    window.Close();
                    break;
                }
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
