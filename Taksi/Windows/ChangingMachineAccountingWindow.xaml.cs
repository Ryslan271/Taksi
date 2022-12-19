using System.Windows;
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
            EmployeeEditCar = employee;

            InitializeComponent();
        }

        private void DeleteCarInEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (ListCarEmployee.SelectedItem == null)
                return;

            EmployeeEditCar.Car.Remove(ListCarEmployee.SelectedItem as Car);

            ListCarEmployee.Items.Refresh();

            App.db.SaveChanges();

            ListEmployeePage.Instance.ListEmployees.Items.Refresh();

            MainWindow.GoMessager(true);
        }
    }
}
