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

namespace Diplom.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectedPartPage.xaml
    /// </summary>
    public partial class SelectedPartPage : Page
    {
        public SelectedPartPage()
        {
            InitializeComponent();
            PhotoImg.DataContext = App.selectedParticipant;
            NameTbl.DataContext = App.selectedParticipant;
            RankTbl.DataContext = App.selectedParticipant;
            DescTbl.DataContext = App.selectedParticipant;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
