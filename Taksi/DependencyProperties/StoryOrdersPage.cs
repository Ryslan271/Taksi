using System.Collections.ObjectModel;
using System.Windows;

namespace Taksi.Pages
{
    public partial class StoryOrdersPage
    {
        public ObservableCollection<Order> Orders
        {
            get { return (ObservableCollection<Order>)GetValue(OrdersProperty); }
            set { SetValue(OrdersProperty, value); }
        }

        public static readonly DependencyProperty OrdersProperty =
            DependencyProperty.Register("Orders", typeof(ObservableCollection<Order>), typeof(StoryOrdersPage));
    }
}
