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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            GenderCmb.SelectedValuePath = "id";
            GenderCmb.DisplayMemberPath = "name";
            GenderCmb.ItemsSource = App.context.Gender.ToList();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string txt = "";

            if (string.IsNullOrWhiteSpace(SurTb.Text))
            {
                txt += "Введите фамилию\n";
            }
            if (string.IsNullOrWhiteSpace(NameTb.Text))
            {
                txt += "Введите имя\n";
            }
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                txt += "Введите логин\n";
            }
            if (string.IsNullOrWhiteSpace(PhoneTb.Text))
            {
                txt += "Введите номер телефона\n";
            }
            if (string.IsNullOrWhiteSpace(PasswordPb.Password))
            {
                txt += "Введите пароль\n";
            }
            if (string.IsNullOrWhiteSpace(SecondPassPb.Password))
            {
                txt += "Повторите пароль\n";
            }

            if (txt != "")
            {
                MessageBox.Show(txt);
                txt = "";
                return;
            }

            if (PasswordPb.Password != SecondPassPb.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            if (PatrTb.Text=="Отчество")
            {
                PatrTb.Text = "";
            }
            User user = new User()
            {
                name = NameTb.Text,
                surname = SurTb.Text,
                patronymic = PatrTb.Text,
                login = LoginTb.Text,
                password = PasswordPb.Password,
                phone = PhoneTb.Text,
                gender_id = GenderCmb.SelectedIndex + 1,
                role_id = 2
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
                    if (window is AuthRegWindow)
                    {
                        window.Close();
                        break;
                    }
                }
            }
        }

        private void SurTb_GotFocus(object sender, RoutedEventArgs e)
        {
            SurTb.Text = "";
        }

        private void NameTb_GotFocus(object sender, RoutedEventArgs e)
        {
            NameTb.Text = "";
        }

        private void PatrTb_GotFocus(object sender, RoutedEventArgs e)
        {
            PatrTb.Text = "";
        }

        private void LoginTb_GotFocus(object sender, RoutedEventArgs e)
        {
            LoginTb.Text = "";
        }

        private void PhoneTb_GotFocus(object sender, RoutedEventArgs e)
        {
            PhoneTb.Text = "";
        }


        private void SurTb_LostFocus(object sender, RoutedEventArgs e)
        {
            SurTb.Text = "Фамилия";
        }

        private void NameTb_LostFocus(object sender, RoutedEventArgs e)
        {
            NameTb.Text = "Имя";
        }

        private void PatrTb_LostFocus(object sender, RoutedEventArgs e)
        {
            PatrTb.Text = "Отчество";
        }

        private void LoginTb_LostFocus(object sender, RoutedEventArgs e)
        {
            LoginTb.Text = "Логин";
        }

        private void PhoneTb_LostFocus(object sender, RoutedEventArgs e)
        {
            PhoneTb.Text = "Номер телефона";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
