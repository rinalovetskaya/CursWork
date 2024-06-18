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
    /// Логика взаимодействия для NewRefPage.xaml
    /// </summary>
    public partial class NewRefPage : Page
    {
        

        public NewRefPage()
        {
            InitializeComponent();


            var tags = App.context.Tag.ToList();

            tags.Insert(0, new Tag { name = "Не имеется" });
            TagCmb.SelectedValuePath = "id";
            TagCmb.DisplayMemberPath = "name";
            TagCmb.ItemsSource = tags;
            
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

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string img = "";

            if (imageControl.Source == null)
            {
                img += "Выберите изображение\n";
            }
            if (img != "")
            {
                MessageBox.Show(img);
                img = "";
                return;
            }

            Reference reference = new Reference()
            {
                 name = NameTb.Text,
                 description = DescTb.Text,
                 photo = ((BitmapImage)imageControl.Source).UriSource.LocalPath,
                 author_id = App.enteredUser.id,
                 ref_date = DateTime.Now,
                 tag_id = null
            };

            App.context.Reference.Add(reference);
            App.context.SaveChanges();
            NavigationService.GoBack();
                

            



        }
    }
    
}
