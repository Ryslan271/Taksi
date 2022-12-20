using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для MakeCarWindow.xaml
    /// </summary>
    public partial class MakeCarWindow : Window
    {
        public MakeCarWindow(Car car = null)
        {
            App.db.ViewCar.Load();
            App.db.BrandCars.Load();
            App.db.ColorCar.Load();
            App.db.WeightLimit.Load();

            NewCar = car ?? new Car();

            ViewCarses = App.db.ViewCar.Local;
            BrandCarses = App.db.BrandCars.Local;
            ColorsCars = App.db.ColorCar.Local;
            WeightLimits = App.db.WeightLimit.Local;
            Drivers = App.db.Employee.Local.Where(x => x.RoleID == 1);

            InitializeComponent();
        }

        private bool ValidateChangesData() =>
            ComboBoxBrandCarses.SelectedItem == null ||
            ComboBoxColorsCars.SelectedItem == null ||
            ComboBoxViewCarses.SelectedItem == null ||
            ComboBoxWeightLimits.SelectedItem == null ||
            NewCar.RegionNumber == 0 ||
            NewCar.NumberСar == "" ||
            NewCar.NumberСar == null;

        private void SaveNewCar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateChangesData() == true)
            {
                MessageBox.Show("Обязательные поля должны быть заполнены");
                return;
            }

            NewCar.ViewCar = ComboBoxViewCarses.SelectedItem as ViewCar;
            NewCar.BrandCars = ComboBoxBrandCarses.SelectedItem as BrandCars;
            NewCar.ColorCar = ComboBoxColorsCars.SelectedItem as ColorCar;
            NewCar.WeightLimit = ComboBoxWeightLimits.SelectedItem as WeightLimit;

            if (ComboBoxDrivers.SelectedItem != null)
                NewCar.Employee = ComboBoxDrivers.SelectedItem as Employee;

            App.db.Car.Local.Add(NewCar);

            App.db.SaveChanges();

            MainWindow.GoMessager(true);
            Close();
        }

        private void ExitWindow_Click(object sender, RoutedEventArgs e)
        {
            NewCar = null;
            Close();
        }
    }
}
