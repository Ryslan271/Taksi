using System.ComponentModel;
using System.Windows;

namespace Taksi.Pages
{
    public partial class StoryOrdersPage
    {
        public ICollectionView Orders
        {
            get { return (ICollectionView)GetValue(OrdersProperty); }
            set { SetValue(OrdersProperty, value); }
        }

        public static readonly DependencyProperty OrdersProperty =
            DependencyProperty.Register("Orders", typeof(ICollectionView), typeof(StoryOrdersPage));
    }
}
