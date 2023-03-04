namespace OOOSportProduct.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int userId { get; set; }

        [Required]
        [StringLength(100)]
        public string userSurname { get; set; }

        [Required]
        [StringLength(100)]
        public string userName { get; set; }

        [Required]
        [StringLength(100)]
        public string userPatronymic { get; set; }

        [Required]
        public string userLogin { get; set; }

        [Required]
        public string userPassword { get; set; }

        public int userRoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
