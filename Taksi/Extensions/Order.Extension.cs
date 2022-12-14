using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taksi
{
    public partial class Order
    {
        public Employee Driver
        {
            get => App.db.Car.First(x => x.Order == this).Employee;
        }
    }
}
