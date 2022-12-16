using System.Collections.ObjectModel;
using System.Windows;

namespace Taksi.Pages
{
    public partial class ListCarsPage
    {
        public ObservableCollection<Car> Cars
        {
            get { return (ObservableCollection<Car>)GetValue(CarsProperty); }
            set { SetValue(CarsProperty, value); }
        }

        public static readonly DependencyProperty CarsProperty =
            DependencyProperty.Register("Cars", typeof(ObservableCollection<Car>), typeof(ListCarsPage));
    }
}
