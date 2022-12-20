using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Taksi.Pages;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangingMachineAccountingWindow.xaml
    /// </summary>
    public partial class ChangingMachineAccountingWindow : Window
    {
        public ChangingMachineAccountingWindow(Employee employee)
        {
            EmployeeEdit = employee;

            Roles = App.db.Role.Local;

            InitializeComponent();

            ChageVisibilityCarsDriverDelete();
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

        private void ChageVisibilityCarsDriverDelete()
        {
            if (EmployeeEdit.RoleID != 1)
            {
                CarsDriverDelete.Visibility = Visibility.Collapsed;
                GridDrivingLicenseCategory.Visibility = Visibility.Collapsed;
                return;
            }

            CarsDriverDelete.Visibility = Visibility.Visible;
            GridDrivingLicenseCategory.Visibility = Visibility.Visible;
        }

        private bool CheckEmployeeDate()
        {
            if (ValidateChangesData())
            {
                MessageBox.Show("Поля не должны оставаться пустыми", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            int userCount = App.db.Employee.Local.Count(x => x.Login == LoginBox.Text.Trim() ||
                                                             x.Email == EmailBox.Text.Trim() ||
                                                             x.PhoneNumber == PhoneBox.Text.Trim());

            if (userCount > 1)
            {
                MessageBox.Show("Пользователь с таким логином" +
                                " или адресом электронной почты" +
                                " или с номером телефона уже есть",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            (List<string> message, bool flag) = ValidatePassword(PasswordBox.Text.Trim());

            if (flag == false)
            {
                MessageBox.Show(string.Join("\n", message), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
        #endregion

        #region Обработчики

        private void DeleteCarInEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (ListCarEmployee.SelectedItem == null)
                return;

            if (CheckEmployeeDate() == false)
                return;

            EmployeeEdit.Car.Remove(ListCarEmployee.SelectedItem as Car);

            ListCarEmployee.Items.Refresh();

            App.db.SaveChanges();

            ListEmployeePage.Instance.ListEmployees.Items.Refresh();

            MainWindow.GoMessager(true);
        }

        private void SaveChange_Click(object sender, RoutedEventArgs e)
        {
            if (App.db.ChangeTracker.HasChanges() == false)
                return;

            if (CheckEmployeeDate() == false)
                return;

            App.db.SaveChanges();
            MainWindow.GoMessager(true);
            ListEmployeePage.Instance.Employees.Refresh();
        }

        private void DeleteNewDrivingLicenseCategory_Click(object sender, RoutedEventArgs e)
        {
            if (ListDrivingLicenseCategory.SelectedItem == null)
            {
                MessageBox.Show("Для удаление категории, выберите одну категорию из списка");
                return;
            }

            EmployeeEdit.DrivingLicenseCategory.Remove(ListDrivingLicenseCategory.SelectedItem as DrivingLicenseCategory);
            ListDrivingLicenseCategory.Items.Refresh();

            App.db.SaveChanges();

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

        private void AddNewDrivingLicenseCategory_Click(object sender, RoutedEventArgs e) =>
            new MakeDrivingLicenseCategory(EmployeeEdit, true).ShowDialog();
        #endregion
    }
}
