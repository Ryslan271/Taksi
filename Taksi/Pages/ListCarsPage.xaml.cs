using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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

        private void AddCar_Click(object sender, RoutedEventArgs e) => new Windows.MakeCarWindow().ShowDialog();

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListCars.SelectedItem == null)
                return;

            new Windows.MakeCarWindow(ListCars.SelectedItem as Car).ShowDialog();
        }
    }
}
