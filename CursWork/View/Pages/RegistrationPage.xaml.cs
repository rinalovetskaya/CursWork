using CursWork.Model;
using CursWork.View.Windows;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            StatusCmb.SelectedValue = "id";
            StatusCmb.DisplayMemberPath = "name";
            StatusCmb.ItemsSource = App.context.Role.ToList();
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

        private void RegBtn_Click(object sender, RoutedEventArgs e)
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
            if (string.IsNullOrWhiteSpace(StatusCmb.Text))
            {
                txt += "Выберите статус\n";
            }
            if (string.IsNullOrWhiteSpace(PasswordPb.Password))
            {
                txt += "Введите пароль\n";
            }
            if (string.IsNullOrWhiteSpace(SPasswordPb.Password))
            {
                txt += "Повторите пароль\n";
            }

            if (txt!="")
            {
                MessageBox.Show(txt);
                txt = "";
                return;
            }

            if (PasswordPb.Password!=SPasswordPb.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            User user = new User()
            {
                photo = getJPGFromImageControl(imageControl.Source as BitmapImage),
                nickname = NickTb.Text,
                email = EmailTb.Text,
                phone = PhoneTb.Text,
                status = StatusCmb.Text,
                password = PasswordPb.Password
            };

            App.context.User.Add(user);
            App.context.SaveChanges();

            if (user != null)
            {
                App.enteredUser = user;
                BasicWindow basicWindow = new BasicWindow();
                basicWindow.Show();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is StartWindow)
                    {
                        window.Close();
                        break;
                    }
                }
            }

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string navigateUri = e.Uri.OriginalString;
            Uri uri = new Uri(navigateUri, UriKind.Relative);
            NavigationService?.Navigate(uri);
        }
    }
}
