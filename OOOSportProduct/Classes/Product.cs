namespace OOOSportProduct.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        [StringLength(6)]
        public string ProductArticleNumber { get; set; }

        [Required]
        public string ProductName { get; set; }

        public int productUnitId { get; set; }

        public decimal ProductCost { get; set; }

        public int ProductSaleMax { get; set; }

        public int productManufacturerId { get; set; }

        public int productProviderId { get; set; }

        public int productCategoryId { get; set; }

        public int productSale { get; set; }

        public int productCount { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [StringLength(50)]
        public string ProductPhoto { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        public virtual Provider Provider { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
