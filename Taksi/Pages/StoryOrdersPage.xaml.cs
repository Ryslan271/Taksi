using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для StoryOrdersPage.xaml
    /// </summary>
    public partial class StoryOrdersPage : Page
    {
        public StoryOrdersPage()
        {
            if (App.Client != null)
                Orders = new CollectionViewSource { Source = App.db.Order.Local.Where(x => x.Client == App.Client) }.View;
            else if (App.Employee.RoleID == 0)
                Orders = new CollectionViewSource { Source = App.db.Order.Local }.View;
            else
                Orders = new CollectionViewSource { Source = App.db.Order.Local.Where(x => x.Car == App.Employee.Car) }.View;

            Orders.GroupDescriptions.Add(new PropertyGroupDescription("InProcessing"));

            InitializeComponent();
        }
    }
}
