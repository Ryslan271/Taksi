using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Taksi.Pages
{
    /// <summary>
    /// Логика взаимодействия для MakeOrderPage.xaml
    /// </summary>
    public partial class MakeOrderPage : Page
    {
        public DateTime NowDateTime { get; set; } = DateTime.Now;

        public MakeOrderPage()
        {
            ViewCars = App.db.ViewCar.Local;

            InitializeComponent();
        }

        #region Обработчики

        private void ViewCar_Click(object sender, RoutedEventArgs e)
        {
            if (ViewCarComboBox.SelectedItem == null)
                return;

            Cars = new System.Collections.ObjectModel.ObservableCollection<Car>
                    (App.db.Car.Local.Where(x => x.ViewCar == (ViewCarComboBox.SelectedItem as ViewCar)));

            ViewCarStackPanel.Visibility = Visibility.Collapsed;
            MakeOrderMainGrid.Visibility = Visibility.Visible;
            ButtonCancel.Visibility = Visibility.Visible;

            NewOrder();
        }

        private void NewOrder()
        {
            MakeOrder = new Order
            {
                CreationDate = NowDateTime
            };
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ViewCarStackPanel.Visibility = Visibility.Visible;
            MakeOrderMainGrid.Visibility = Visibility.Collapsed;
            ButtonCancel.Visibility = Visibility.Collapsed;

            MakeOrder = null;
        }
        #endregion
    }
}
