using Diplom.Model;
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
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            PartLb.ItemsSource = App.context.Participant.ToList();

            var rank = App.context.MilitaryRank.ToList();

            rank.Insert(0, new MilitaryRank { name = "Все звания" });

            RankCmb.SelectedValuePath = "id";
            RankCmb.DisplayMemberPath = "name";
            RankCmb.ItemsSource = rank;


        }

        private void PartLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Participant part = PartLb.SelectedItem as Participant;


            if (App.enteredUser.role_id == 1)
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

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTb.Text != string.Empty)
            {
                PartLb.ItemsSource = App.context.Participant.Where(x => x.name.ToLower().Contains(SearchTb.Text.ToLower()) || x.surname.ToLower().Contains(SearchTb.Text.ToLower()) || x.patronymic.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            }
            else
            {
                PartLb.ItemsSource = App.context.Participant.ToList();
            }
        }

        private void RankCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(RankCmb.SelectedIndex != 0)
            {
                PartLb.ItemsSource=App.context.Participant.Where(x=>x.MilitaryRank.id == RankCmb.SelectedIndex).ToList();
            }
            else
            {
                PartLb.ItemsSource = App.context.Participant.ToList();
            }
        }
    }
}
