﻿using CursWork.Model;
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
using static CursWork.View.Windows.StartWindow;

namespace CursWork.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = App.context.User.FirstOrDefault(u => u.email == LoginTb.Text && u.password == PassPb.Password);

            if (user != null)
            {
                App.enteredUser = user;
                BasicWindow basicWindow = new BasicWindow();
                basicWindow.Show();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is StartWindow)
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

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string navigateUri = e.Uri.OriginalString;
            Uri uri = new Uri(navigateUri, UriKind.Relative);
            NavigationService?.Navigate(uri);
        }

    }
}
