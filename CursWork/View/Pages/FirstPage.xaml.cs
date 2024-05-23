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
using System.Windows.Threading;

namespace CursWork.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {

        private DispatcherTimer timer;
        public FirstPage()
        {
            InitializeComponent();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            WelcomeTbl.Visibility = Visibility.Visible;
            SecTbl.Visibility = Visibility.Visible;
            timer.Stop();
        }
        private void WelcomeTbl_Initialized(object sender, EventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Start();
        }

        private void MainGd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WelcomeTbl.Visibility == Visibility.Visible)
            {
                NavigationService.Navigate(new View.Pages.StartPage());
            }
        }
    }
}
