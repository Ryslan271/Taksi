using System.Collections.ObjectModel;
using System.Windows;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для MakeDrivingLicenseCategory.xaml
    /// </summary>
    public partial class MakeDrivingLicenseCategory : Window
    {
        private Employee _employee;
        private bool _flag;

        public MakeDrivingLicenseCategory(Employee employee, bool flag)
        {
            _employee = employee;
            _flag = flag;

            DrivingLicenseCategories = new ObservableCollection<DrivingLicenseCategory>(App.db.DrivingLicenseCategory.Local);

            InitializeComponent();
        }

        private void AddNewCategoryEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (ListDrivingLicenseCategory.SelectedItem == null)
            {
                MessageBox.Show("Категория не выбрана");
                return;
            }

            _employee.DrivingLicenseCategory.Add(ListDrivingLicenseCategory.SelectedItem as DrivingLicenseCategory);

            if (_flag == true)
                Pages.PersonalEmployeePage.Instance.ListDrivingLicenseCategory.Items.Refresh();
            else
                Windows.MakeEmployeeWindow.Instance.ListDrivingLicenseCategory.Items.Refresh();

            DrivingLicenseCategories.Remove(ListDrivingLicenseCategory.SelectedItem as DrivingLicenseCategory);

            App.db.SaveChanges();
        }
    }
}
