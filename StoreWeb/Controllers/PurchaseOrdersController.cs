using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreWeb;

namespace StoreWeb.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private StoreDB db = new StoreDB();

        // GET: PurchaseOrders
        public ActionResult Index()
        {
            var purchaseOrders = db.PurchaseOrders.Include(p => p.Employee).Include(p => p.OrderStatu).Include(p => p.Supplier);
            return View(purchaseOrders.ToList());
        }

        // GET: PurchaseOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public ActionResult Create()
        {
            //ViewBag.PurchaseId = new SelectList(db.PurchaseOrders, "Id", "Supplier");
            //ViewBag.CreatedBy = new SelectList(db.Employees, "Id", "FirstName");


            
            var supplierListForDdl = new List<SelectListItem>();
            supplierListForDdl.Add(new SelectListItem() { Text = "", Value = "0" });
            foreach (var item in db.Suppliers.ToList())
            {
                supplierListForDdl.Add(new SelectListItem() { Text = item.Company, Value = Convert.ToString(item.Id) });
            }
            ViewBag.SupplierList = supplierListForDdl;


            var employeeListForDdl= new List<SelectListItem>();
            employeeListForDdl.Add(new SelectListItem() { Text = "", Value = "0" });
            foreach (var item in db.Employees.ToList())
            {
                employeeListForDdl.Add(new SelectListItem() { Text = item.FirstName, Value = Convert.ToString(item.Id) });
            }
            ViewBag.EmployeeList = employeeListForDdl;
            
            return View();
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderDate,SuppplierId,CreatedBy,CreatedDate,ExpectedDate,ShippingFee,Taxes,PaymentDate,PaymentAmount,PaymentMethod,Notes,OrderSubTotal,OrderTotal,SubmittedBy,SubmittedDate,ClosedBy,ClosedDate,IsCompleted,IsSubmitted,IsNew,OrderStatusId")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.Employees, "Id", "FirstName", purchaseOrder.CreatedBy);
            ViewBag.OrderStatusId = new SelectList(db.OrderStatus, "Id", "Status", purchaseOrder.OrderStatusId);
            ViewBag.SuppplierId = new SelectList(db.Suppliers, "Id", "Company", purchaseOrder.SuppplierId);
            return View(purchaseOrder);
        }


        public ActionResult GetProductListBySupplier(int? suppliedId)
        {
            ResponseMessage responseMessage;
            if (suppliedId == null || suppliedId==0)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Supplier ID is not provided"
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);

            }
            var productList = db.Products.Where(p => p.SuppliedId == suppliedId).ToList();
            
            ViewBag.ProductList = new SelectList(productList, "Id", "ProductName"); 

            responseMessage = new ResponseMessage()
            {
                Success = true,
                Message = "Success"
            };

            return Json(responseMessage, JsonRequestBehavior.AllowGet);
        }

        // GET: PurchaseOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.Employees, "Id", "FirstName", purchaseOrder.CreatedBy);
            ViewBag.OrderStatusId = new SelectList(db.OrderStatus, "Id", "Status", purchaseOrder.OrderStatusId);
            ViewBag.SuppplierId = new SelectList(db.Suppliers, "Id", "Company", purchaseOrder.SuppplierId);
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderDate,SuppplierId,CreatedBy,CreatedDate,ExpectedDate,ShippingFee,Taxes,PaymentDate,PaymentAmount,PaymentMethod,Notes,OrderSubTotal,OrderTotal,SubmittedBy,SubmittedDate,ClosedBy,ClosedDate,IsCompleted,IsSubmitted,IsNew,OrderStatusId")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.Employees, "Id", "FirstName", purchaseOrder.CreatedBy);
            ViewBag.OrderStatusId = new SelectList(db.OrderStatus, "Id", "Status", purchaseOrder.OrderStatusId);
            ViewBag.SuppplierId = new SelectList(db.Suppliers, "Id", "Company", purchaseOrder.SuppplierId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            db.PurchaseOrders.Remove(purchaseOrder);
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
    }
}
