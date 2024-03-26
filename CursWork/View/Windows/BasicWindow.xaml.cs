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

namespace CursWork.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для BasicWindow.xaml
    /// </summary>
    public partial class BasicWindow : Window
    {
        public BasicWindow()
        {
            InitializeComponent();
            BasicFrm.Navigate(new View.Pages.MainPage());
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            BasicFrm.Navigate(new View.Pages.MainPage());
            PageTextTbl.Text = "Главная";
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            BasicFrm.Navigate(new View.Pages.SearchPage());
            PageTextTbl.Text = "Поиск";
        }

        private void AuthorsBtn_Click(object sender, RoutedEventArgs e)
        {
            BasicFrm.Navigate(new View.Pages.AuthorsPage());
            PageTextTbl.Text = "Авторы";
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            BasicFrm.Navigate(new View.Pages.ProfilePage());
            PageTextTbl.Text = "Профиль";
        }

    }
}
