namespace StoreWeb
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreDB : DbContext
    {
        public StoreDB()
            : base("name=StoreDBConnection")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryShrinkage> InventoryShrinkages { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<ShippingCompany> ShippingCompanies { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryShrinkage>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<OrderStatu>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<OrderStatu>()
                .HasMany(e => e.PurchaseOrders)
                .WithOptional(e => e.OrderStatu)
                .HasForeignKey(e => e.OrderStatusId);

            modelBuilder.Entity<OrderStatu>()
                .HasMany(e => e.SalesOrders)
                .WithRequired(e => e.OrderStatu)
                .HasForeignKey(e => e.OrderStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderStatu>()
                .HasMany(e => e.SalesOrderDetails)
                .WithRequired(e => e.OrderStatu)
                .HasForeignKey(e => e.OrderStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
               .Property(e => e.ProductImage)
               .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.StandardCost)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.ListPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.QuantityPerUnit)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Inventories)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.InventoryShrinkages)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.SalesOrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.UnitCost)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.ExtendedPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.ShippingFee)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.Taxes)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.PaymentAmount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.PaymentMethod)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.OrderSubTotal)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.OrderTotal)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.ShipName)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.ShipAddress)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.ShipCity)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.ShipState)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.ShipZIpCode)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.ShipFee)
                .HasPrecision(8, 2);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.Tax)
                .HasPrecision(8, 2);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.PaymentType)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.TaxRate)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.OrderSubTotal)
                .HasPrecision(8, 2);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.OrderTotal)
                .HasPrecision(8, 2);

            modelBuilder.Entity<SalesOrder>()
                .HasOptional(e => e.SalesOrder1)
                .WithRequired(e => e.SalesOrder2);

            modelBuilder.Entity<SalesOrder>()
                .HasMany(e => e.SalesOrderDetails)
                .WithRequired(e => e.SalesOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.DiscountPercent)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.DiscountAmount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.EntendedPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.ContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.BusinessPhone)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.Web)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingCompany>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.BusinessPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.HomePhone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.FaxNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.SuppliedId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.SuppplierId)
                .WillCascadeOnDelete(false);
        }
    }
}
