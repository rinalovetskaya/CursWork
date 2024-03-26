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
    /// Логика взаимодействия для AuthorsPage.xaml
    /// </summary>
    public partial class AuthorsPage : Page
    {
        public AuthorsPage()
        {
            InitializeComponent();
            
            AuthorsLb.ItemsSource = App.context.User.Where(u=>u.role_id==2).ToList();
        }

        private void AuthorsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
