using CursWork.Model;
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

namespace CursWork.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewPackPage.xaml
    /// </summary>
    public partial class NewPackPage : Page
    {
        public NewPackPage()
        {
            InitializeComponent();
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

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string txt = "";

            if (imageControl.Source == null)
            {
                txt += "Выберите изображение\n";
            }
            if (string.IsNullOrWhiteSpace(NameTb.Text))
            {
                txt += "Введите название\n";
            }
            if (txt != "")
            {
                MessageBox.Show(txt);
                txt = "";
                return;
            }

            Pack pack = new Pack()
            {
                name = NameTb.Text,
                photo = ((BitmapImage)imageControl.Source).UriSource.LocalPath,
                user_id = App.enteredUser.id
            };

            App.context.Pack.Add(pack);
            App.context.SaveChanges();

            NavigationService.Navigate(new EditPackPage());

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
