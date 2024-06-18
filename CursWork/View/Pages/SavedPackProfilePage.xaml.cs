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
    /// Логика взаимодействия для SavedPackProfilePage.xaml
    /// </summary>
    public partial class SavedPackProfilePage : Page
    {
        public SavedPackProfilePage()
        {
            InitializeComponent();

            PackLb.ItemsSource = App.context.Pack.Where(u => App.context.SavedPack.Any(s => s.pack_id == u.id && s.user_id == App.enteredUser.id)).ToList();
        }

        private void DelPackBtn_Click(object sender, RoutedEventArgs e)
        {
            var Sp = App.context.SavedPack.FirstOrDefault(x => x.user_id == App.enteredUser.id && x.pack_id == App.selectedPack.id);
            App.context.SavedPack.Remove(Sp);
            App.context.SaveChanges();

            PackLb.ItemsSource = App.context.Pack.Where(u => App.context.SavedPack.Any(s => s.pack_id == u.id && s.user_id == App.enteredUser.id)).ToList();
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
    }
}
