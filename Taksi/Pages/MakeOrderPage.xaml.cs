using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Taksi.Windows;

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
            Clients = App.db.Client.Local;

            InitializeComponent();

            if (App.Client != null)
                ClientView.Visibility = Visibility.Collapsed;
            else
                ClientView.Visibility = Visibility.Visible;
        }

        #region Обработчики

        private void ViewCar_Click(object sender, RoutedEventArgs e)
        {
            if (ViewCarComboBox.SelectedItem == null)
                return;

            if (ClientComboBox.SelectedItem == null)
                return;

            Cars = new System.Collections.ObjectModel.ObservableCollection<Car>
                    (App.db.Car.Local.Where(x => x.ViewCar == (ViewCarComboBox.SelectedItem as ViewCar)));

            CarsComboBox.Items.Refresh();

            ViewCarStackPanel.Visibility = Visibility.Collapsed;
            MakeOrderMainGrid.Visibility = Visibility.Visible;
            ButtonCancel.Visibility = Visibility.Visible;
            ButtonSave.Visibility = Visibility.Visible;

            NewOrder();

            Cost += MakeOrderCost(ViewCarComboBox.SelectedItem as ViewCar);
        }

        #region Определение цены

        private int MakeOrderCost(ViewCar viewCar)
        {
            switch (viewCar.ID)
            {
                case 0:
                    return 200;

                case 1:
                    return 300;
            }
            return 400;
        }

        private void Address_TextChanged(object sender, TextChangedEventArgs e)
        {
            TimeSpan dateTime = MakeOrder.TimeForExecution;

            Cost += (DateTime.Now - dateTime).Hour * 100;
        }
        #endregion

        private void NewOrder()
        {
            if (App.Client != null)
                MakeOrder = new Order
                {
                    CreationDate = NowDateTime,
                    Client = App.Client,
                    OrderStatusID = 0
                };

            else
                MakeOrder = new Order
                {
                    CreationDate = NowDateTime,
                    OrderStatusID = 0,
                    Client = ClientComboBox.SelectedItem as Client
                };
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ViewCarStackPanel.Visibility = Visibility.Visible;
            MakeOrderMainGrid.Visibility = Visibility.Collapsed;
            ButtonCancel.Visibility = Visibility.Collapsed;
            ButtonSave.Visibility = Visibility.Collapsed;

            MakeOrder = null;

            MainWindow.GoMessager(false);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (CarsComboBox.SelectedItem == null)
                return;

            if (ValidateNewOrder() == true)
            {
                MessageBox.Show("Поля не должны оставаться пустыми", "Ошибка");
                return;
            }

            MakeOrder.Car = CarsComboBox.SelectedItem as Car;
            MakeOrder.Client = App.Client;
            MakeOrder.Cost = Cost;

            App.db.Order.Local.Add(MakeOrder);

            App.db.SaveChanges();

            MainWindow.Instance.MakeOrderListButton.IsChecked = false;
            MainWindow.Instance.Orders.IsChecked = true;
            MainWindow.Instance.MainFrame.Navigate(new Pages.StoryOrdersPage());

            MainWindow.GoMessager(true);
        }

        private bool ValidateNewOrder() =>
            MakeOrder.Address == "" ||
            MakeOrder.Address == null;
        #endregion

    }
}
