//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Taksi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> CarID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string Address { get; set; }
        public int OrderStatusID { get; set; }
        public System.TimeSpan TimeForExecution { get; set; }
        public decimal Cost { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Client Client { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}
