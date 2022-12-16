using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

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


        public int Cost
        {
            get { return (int)GetValue(CostProperty); }
            set { SetValue(CostProperty, value); }
        }

        public static readonly DependencyProperty CostProperty =
            DependencyProperty.Register("Cost", typeof(int), typeof(MakeOrderPage));


        public IEnumerable<Client> Clients
        {
            get { return (IEnumerable<Client>)GetValue(ClientsProperty); }
            set { SetValue(ClientsProperty, value); }
        }

        public static readonly DependencyProperty ClientsProperty =
            DependencyProperty.Register("Clients", typeof(IEnumerable<Client>), typeof(MakeOrderPage));
    }
}
