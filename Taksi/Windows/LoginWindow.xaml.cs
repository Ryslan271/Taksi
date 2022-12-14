using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Taksi.Properties;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Employee _userEmployee;
        Client _user;

        public LoginWindow()
        {
            InitializeComponent();

            if (Settings.Default.Login != null)
                LoginBox.Text = Settings.Default.Login;
        }

        #region Обработчики

        private void GoToRegistrationPage_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            Close();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            _user = App.db.Client.Local.FirstOrDefault(x => x.Login == LoginBox.Text.Trim() && x.Password == PasswordBox.Password.Trim());

            if (_user == null)
            {
                _userEmployee = App.db.Employee.Local.FirstOrDefault(x => x.Login == LoginBox.Text.Trim() && x.Password == PasswordBox.Password.Trim());
                EnterEmployee(_userEmployee);
            }

            if (_userEmployee == null && _user == null)
            {
                MessageBox.Show("Такой пользователь не зарегистрирован");
                return;
            }

            EnterClient(_user);
        }
        #endregion

        #region Методы при входе в систему

        public void EnterEmployee(Employee employee)
        {
            if (employee == null)
                return;

            if (CheckSaveLogin.IsChecked == true)
                Settings.Default.Login = LoginBox.Text.Trim();

            App.Employee = employee;
            new MainWindow().Show();
            Close();
        }

        public void EnterClient(Client client)
        {
            if (client == null)
                return;

            if (CheckSaveLogin.IsChecked == true)
                Settings.Default.Login = LoginBox.Text.Trim();

            App.Client = client;
            new MainWindow().Show();
            Close();
        }
        #endregion
    }
}
