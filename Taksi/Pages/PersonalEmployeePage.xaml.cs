﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Taksi.Pages
{
    /// <summary>
    /// Логика взаимодействия для PersonalEmployeePage.xaml
    /// </summary>
    public partial class PersonalEmployeePage : Page
    {
        public PersonalEmployeePage()
        {
            EmployeePersonal = App.Employee;

            InitializeComponent();
        }

        #region Обработчики

        private void EditingEmployee(object sender, RoutedEventArgs e)
        {
            if (App.db.ChangeTracker.HasChanges() == false)
                return;

            App.db.SaveChanges();
        }
        #endregion
    }
}
