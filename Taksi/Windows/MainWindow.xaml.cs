using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public bool FlagClickTab
        {
            get => FlagClickTab;
            set
            {
                FlagClickTab = value;
                OnPropertyChaged();
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChaged() =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Visibility"));

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
        #endregion

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab && FlagClickTab == true)
            {
                FlagClickTab = false;
                Colum.Width = new GridLength(70);

            }
            else if (e.Key == Key.Tab && FlagClickTab == false)
            {
                FlagClickTab = true;
                Colum.Width = new GridLength(180);
            }
        }
    }
}
