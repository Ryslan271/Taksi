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
    /// Логика взаимодействия для MakeEmployeeWindow.xaml
    /// </summary>
    public partial class MakeEmployeeWindow : Window
    {
        public static MakeEmployeeWindow Instance { get; set; }

        public MakeEmployeeWindow()
        {
            NewEmployee = new Employee();

            Roles = App.db.Role.Local;

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
               AgeBox.Text.Trim() == "" ||
               PasswordBox.Text.Trim() == "";
        #endregion

        #region Обработчики

        private void AddNewDrivingLicenseCategory_Click(object sender, RoutedEventArgs e)
        {
            new MakeDrivingLicenseCategory(NewEmployee, false).ShowDialog();
        }

        private void DeleteNewDrivingLicenseCategory_Click(object sender, RoutedEventArgs e)
        {
            if (ListDrivingLicenseCategory.SelectedItem == null)
            {
                MessageBox.Show("Для удаление категории, выберите одну категорию из списка");
                return;
            }

            NewEmployee.DrivingLicenseCategory.Remove(ListDrivingLicenseCategory.SelectedItem as DrivingLicenseCategory);
            ListDrivingLicenseCategory.Items.Refresh();

            App.db.SaveChanges();
        }

        private void SaveNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateChangesData())
            {
                MessageBox.Show("Поля не должны оставаться пустыми", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ComboBoxRoleEmployee.SelectedItem == null)
                return;

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

            if (NewEmployee.Age < 18)
            {
                MessageBox.Show("Нельзя добавлять сотрудников, которым меньше 18 лет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NewEmployee.Role = ComboBoxRoleEmployee.SelectedItem as Role;

            App.db.Employee.Local.Add(NewEmployee);

            App.db.SaveChanges();

            MainWindow.GoMessager(true);
        }

        private void ComboBoxRoleEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridDrivingLicenseCategory == null)
                return;

            if ((ComboBoxRoleEmployee.SelectedItem as Role).ID == 1)
                GridDrivingLicenseCategory.Visibility = Visibility.Visible;
            else
                GridDrivingLicenseCategory.Visibility = Visibility.Collapsed;
        }
        #endregion

    }
}
