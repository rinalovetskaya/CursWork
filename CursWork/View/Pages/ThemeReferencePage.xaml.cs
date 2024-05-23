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
    /// Логика взаимодействия для ThemeReferencePage.xaml
    /// </summary>
    public partial class ThemeReferencePage : Page
    {
        public ThemeReferencePage(Tag tag)
        {
            InitializeComponent();

            RefLb.DataContext = App.selectedTag;
            RefLb.ItemsSource = App.context.Reference.ToList();
        }

        private void RefLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
