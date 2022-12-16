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
    /// Логика взаимодействия для ListCarsPage.xaml
    /// </summary>
    public partial class ListCarsPage : Page
    {
        public ListCarsPage()
        {
            Cars = new CollectionViewSource { Source = App.db.Car.Local }.View;

            Cars.GroupDescriptions.Add(new PropertyGroupDescription("StatusCar"));

            InitializeComponent();
        }
    }
}
