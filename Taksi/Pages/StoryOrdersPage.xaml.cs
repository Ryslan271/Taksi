using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace Taksi.Pages
{
    /// <summary>
    /// Логика взаимодействия для StoryOrdersPage.xaml
    /// </summary>
    public partial class StoryOrdersPage : Page
    {
        public Employee Employee { get; set; } = App.Employee;
        public StoryOrdersPage()
        {
            if (App.Client != null)
                Orders = new CollectionViewSource { Source = App.db.Order.Local.Where(x => x.Client == App.Client) }.View;
            else if (App.Employee.RoleID == 0 || App.Employee.RoleID == 2)
                Orders = new CollectionViewSource { Source = App.db.Order.Local }.View;
            else
                Orders = new CollectionViewSource { Source = App.db.Order.Local.Where(x => App.Employee.Car.Contains(x.Car)) }.View;

            Orders.GroupDescriptions.Add(new PropertyGroupDescription("InProcessing"));

            InitializeComponent();
        }

        private void ChangeStatusAccepted_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ListOrder.SelectedItem == null &&
               (ListOrder.SelectedItem as Order).OrderStatusID == 1)
                return;

            Order order = ListOrder.SelectedItem as Order;

            order.OrderStatusID = 2;

            Orders.Refresh();
            ListOrder.Items.Refresh();
        }

        private void ChangeStatusDone_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ListOrder.SelectedItem == null &&
               (ListOrder.SelectedItem as Order).OrderStatusID == 2)
                return;

            Order order = ListOrder.SelectedItem as Order;

            order.OrderStatusID = 3;

            Orders.Refresh();
            ListOrder.Items.Refresh();
        }
    }
}
