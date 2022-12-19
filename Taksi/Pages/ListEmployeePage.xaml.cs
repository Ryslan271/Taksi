using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Taksi.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListEmployee.xaml
    /// </summary>
    public partial class ListEmployeePage : Page
    {
        public static ListEmployeePage Instance { get; set; }
        public ListEmployeePage()
        {
            Employees = new CollectionViewSource { Source = App.db.Employee.Local }.View;

            Employees.GroupDescriptions.Add(new PropertyGroupDescription("InProcessing"));

            InitializeComponent();

            Instance = this;
        }

        private void AddNewEmployee_Click(object sender, RoutedEventArgs e) => new Windows.MakeEmployeeWindow().ShowDialog();

        private void ListEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((ListEmployees.SelectedItem as Employee).RoleID != 1)
                return;

            new Windows.ChangingMachineAccountingWindow(ListEmployees.SelectedItem as Employee).ShowDialog();
        }
    }
}
