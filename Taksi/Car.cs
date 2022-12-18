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
    
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int ID { get; set; }
        public string NumberСar { get; set; }
        public int RegionNumber { get; set; }
        public int ColorCarID { get; set; }
        public int ViewCarID { get; set; }
        public int BrandCarsID { get; set; }
        public int WeightLimitID { get; set; }
        public Nullable<int> DriverID { get; set; }
    
        public virtual BrandCars BrandCars { get; set; }
        public virtual ColorCar ColorCar { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ViewCar ViewCar { get; set; }
        public virtual WeightLimit WeightLimit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
