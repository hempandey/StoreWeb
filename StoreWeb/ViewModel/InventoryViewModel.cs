using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreWeb.ViewModel
{
    public class InventoryViewModel
    {
        public Inventory Inventory { get; set; }
        public List<InventoryShrinkage> InventoryShrinkage { get; set; }


    }
}