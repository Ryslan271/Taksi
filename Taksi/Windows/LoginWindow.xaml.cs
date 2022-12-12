using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Taksi.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Employee _userEmployee;
        Client _user;

        public LoginWindow() => InitializeComponent();

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
                MainWindow.EnterEmployee(_userEmployee);
                Close();
            }

            MainWindow.EnterClient(_user);
            Close();
        }
        #endregion
    }
}
