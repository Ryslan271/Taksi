using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        #region Методы

        private (List<string>, bool) ValidatePassword(string password)
        {
            List<string> message = new List<string>();

            if (password.Length < 6)
                message.Add("Пароль должен быть не менее 6 символов");
            if (!password.Any(c => Char.IsUpper(c)))
                message.Add("В пароле должна быть хотя бы одна прописная буква");
            if (!Regex.IsMatch(password, @"\d"))
                message.Add("В пароле должна быть хотя бы одна цифра");
            if (!Regex.IsMatch(password, @"[!@#$%^]"))
                message.Add("В пароле должен быть хотя бы одний из символов ! @ # $ % ^");

            return message == null ? (null, true) : (message, false);
        }

        private bool ValidateChangesData() =>
               NameBox.Text.Trim() == "" ||
               LastnameBox.Text.Trim() == "" ||
               PhynimicBox.Text.Trim() == "" ||
               PhoneBox.Text.Trim() == "" ||
               EmailBox.Text.Trim() == "" ||
               LoginBox.Text.Trim() == "" ||
               PasswordBox.Password.Trim() == "";

        private Client newClient() =>
           new Client()
           {
               Email = EmailBox.Text.Trim(),
               Surname = LastnameBox.Text.Trim(),
               Name = NameBox.Text.Trim(),
               Login = LoginBox.Text.Trim(),
               Password = PasswordBox.Password.Trim(),
               PhoneNumber = PhoneBox.Text.Trim(),
               Patronymic = PhynimicBox.Text.Trim(),
               GradeClientID = 5
           };
        #endregion

        #region Обработчики

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateChangesData())
            {
                MessageBox.Show("Поля не должны оставаться пустыми", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Client user = App.db.Client.Local.FirstOrDefault(x => x.Login == LoginBox.Text.Trim() ||
                                                                  x.Email == EmailBox.Text.Trim() ||
                                                                  x.PhoneNumber == PhoneBox.Text.Trim());

            if (user != null)
            {
                MessageBox.Show("Такой пользователь уже есть", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            (List<string> message, bool flag) = ValidatePassword(PasswordBox.Password.Trim());

            if (flag == false)
            {
                MessageBox.Show(string.Join("\n", message), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Client client = newClient();

            App.db.Client.Local.Add(client);
            App.Client = client;
            App.db.SaveChanges();

            new MainWindow().Show();
            Close();
        }

        private void GoToLoginPage_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
        #endregion
    }
}
