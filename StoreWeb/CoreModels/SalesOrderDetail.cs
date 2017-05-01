namespace StoreWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SalesOrderDetail
    {
        public int Id { get; set; }

        public int SalesOrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        [StringLength(4)]
        public string DiscountPercent { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal EntendedPrice { get; set; }

        public int OrderStatusId { get; set; }

        public virtual OrderStatu OrderStatu { get; set; }

        public virtual Product Product { get; set; }

        public virtual SalesOrder SalesOrder { get; set; }
    }
}
