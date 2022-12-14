using System.Windows;

namespace Taksi.Pages
{
    public partial class PersonalEmployeePage
    {
        public Employee EmployeePersonal
        {
            get { return (Employee)GetValue(EmployeeProperty); }
            set { SetValue(EmployeeProperty, value); }
        }

        public static readonly DependencyProperty EmployeeProperty =
            DependencyProperty.Register("EmployeePersonal", typeof(Employee), typeof(PersonalEmployeePage));
    }
}
