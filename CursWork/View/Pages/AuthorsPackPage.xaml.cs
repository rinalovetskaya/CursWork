using CursWork.Model;
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
    /// Логика взаимодействия для AuthorsPackPage.xaml
    /// </summary>
    public partial class AuthorsPackPage : Page
    {

        public AuthorsPackPage()
        {
            InitializeComponent();

            PackLb.ItemsSource = App.context.Pack.Where(u=>u.user_id==App.selectedAuthor.id).ToList();

        }

        private void PackLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pack pack = PackLb.SelectedItem as Pack;

            if (pack != null)
            {
                App.selectedPack = pack;
                NavigationService.Navigate(new SelectedPackOnAuthorPage());
            }
        }


        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }



        private void SavePackBtn_Click(object sender, RoutedEventArgs e)
        {

            SavedPack savedPack = new SavedPack()
            {
                user_id = App.enteredUser.id,
                pack_id = App.selectedPack.id
            };

            App.context.SavedPack.Add(savedPack);
            App.context.SaveChanges();

        }
    }
}
