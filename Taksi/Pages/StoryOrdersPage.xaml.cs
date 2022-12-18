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
        public StoryOrdersPage()
        {
            if (App.Client != null)
                Orders = new CollectionViewSource { Source = App.db.Order.Local.Where(x => x.Client == App.Client) }.View;
            else if (App.Employee.RoleID == 0)
                Orders = new CollectionViewSource { Source = App.db.Order.Local }.View;
            else
                Orders = new CollectionViewSource { Source = App.db.Order.Local.Where(x => App.Employee.Car.Contains(x.Car)) }.View;

            Orders.GroupDescriptions.Add(new PropertyGroupDescription("InProcessing"));

            InitializeComponent();
        }
    }
}
