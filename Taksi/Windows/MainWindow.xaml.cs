using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Threading;
using System;
using System.Windows.Media.Imaging;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DispatcherTimer timer;
        public string FullNameUser { get; set; }
        public static MainWindow Instance { get; set; }

        public MainWindow()
        {
            if (App.Client != null)
                FullNameUser = App.Client.FullName;
            else
                FullNameUser = App.Employee.FullName;

            FlagClickTab = Visibility.Visible;

            InitializeComponent();

            Instance = this;

            ParsonCabinet.IsChecked = true;

            if (App.Client == null)
                MainFrame.Navigate(new Pages.PersonalEmployeePage());
            else
                MainFrame.Navigate(new Pages.PersonalClientPage());
        }

        #region Обработчики

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            App.Client = null;
            App.Employee = null;
            new LoginWindow().Show();
            Close();
        }

        private void ParsonCabinet_Click(object sender, RoutedEventArgs e)
        {
            if (App.Client == null)
                MainFrame.Navigate(new Pages.PersonalEmployeePage());
            else
                MainFrame.Navigate(new Pages.PersonalClientPage());
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.StoryOrdersPage());
        }

        #region Проверка на нажатие кнопки TAB

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab && FlagClickTab == Visibility.Visible)
            {
                FlagClickTab = Visibility.Collapsed;
                Colum.Width = new GridLength(70);
                MenuIcon.Width = 50;

            }
            else if (e.Key == Key.Tab && FlagClickTab == Visibility.Collapsed)
            {
                FlagClickTab = Visibility.Visible;
                Colum.Width = new GridLength(210);
                MenuIcon.Width = 100;
            }
        }
        #endregion

        private void MakeOrder_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pages.MakeOrderPage());
        private void ListEmployeeButton_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pages.ListEmployeePage());
        private void ListClientButton_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pages.ListClientPage());
        private void ListCars_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pages.ListCarsPage());
        private void CarEditEmployee_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pages.CarEditEmployeePage());
        #endregion

        #region Вывод информация о том сохранен/не сохранен

        public static void GoMessager(bool flag)
        {
            if (flag)
            {
                Instance.InformationMessage.Text = "Запись сохранена";
                Instance.InformationMessage.Foreground = Brushes.White;

                Instance.StackPanelMessageInfo.Background = Brushes.Green;
                Instance.StackPanelMessageInfo.BorderBrush = Brushes.Green;
            }
            else
            {
                Instance.InformationMessage.Text = "Запись отменена";
                Instance.InformationMessage.Foreground = Brushes.White;

                Instance.StackPanelMessageInfo.Background = Brushes.Red;
                Instance.StackPanelMessageInfo.BorderBrush = Brushes.Red;
            }

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 15);
            timer.Start();
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            Instance.InformationMessage.Text = "";
            Instance.StackPanelMessageInfo.Background = Brushes.Transparent;
            Instance.StackPanelMessageInfo.BorderBrush = Brushes.Transparent;
        }
        #endregion

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
