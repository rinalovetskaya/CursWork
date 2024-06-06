using Diplom.Model;
using Microsoft.Win32;
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
    /// Логика взаимодействия для NewPartPage.xaml
    /// </summary>
    public partial class NewPartPage : Page
    {
        public NewPartPage()
        {
            InitializeComponent();
            RankCmb.SelectedValuePath = "id";
            RankCmb.DisplayMemberPath = "name";
            RankCmb.ItemsSource = App.context.MilitaryRank.ToList();

            GenderCmb.SelectedValuePath = "id";
            GenderCmb.DisplayMemberPath = "name";
            GenderCmb.ItemsSource = App.context.Gender.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(selectedFileName));
                imageControl.Source = bitmap;
                PhotoTbl.Visibility = Visibility.Hidden;
            }
        }

        private void SurnameTb_GotFocus(object sender, RoutedEventArgs e)
        {
            SurnameTb.Text = "";
        }

        private void SurnameTb_LostFocus(object sender, RoutedEventArgs e)
        {
            SurnameTb.Text = "Фамилия";
        }

        private void NameTb_GotFocus(object sender, RoutedEventArgs e)
        {
            NameTb.Text = "";
        }

        private void NameTb_LostFocus(object sender, RoutedEventArgs e)
        {
            NameTb.Text = "Имя";
        }

        private void PatrTb_GotFocus(object sender, RoutedEventArgs e)
        {
            PatrTb.Text = "";
        }

        private void PatrTb_LostFocus(object sender, RoutedEventArgs e)
        {
            PatrTb.Text = "Отчество";
        }

        private void DescTb_GotFocus(object sender, RoutedEventArgs e)
        {
            DescTb.Text = "";
        }

        private void DescTb_LostFocus(object sender, RoutedEventArgs e)
        {
            PatrTb.Text = "Описание";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string txt = "";

            if (string.IsNullOrWhiteSpace(SurnameTb.Text))
            {
                txt += "Введите фамилию\n";
            }
            if (string.IsNullOrWhiteSpace(NameTb.Text))
            {
                txt += "Введите имя\n";
            }
            if (string.IsNullOrWhiteSpace(GenderCmb.Text))
            {
                txt += "Выберите пол\n";
            }
            if (string.IsNullOrWhiteSpace(RankCmb.Text))
            {
                txt += "Выберите звание\n";
            }

            if (txt != "")
            {
                MessageBox.Show(txt);
                txt = "";
                return;
            }

            if (PatrTb.Text == "Отчество")
            {
                PatrTb.Text = "";
            }
            if (imageControl.Source != null)
            {
                Participant participant = new Participant()
                {
                    surname = SurnameTb.Text,
                    name = NameTb.Text,
                    patronymic = PatrTb.Text,
                    gender_id = GenderCmb.SelectedIndex + 1,
                    military_rank_id = RankCmb.SelectedIndex + 1,
                    photo = ((BitmapImage)imageControl.Source).UriSource.LocalPath,
                    add_date = DateTime.Now,
                    description = DescTb.Text,
                    author_id = App.enteredUser.id
                };

                App.context.Participant.Add(participant);
                App.context.SaveChanges();
                NavigationService.GoBack();

            }
        }
    }
}
