using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Taksi.Windows;

namespace Taksi.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarEditEmployeePage.xaml
    /// </summary>
    public partial class CarEditEmployeePage : Page
    {
        public CarEditEmployeePage()
        {
            Employees = App.db.Employee.Local.Where(x => x.RoleID == 1);

            Cars = new ObservableCollection<Car>(App.db.Car.Local.Where(x => x.Employee == null));

            InitializeComponent();
        }

        private void CarEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (ListCars.SelectedItem == null ||
                ListEmployees.SelectedItem == null)
                return;

            Employee employee = ListEmployees.SelectedItem as Employee;

            employee.Car.Add(ListCars.SelectedItem as Car);

            Cars.Remove(ListCars.SelectedItem as Car);

            ListCars.Items.Refresh();
            ListEmployees.Items.Refresh();

            App.db.SaveChanges();
            MainWindow.GoMessager(true);
        }
    }
}
