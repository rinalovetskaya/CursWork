using Diplom.View.Pages;
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
using System.Windows.Shapes;

namespace Diplom.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для BasicWindow.xaml
    /// </summary>
    public partial class BasicWindow : Window
    {
        public BasicWindow()
        {
            InitializeComponent();
            MainFrm.NavigationService.Navigate(new ViewPage());
        }

        private void NewPartBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.NavigationService.Navigate(new NewPartPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthRegWindow authRegWindow = new AuthRegWindow();
            authRegWindow.Show();
            this.Close();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.NavigationService.Navigate(new SearchPage());
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.NavigationService.Navigate(new ViewPage());
        }
    }
}
