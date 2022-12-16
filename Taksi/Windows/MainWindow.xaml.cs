using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Threading;
using System;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DispatcherTimer timer;

        public static MainWindow Instance { get; set; }

        public MainWindow()
        {
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

            }
            else if (e.Key == Key.Tab && FlagClickTab == Visibility.Collapsed)
            {
                FlagClickTab = Visibility.Visible;
                Colum.Width = new GridLength(180);
            }
        }
        #endregion

        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.MakeOrderPage());
        }
        #endregion

        #region Вывод информация о том сохранен/не сохранен заказ

        public static void GoMessager(bool flag)
        {
            if (flag)
            {
                Instance.InformationMessage.Text = "Заказ сохранен";
                Instance.InformationMessage.Foreground = Brushes.White;

                Instance.StackPanelMessageInfo.Background = Brushes.Green;
                Instance.StackPanelMessageInfo.BorderBrush = Brushes.Green;
            }
            else
            {
                Instance.InformationMessage.Text = "Заказ отменен";
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
    }
}
