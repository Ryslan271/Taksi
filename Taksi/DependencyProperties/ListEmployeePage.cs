using System.ComponentModel;
using System.Windows;

namespace Taksi.Pages
{
    public partial class ListEmployeePage
    {
        public ICollectionView Employees
        {
            get { return (ICollectionView)GetValue(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }

        public static readonly DependencyProperty EmployeesProperty =
            DependencyProperty.Register("Employees", typeof(ICollectionView), typeof(ListEmployeePage));
    }
}
