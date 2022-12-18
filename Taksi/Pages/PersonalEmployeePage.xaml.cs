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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Taksi.Windows;

namespace Taksi.Pages
{
    /// <summary>
    /// Логика взаимодействия для PersonalEmployeePage.xaml
    /// </summary>
    public partial class PersonalEmployeePage : Page
    {
        public static PersonalEmployeePage Instance { get; set; } 
        public PersonalEmployeePage()
        {
            EmployeePersonal = App.Employee;

            InitializeComponent();

            Instance = this;
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

            return message.Count == 0 ? (null, true) : (message, false);
        }

        private bool ValidateChangesData() =>
               NameBox.Text.Trim() == "" ||
               SurnameBox.Text.Trim() == "" ||
               PatronymicBox.Text.Trim() == "" ||
               PhoneBox.Text.Trim() == "" ||
               EmailBox.Text.Trim() == "" ||
               LoginBox.Text.Trim() == "" ||
               PasswordBox.Text.Trim() == "";
        #endregion

        #region Обработчики

        private void EditingEmployee(object sender, RoutedEventArgs e)
        {
            if (App.db.ChangeTracker.HasChanges() == false)
                return;

            if (ValidateChangesData())
            {
                MessageBox.Show("Поля не должны оставаться пустыми", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Employee user = App.db.Employee.Local.FirstOrDefault(x => x.Login == LoginBox.Text.Trim() ||
                                                                  x.Email == EmailBox.Text.Trim() ||
                                                                  x.PhoneNumber == PhoneBox.Text.Trim());

            if (user != null)
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

            App.db.SaveChanges();
        }

        private void AddNewDrivingLicenseCategory_Click(object sender, RoutedEventArgs e)
        {
            new MakeDrivingLicenseCategory(EmployeePersonal, true).ShowDialog();
        }

        private void DeleteNewDrivingLicenseCategory_Click(object sender, RoutedEventArgs e)
        {
            if (ListDrivingLicenseCategory.SelectedItem == null)
            {
                MessageBox.Show("Для удаление категории, выберите одну категорию из списка");
                return;
            }

            EmployeePersonal.DrivingLicenseCategory.Remove(ListDrivingLicenseCategory.SelectedItem as DrivingLicenseCategory);
            ListDrivingLicenseCategory.Items.Refresh();

            App.db.SaveChanges();
        }
        #endregion

    }
}
