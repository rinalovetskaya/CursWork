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
    /// Логика взаимодействия для SelectedPackOnAuthorPage.xaml
    /// </summary>
    public partial class SelectedPackOnAuthorPage : Page
    {
        public SelectedPackOnAuthorPage()
        {
            InitializeComponent();

            NicknameTb.DataContext = App.selectedAuthor;
            NameTb.DataContext = App.selectedAuthor;
            
            //RefLb.ItemsSource=App.context.Reference.Where(x=>x.id==App.selectedPackRef.ref_id).Where(App.selectedPackRef.pack_id == App.selectedPack.id).ToList();


        }

        private void RefLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
