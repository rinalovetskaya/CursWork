using CursWork.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EditAuthorProfilePage.xaml
    /// </summary>
    public partial class EditAuthorProfilePage : Page
    {
        public EditAuthorProfilePage()
        {
            InitializeComponent();
            imageControl.DataContext = App.enteredUser;
            NickTb.DataContext = App.enteredUser;
            EmailTb.DataContext = App.enteredUser;
            PhoneTb.DataContext = App.enteredUser;
            PasswordPb.DataContext = App.enteredUser;
            SPasswordPb.DataContext = App.enteredUser;

            StatusCmb.SelectedValue = "id";
            StatusCmb.DisplayMemberPath = "name";
            StatusCmb.ItemsSource = App.context.Role.ToList();
            StatusCmb.IsEnabled = false;
        }
        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
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
                AvaTbl.Visibility = Visibility.Hidden;
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            string txt = "";

            if (string.IsNullOrWhiteSpace(NickTb.Text))
            {
                txt += "Введите никнейм\n";
            }
            if (string.IsNullOrWhiteSpace(EmailTb.Text))
            {
                txt += "Введите Email\n";
            }
            if (string.IsNullOrWhiteSpace(PhoneTb.Text))
            {
                txt += "Введите номер телефона\n";
            }
            if (string.IsNullOrWhiteSpace(PasswordPb.Password))
            {
                txt += "Введите пароль\n";
            }
            if (string.IsNullOrWhiteSpace(SPasswordPb.Password))
            {
                txt += "Повторите пароль\n";
            }

            if (txt != "")
            {
                MessageBox.Show(txt);
                txt = "";
                return;
            }

            if (PasswordPb.Password != SPasswordPb.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            User user = App.context.User.FirstOrDefault(u => u.id == App.enteredUser.id);

            if (user != null)
            {
                user.photo = getJPGFromImageControl(imageControl.Source as BitmapImage);
                user.nickname = NickTb.Text;
                user.email = EmailTb.Text;
                user.phone = PhoneTb.Text;
                user.password = PasswordPb.Password;

                App.context.SaveChanges();
            }



        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
