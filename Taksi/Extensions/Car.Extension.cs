using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taksi
{
    public partial class Car
    {
        public string StatusCar
        {
            get
            {
                if (this.ViewCarID == 0)
                    return "Перевозка грузов без пассажиров";
                else if (this.ViewCarID == 1)
                    return "Перевозка людей без груза";

                return "Перевозка груза и пассажиров";
            }
        }
    }
}
