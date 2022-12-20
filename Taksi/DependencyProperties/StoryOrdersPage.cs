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

        public Visibility VisibilityButtonSupport
        {
            get { return (Visibility)GetValue(VisibilityButtonSupportProperty); }
            set { SetValue(VisibilityButtonSupportProperty, value); }
        }

        public static readonly DependencyProperty VisibilityButtonSupportProperty =
            DependencyProperty.Register("VisibilityButtonSupport", typeof(Visibility), typeof(StoryOrdersPage));

        public Visibility VisibilityButtonDriver
        {
            get { return (Visibility)GetValue(VisibilityButtonDriverSupportProperty); }
            set { SetValue(VisibilityButtonDriverSupportProperty, value); }
        }

        public static readonly DependencyProperty VisibilityButtonDriverSupportProperty =
            DependencyProperty.Register("VisibilityButtonDriver", typeof(Visibility), typeof(StoryOrdersPage));
    }
}
