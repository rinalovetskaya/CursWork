using CursWork.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {


        public MainPage()
        {
            InitializeComponent();

            RefLb.ItemsSource = App.context.Reference.ToList();
        }


        private void MainLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reference reference = RefLb.SelectedItem as Reference;

            if (reference != null)
            {
                App.selectedRef = reference;
                NavigationService.Navigate(new SelectedRefPage());
            }
        }

        private void RefLb_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
