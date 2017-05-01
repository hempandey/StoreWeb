using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreWeb.ViewModel
{
    public class ProductViewModel
    {
        
        public Product Product { get; set; }
        public List<SalesOrder> SalesOrder { get; set; }
        public List<PurchaseOrder> PurchaseOrder { get; set; }
        public InventoryViewModel InventoryViewModel { get; set; }


    }
}