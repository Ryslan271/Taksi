using System.Collections.Generic;
using System.Windows;

namespace Taksi.Windows
{
    public partial class ChangingMachineAccountingWindow
    {
        public Employee EmployeeEdit
        {
            get { return (Employee)GetValue(EmployeeEditCarProperty); }
            set { SetValue(EmployeeEditCarProperty, value); }
        }

        public static readonly DependencyProperty EmployeeEditCarProperty =
            DependencyProperty.Register("EmployeeEditCar", typeof(Employee), typeof(ChangingMachineAccountingWindow));

        public IEnumerable<Role> Roles
        {
            get { return (IEnumerable<Role>)GetValue(RolesProperty); }
            set { SetValue(RolesProperty, value); }
        }

        public static readonly DependencyProperty RolesProperty =
            DependencyProperty.Register("Roles", typeof(IEnumerable<Role>), typeof(ChangingMachineAccountingWindow));
    }
}
