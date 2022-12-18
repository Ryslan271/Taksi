using System.Collections.Generic;
using System.Windows;

namespace Taksi.Windows
{
    public partial class MakeCarWindow
    {
        public Car NewCar
        {
            get { return (Car)GetValue(NewCarProperty); }
            set { SetValue(NewCarProperty, value); }
        }

        public static readonly DependencyProperty NewCarProperty =
            DependencyProperty.Register("NewCar", typeof(Car), typeof(MakeCarWindow));

        public IEnumerable<BrandCars> BrandCarses
        {
            get { return (IEnumerable<BrandCars>)GetValue(BrandCarsesProperty); }
            set { SetValue(BrandCarsesProperty, value); }
        }

        public static readonly DependencyProperty BrandCarsesProperty =
            DependencyProperty.Register("BrandCarses", typeof(IEnumerable<BrandCars>), typeof(MakeCarWindow));

        public IEnumerable<ViewCar> ViewCarses
        {
            get { return (IEnumerable<ViewCar>)GetValue(ViewCarsesProperty); }
            set { SetValue(ViewCarsesProperty, value); }
        }

        public static readonly DependencyProperty ViewCarsesProperty =
            DependencyProperty.Register("ViewCarses", typeof(IEnumerable<ViewCar>), typeof(MakeCarWindow));

        public IEnumerable<ColorCar> ColorsCars
        {
            get { return (IEnumerable<ColorCar>)GetValue(ColorsCarsProperty); }
            set { SetValue(ColorsCarsProperty, value); }
        }

        public static readonly DependencyProperty ColorsCarsProperty =
            DependencyProperty.Register("ColorsCars", typeof(IEnumerable<ColorCar>), typeof(MakeCarWindow));

        public IEnumerable<WeightLimit> WeightLimits
        {
            get { return (IEnumerable<WeightLimit>)GetValue(WeightLimitsProperty); }
            set { SetValue(WeightLimitsProperty, value); }
        }

        public static readonly DependencyProperty WeightLimitsProperty =
            DependencyProperty.Register("WeightLimits", typeof(IEnumerable<WeightLimit>), typeof(MakeCarWindow));

        public IEnumerable<Employee> Drivers
        {
            get { return (IEnumerable<Employee>)GetValue(DriversProperty); }
            set { SetValue(DriversProperty, value); }
        }

        public static readonly DependencyProperty DriversProperty =
            DependencyProperty.Register("Drivers", typeof(IEnumerable<Employee>), typeof(MakeCarWindow));
    }
}
