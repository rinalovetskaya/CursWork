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
    /// Логика взаимодействия для SelectedRefPage.xaml
    /// </summary>
    public partial class SelectedRefPage : Page
    {
        public SelectedRefPage()
        {
            InitializeComponent();

            SelectedRefImg.DataContext = App.selectedRef;
            AuthorTbl.DataContext = App.selectedRef;
            NameTbl.DataContext = App.selectedRef;
            DescTbl.DataContext = App.selectedRef;
            DateTbl.DataContext = App.selectedRef;
        }

        private void BlockMethod()
        {
            if (SaveRefBtn != null)
            {
                SaveRefBtn.IsEnabled = false;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }



        private void SaveRefBtn_Click(object sender, RoutedEventArgs e)
        {
            SavedRef savedRef = new SavedRef()
            {
                user_id = App.enteredUser.id,
                ref_id = App.selectedRef.id
            };

            App.context.SavedRef.Add(savedRef);
            App.context.SaveChanges();

            BlockMethod();
        }
    }
}
