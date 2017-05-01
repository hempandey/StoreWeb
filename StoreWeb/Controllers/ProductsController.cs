using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreWeb;
using StoreWeb.ViewModel;

namespace StoreWeb.Controllers
{
    public class ProductsController : Controller
    {
        private StoreDB db = new StoreDB();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier);
            return View(products.ToList());           
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);


            if (product == null)
            {
                return HttpNotFound();
            }


            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
            ViewBag.SuppliedId = new SelectList(db.Suppliers, "Id", "Company", product.SuppliedId);

            ProductViewModel pvm = new ProductViewModel();
            pvm.Product = product;



            return View(pvm);

            // return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            //////=== Approach A ====
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            ViewBag.SuppliedId = new SelectList(db.Suppliers, "Id", "Company");


            //////==Approach B ======

            ViewBag.SupplierList = db.Suppliers.ToList();

            return View();
        }


        //GET: Category/Create
        //public ActionResult Create()
        //{
        //    //ViewBag.Categoryist = GetCategoryList();
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
        //    ViewBag.SuppliedId = new SelectList(db.Suppliers, "Id", "Company");
        //    return View();
        //}

        //POST: Products/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ProductCode,ProductName,Description,StandardCost,ListPrice,QuantityPerUnit,Discountinue,SuppliedId,CategoryId")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Products.Add(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
        //    ViewBag.SuppliedId = new SelectList(db.Suppliers, "Id", "Company", product.SuppliedId);
        //    return View(product);
        //}
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
            ViewBag.SuppliedId = new SelectList(db.Suppliers, "Id", "Company", product.SuppliedId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
            ViewBag.SuppliedId = new SelectList(db.Suppliers, "Id", "Company", product.SuppliedId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductCode,ProductName,Description,StandardCost,ListPrice,QuantityPerUnit,Discountinue,SuppliedId,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
            ViewBag.SuppliedId = new SelectList(db.Suppliers, "Id", "Company", product.SuppliedId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private List<SelectListItem> GetSupplierList()
        //{
        //    var supplier = new List<SelectListItem>();
        //    supplier.Add(new SelectListItem() { Text = "--Select Supplier Name--", Value = "0"});
        //    supplier.Add(new SelectListItem() { Text = "California Dairies, Inc.", Value = "CD"});
        //    supplier.Add(new SelectListItem() { Text = "Cayuga Milk Ingredients", Value = "CI"});
        //    supplier.Add(new SelectListItem() { Text = "Hoogwegt U.S., Inc.", Value = "HI"});
        //    supplier.Add(new SelectListItem() { Text = "Cheerios - General Mills", Value = "CM"});
        //    supplier.Add(new SelectListItem() { Text = "ABCD XYZ", Value = "AX"});
        //    return supplier;
        //}








        //private List<SelectListItem> GetcategoryList()
        //{
        //    var category = new List<SelectListItem>();
        //    category.Add(new SelectListItem() { Text = "-- Select Category--", Value = "0" });
        //    category.Add(new SelectListItem() { Text = "Baked Goods and Mixes", Value = "Baked Goods and Mixes" });
        //    category.Add(new SelectListItem() { Text = " Beverages", Value = "Beverages" });
        //    category.Add(new SelectListItem() { Text = "Candy ", Value = "Candy" });
        //    category.Add(new SelectListItem() { Text = "Canned Fruit & Vegetables", Value = "Canned Fruit & Vegetables  " });
        //    category.Add(new SelectListItem() { Text = "Canned Meat ", Value = "Canned Meat " });
        //    category.Add(new SelectListItem() { Text = "Cereal", Value = "Cereal " });
        //    category.Add(new SelectListItem() { Text = "Chips", Value = "Chips " });
        //    category.Add(new SelectListItem() { Text = "Condiments", Value = "Condiments " });
        //    category.Add(new SelectListItem() { Text = "Dairy Fruits & Nuts", Value = "Dairy Fruits & Nuts " });
        //    category.Add(new SelectListItem() { Text = "Dairy Products", Value = "Dairy Products " });
        //    category.Add(new SelectListItem() { Text = "Grains", Value = "Grains" });
        //    category.Add(new SelectListItem() { Text = "Jams & Preserves", Value = "Jams & Preserves " });
        //    category.Add(new SelectListItem() { Text = "Oil", Value = "Oil " });
        //    category.Add(new SelectListItem() { Text = "Pasta", Value = "Pasta " });
        //    category.Add(new SelectListItem() { Text = "Sauces", Value = "Sauces " });
        //    category.Add(new SelectListItem() { Text = "Snacks", Value = "Snacks " });
        //    category.Add(new SelectListItem() { Text = "Soups", Value = "Soups " });
        //    return category;
        //}

    }
}

