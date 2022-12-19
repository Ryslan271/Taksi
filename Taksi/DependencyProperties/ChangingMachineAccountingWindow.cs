using System.Windows;

namespace Taksi.Windows
{
    public partial class ChangingMachineAccountingWindow
    {
        public Employee EmployeeEditCar
        {
            get { return (Employee)GetValue(EmployeeEditCarProperty); }
            set { SetValue(EmployeeEditCarProperty, value); }
        }

        public static readonly DependencyProperty EmployeeEditCarProperty =
            DependencyProperty.Register("EmployeeEditCar", typeof(Employee), typeof(ChangingMachineAccountingWindow));
    }
}
