using System.ComponentModel;
using System.Windows;

namespace Taksi.Pages
{
    public partial class ListCarsPage
    {
        public ICollectionView Cars
        {
            get { return (ICollectionView)GetValue(CarsProperty); }
            set { SetValue(CarsProperty, value); }
        }

        public static readonly DependencyProperty CarsProperty =
            DependencyProperty.Register("Cars", typeof(ICollectionView), typeof(ListCarsPage));
    }
}
