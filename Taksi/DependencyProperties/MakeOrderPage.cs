using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Taksi.Windows;

namespace Taksi.Pages
{
    public partial class MakeOrderPage
    {
        public ObservableCollection<Car> Cars
        {
            get { return (ObservableCollection<Car>)GetValue(CarsProperty); }
            set { SetValue(CarsProperty, value); }
        }

        public static readonly DependencyProperty CarsProperty =
            DependencyProperty.Register("Cars", typeof(ObservableCollection<Car>), typeof(MakeOrderPage));


        public IEnumerable<ViewCar> ViewCars
        {
            get { return (IEnumerable<ViewCar>)GetValue(ViewCarsProperty); }
            set { SetValue(ViewCarsProperty, value); }
        }

        public static readonly DependencyProperty ViewCarsProperty =
            DependencyProperty.Register("ViewCars", typeof(IEnumerable<ViewCar>), typeof(MakeOrderPage));


        public Order MakeOrder
        {
            get { return (Order)GetValue(MakeOrderProperty); }
            set { SetValue(MakeOrderProperty, value); }
        }

        public static readonly DependencyProperty MakeOrderProperty =
            DependencyProperty.Register("MakeOrder", typeof(Order), typeof(MakeOrderPage));
    }
}
