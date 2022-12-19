using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для MakeClientWindow.xaml
    /// </summary>
    public partial class MakeClientWindow : Window
    {
        public MakeClientWindow()
        {
            NewClient = new Client()
            {
                GradeClientID = 0
            };

            InitializeComponent();
        }

        #region Обработчики

        private void SaveNewClient_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateClient() == true)
                return;

            Employee userEmployee = App.db.Employee.Local.FirstOrDefault(x => x.Login == LoginBox.Text.Trim() ||
                                                                  x.Email == EmailBox.Text.Trim() ||
                                                                  x.PhoneNumber == PhoneBox.Text.Trim());

            Client userClient = App.db.Client.Local.FirstOrDefault(x => x.Login == LoginBox.Text.Trim() ||
                                                                 x.Email == EmailBox.Text.Trim() ||
                                                                 x.PhoneNumber == PhoneBox.Text.Trim());

            if (userEmployee != null || userClient != null)
            {
                MessageBox.Show("Пользователь с таким логином" +
                                " или адресом электронной почты" +
                                " или с номером телефона уже есть",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            (List<string> message, bool flag) = ValidatePassword(PasswordBox.Text.Trim());

            if (flag == false)
            {
                MessageBox.Show(string.Join("\n", message), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            App.db.Client.Local.Add(NewClient);
            App.db.SaveChanges();
            MainWindow.GoMessager(true);
        }
        #endregion

        #region Методы

        private bool ValidateClient() =>
            NameBox.Text.Trim() == "" ||
            SurnameBox.Text.Trim() == "" ||
            PatronymicBox.Text.Trim() == "" ||
            PhoneBox.Text.Trim() == "" ||
            EmailBox.Text.Trim() == "" ||
            LoginBox.Text.Trim() == "" ||
            PasswordBox.Text.Trim() == "" ||
            LoginBox.Text.Trim().Length > 6;

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

            return message.Count == 0 ? (null, true) : (message, false);
        }
        #endregion
    }
}
