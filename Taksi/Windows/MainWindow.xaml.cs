using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.MakeOrderPage());
        }
        #endregion
    }
}
