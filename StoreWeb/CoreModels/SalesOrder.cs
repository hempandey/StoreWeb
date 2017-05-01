namespace StoreWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesOrder")]
    public partial class SalesOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesOrder()
        {
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        public int Id { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? EmployeeId { get; set; }

        public int? CustomerId { get; set; }

        [StringLength(100)]
        public string ShipName { get; set; }

        public DateTime? ShippedDate { get; set; }

        [StringLength(100)]
        public string ShipAddress { get; set; }

        [StringLength(50)]
        public string ShipCity { get; set; }

        [StringLength(50)]
        public string ShipState { get; set; }

        [StringLength(12)]
        public string ShipZIpCode { get; set; }

        public decimal? ShipFee { get; set; }

        public int? ShipperId { get; set; }

        public decimal? Tax { get; set; }

        [StringLength(20)]
        public string PaymentType { get; set; }

        public DateTime? PaymentDate { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public decimal? TaxRate { get; set; }

        public decimal? OrderSubTotal { get; set; }

        public decimal? OrderTotal { get; set; }

        public int OrderStatusId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual OrderStatu OrderStatu { get; set; }

        public virtual SalesOrder SalesOrder1 { get; set; }

        public virtual SalesOrder SalesOrder2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
