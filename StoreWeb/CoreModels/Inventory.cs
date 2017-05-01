namespace StoreWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Inventory
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int? ReorderLevel { get; set; }

        public int? TargetLevel { get; set; }

        public int? MinReorderQuantity { get; set; }

        public int? Received { get; set; }

        public int? OnOrder { get; set; }

        public int? Shrinkage { get; set; }

        public int? Shipped { get; set; }

        public int? Allocated { get; set; }

        public int? BackOrder { get; set; }

        public int? InitialLevel { get; set; }

        public virtual Product Product { get; set; }
    }
}
