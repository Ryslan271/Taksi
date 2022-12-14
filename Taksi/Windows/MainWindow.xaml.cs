using System.Windows;

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
            MainFrame.Navigate(new Pages.PersonalEmployeePage());
        }
        #endregion

    }
}
