using System.Data.Entity;
using System.Windows;

namespace Taksi
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CompanyBaseEntities db { get; set; } = new CompanyBaseEntities();
        public static Employee Employee { get; set; }
        public static Client Client { get; set; }

        public App()
        {
            db.Employee.Load();
            db.Client.Load();
            db.ViewCar.Load();
            db.Car.Load();
            db.Role.Load();
            db.Order.Load();
            db.DrivingLicenseCategory.Load();
        }
    }
}
