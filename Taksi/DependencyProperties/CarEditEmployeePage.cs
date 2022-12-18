using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Taksi.Pages
{
    public partial class CarEditEmployeePage
    {
        public IEnumerable<Employee> Employees
        {
            get { return (IEnumerable<Employee>)GetValue(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }

        public static readonly DependencyProperty EmployeesProperty =
            DependencyProperty.Register("Employees", typeof(IEnumerable<Employee>), typeof(CarEditEmployeePage));

        public ObservableCollection<Car> Cars
        {
            get { return (ObservableCollection<Car>)GetValue(CarsProperty); }
            set { SetValue(CarsProperty, value); }
        }

        public static readonly DependencyProperty CarsProperty =
            DependencyProperty.Register("Cars", typeof(ObservableCollection<Car>), typeof(CarEditEmployeePage));
    }
}
