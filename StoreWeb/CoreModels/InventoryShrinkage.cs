namespace StoreWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryShrinkage")]
    public partial class InventoryShrinkage
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }

        public int? Quantity { get; set; }

        [StringLength(100)]
        public string Reason { get; set; }

        public virtual Product Product { get; set; }
    }
}
