namespace OOOSportProduct.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int categoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string categoryName { get; set; }
    }
}
