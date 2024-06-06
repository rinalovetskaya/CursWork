using Diplom.Model;
using Diplom.View.Windows;
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
    /// Логика взаимодействия для ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Page
    {
        public ViewPage()
        {
            InitializeComponent();

            PartLb.ItemsSource = App.context.Participant.ToList();
        }

        private void PartLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Participant part = PartLb.SelectedItem as Participant;


            if (App.enteredUser.role_id==1)
            {
                if (part != null)
                {
                    App.selectedParticipant = part;
                    NavigationService.Navigate(new SelectedPartByAdmPage());
                }
            }

            else
            {
                if (part != null)
                {
                    App.selectedParticipant = part;
                    NavigationService.Navigate(new SelectedPartPage());
                }
            }
            
        }
    }
}
