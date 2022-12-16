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
            get => this.Car.Employee;
        }

        public string InProcessing
        {
            get
            {
                if (this.OrderStatusID == 0)
                    return "Новый";
                else if (this.OrderStatusID == 1)
                    return "Выдан";
                else if (this.OrderStatusID == 2)
                    return "Принят";

                return "Сделан";
            }
        }
    }
}
