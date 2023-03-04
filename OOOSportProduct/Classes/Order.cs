namespace OOOSportProduct.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int orderID { get; set; }

        public int orderStatusId { get; set; }

        public DateTime orderDeliveryDateStart { get; set; }

        public DateTime ordrDiliveryDateEnd { get; set; }

        public int orderPickupPointId { get; set; }

        [Required]
        [StringLength(100)]
        public string orderClientFio { get; set; }

        public int orderCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
