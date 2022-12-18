using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Taksi.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListEmployee.xaml
    /// </summary>
    public partial class ListEmployeePage : Page
    {
        public ListEmployeePage()
        {
            Employees = new CollectionViewSource { Source = App.db.Employee.Local }.View;

            Employees.GroupDescriptions.Add(new PropertyGroupDescription("InProcessing"));

            InitializeComponent();
        }

        private void AddNewEmployee_Click(object sender, RoutedEventArgs e) => new Windows.MakeEmployeeWindow().ShowDialog();
    }
}
