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
    /// Логика взаимодействия для PackAuthorProfilePage.xaml
    /// </summary>
    public partial class PackAuthorProfilePage : Page
    {
        public PackAuthorProfilePage()
        {
            InitializeComponent();
            PackLb.ItemsSource = App.context.Pack.Where(u => u.user_id == App.enteredUser.id).ToList();
        }


        private void PackLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pack = PackLb.SelectedItem as Pack;

            if (pack != null)
            {
                App.selectedPack = pack;
                var selectedPackPage = new SelectedPackPage();
                var mainWindow = Window.GetWindow(this) as BasicWindow;
                mainWindow.BasicFrm.Content = selectedPackPage;
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var pack = PackLb.SelectedItem as Pack;

            if (pack != null)
            {
                App.selectedPack = pack;
                var EditPack = new EditPackPage();
                var mainWindow = Window.GetWindow(this) as BasicWindow;
                mainWindow.BasicFrm.Content = EditPack;
            }
        }
    }
}
