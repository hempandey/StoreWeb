namespace StoreWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        public int Id { get; set; }

        public DateTime? OrderDate { get; set; }

        public int SuppplierId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ExpectedDate { get; set; }

        public decimal? ShippingFee { get; set; }

        public decimal? Taxes { get; set; }

        public DateTime? PaymentDate { get; set; }

        public decimal? PaymentAmount { get; set; }

        [StringLength(20)]
        public string PaymentMethod { get; set; }

        [StringLength(100)]
        public string Notes { get; set; }

        public decimal? OrderSubTotal { get; set; }

        public decimal? OrderTotal { get; set; }

        public int? SubmittedBy { get; set; }

        public DateTime? SubmittedDate { get; set; }

        public int? ClosedBy { get; set; }

        public DateTime? ClosedDate { get; set; }

        public bool? IsCompleted { get; set; }

        public bool? IsSubmitted { get; set; }

        public bool? IsNew { get; set; }

        public int? OrderStatusId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual OrderStatu OrderStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
