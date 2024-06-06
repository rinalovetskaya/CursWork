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
    /// Логика взаимодействия для GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        public GuestWindow()
        {
            InitializeComponent();
            MainFrm.NavigationService.Navigate(new ViewPage());
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {

            MainFrm.NavigationService.Navigate(new ViewPage());
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

            MainFrm.NavigationService.Navigate(new SearchPage());
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthRegWindow authRegWindow = new AuthRegWindow();
            authRegWindow.Show();
            this.Close();
        }
    }
}
