using System.Collections.Generic;
using System.Windows;

namespace Taksi.Windows
{
    public partial class MakeEmployeeWindow
    {
        public Employee NewEmployee
        {
            get { return (Employee)GetValue(NewEmployeeProperty); }
            set { SetValue(NewEmployeeProperty, value); }
        }

        public static readonly DependencyProperty NewEmployeeProperty =
            DependencyProperty.Register("NewEmployee", typeof(Employee), typeof(MakeEmployeeWindow));

        public IEnumerable<Role> Roles
        {
            get { return (IEnumerable<Role>)GetValue(RolesProperty); }
            set { SetValue(RolesProperty, value); }
        }

        public static readonly DependencyProperty RolesProperty =
            DependencyProperty.Register("Roles", typeof(IEnumerable<Role>), typeof(MakeEmployeeWindow));
    }
}
