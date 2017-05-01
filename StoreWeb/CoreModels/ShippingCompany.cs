namespace StoreWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShippingCompany")]
    public partial class ShippingCompany
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string ContactPerson { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string BusinessPhone { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(15)]
        public string ZipCode { get; set; }

        [StringLength(100)]
        public string Web { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}
