namespace StoreWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseOrderDetail
    {
        public int Id { get; set; }

        public int PurchaseOrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal? UnitCost { get; set; }

        public decimal? ExtendedPrice { get; set; }

        public DateTime? DateReceived { get; set; }

        public bool? PostedToInventory { get; set; }

        public bool? IsSubmitted { get; set; }

        public virtual Product Product { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
