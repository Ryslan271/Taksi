﻿using System.Windows;

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
        }

        #region Методы при входе в систему

        public static void EnterEmployee(Employee employee)
        {
            if (employee == null)
            {
                MessageBox.Show("Такой пользователь не зарегистрирован");
                return;
            }

            App.Employee = employee;
            new MainWindow().Show();
        }

        public static void EnterClient(Client client)
        {
            if (client == null)
            {
                MessageBox.Show("Такой пользователь не зарегистрирован");
                return;
            }

            App.Client = client;
            new MainWindow().Show();
        }
        #endregion

        #region Обработчики

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }

        private void ParsonCabinet_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PersonalPage());
        }
        #endregion
    }
}