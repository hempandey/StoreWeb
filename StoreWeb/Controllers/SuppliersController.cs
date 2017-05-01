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
    public class SuppliersController : Controller
    {
        private StoreDB db = new StoreDB();

        // GET: Suppliers
        public ActionResult Index()
        {
            
            return View(db.Suppliers.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }


        
        
        // GET: Suppliers/Create
        public ActionResult Create()
        {
            ViewBag.StateList = GetStateList();

            return View();
        }

        // POST: Suppliers/Create
       [HttpPost]
       //// [ValidateAntiForgeryToken]
        public JsonResult Create(Supplier supplier) {


            ////if (ModelState.IsValid)
            ////{
            ////    db.Suppliers.Add(supplier);
            ////    db.SaveChanges();
            ////    return RedirectToAction("Index");
            ////}
            ////var data = supplier;

            db.Suppliers.Add(supplier);
           var response= db.SaveChanges();


            var responseMessage = new
            {
                Success = true,
                Message = "Supplier information successfully saved."
            };



            return Json(responseMessage);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Company,FirstName,LastName,Email,BusinessPhone,HomePhone,MobilePhone,FaxNumber,Address,City,ddlState,ZipCode,Website,Note")] Supplier supplier)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Suppliers.Add(supplier);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(supplier);
        //}





        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
           
            ViewBag.StateId = new SelectList(GetStateList(), "Value", "Text", supplier.State);
            return View(supplier);
        }
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Supplier supplier = db.Suppliers.Find(id);
        //    if (supplier == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(supplier);
        //}


        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Company,FirstName,LastName,Email,BusinessPhone,HomePhone,MobilePhone,FaxNumber,Address,City,State,ZipCode,Website,Note")] Supplier supplier)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(supplier).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(supplier);
        //}

        public JsonResult Edit(Supplier supplier)
        {

            db.Entry(supplier).State = EntityState.Modified;
            db.SaveChanges();
            
            var responseMessage = new
            {
                Success = true,
                Message = "Supplier information successfully saved."
            };



            return Json(responseMessage);
        }



        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


      

        public ActionResult Save()
        {
            

            return View();
        }


        [HttpPost]
        public JsonResult SaveData(int acctNo, string name)
        {

            var a = acctNo;
            var b = name;

            return Json("Success");
        }




        private List<SelectListItem> GetStateList()
        {
            var states = new List<SelectListItem>();
            states.Add(new SelectListItem() { Text = "--Select State--", Value = "0" });
            states.Add(new SelectListItem() { Text = "Alabama", Value = "AL" });
            states.Add(new SelectListItem() { Text = "Alaska", Value = "AK" });
            states.Add(new SelectListItem() { Text = "Arizona", Value = "AZ" });
            states.Add(new SelectListItem() { Text = "Arkansas", Value = "AR" });
            states.Add(new SelectListItem() { Text = "California", Value = "CA" });
            states.Add(new SelectListItem() { Text = "Colorado", Value = "CO" });
            states.Add(new SelectListItem() { Text = "Connecticut", Value = "CT" });
            states.Add(new SelectListItem() { Text = "Delaware", Value = "DE" });
            states.Add(new SelectListItem() { Text = "Florida", Value = "FL" });
            states.Add(new SelectListItem() { Text = "Georgia", Value = "GA" });
            states.Add(new SelectListItem() { Text = "Hawaii", Value = "HI" });
            states.Add(new SelectListItem() { Text = "Idaho", Value = "ID" });
            states.Add(new SelectListItem() { Text = "Illinois", Value = "IL" });
            states.Add(new SelectListItem() { Text = "Indiana", Value = "IN" });
            states.Add(new SelectListItem() { Text = "Iowa", Value = "IA" });
            states.Add(new SelectListItem() { Text = "Kansas", Value = "KS" });
            states.Add(new SelectListItem() { Text = "Kentucky", Value = "KY" });
            states.Add(new SelectListItem() { Text = "Louisiana", Value = "LA" });
            states.Add(new SelectListItem() { Text = "Maine", Value = "ME" });
            states.Add(new SelectListItem() { Text = "Maryland", Value = "MD" });
            states.Add(new SelectListItem() { Text = "Massachusetts", Value = "MA" });
            states.Add(new SelectListItem() { Text = "Michigan", Value = "MI" });
            states.Add(new SelectListItem() { Text = "Minnesota", Value = "MN" });
            states.Add(new SelectListItem() { Text = "Mississippi", Value = "MS" });
            states.Add(new SelectListItem() { Text = "Missouri", Value = "MO" });
            states.Add(new SelectListItem() { Text = "Montana", Value = "MT" });
            states.Add(new SelectListItem() { Text = "Nebraska", Value = "NE" });
            states.Add(new SelectListItem() { Text = "Nevada", Value = "NV" });
            states.Add(new SelectListItem() { Text = "New Hampshire", Value = "NH" });
            states.Add(new SelectListItem() { Text = "New Jersey", Value = "NJ" });
            states.Add(new SelectListItem() { Text = "New Mexico", Value = "NM" });
            states.Add(new SelectListItem() { Text = "New York", Value = "NY" });
            states.Add(new SelectListItem() { Text = "North Carolina", Value = "NC" });
            states.Add(new SelectListItem() { Text = "North Dakota", Value = "ND" });
            states.Add(new SelectListItem() { Text = "Ohio", Value = "OH" });
            states.Add(new SelectListItem() { Text = "Oklahoma", Value = "OK" });
            states.Add(new SelectListItem() { Text = "Oregon", Value = "OR" });
            states.Add(new SelectListItem() { Text = "Pennsylvania", Value = "PA" });
            states.Add(new SelectListItem() { Text = "Rhode Island", Value = "RI" });
            states.Add(new SelectListItem() { Text = "South Carolina", Value = "SC" });
            states.Add(new SelectListItem() { Text = "South Dakota", Value = "SD" });
            states.Add(new SelectListItem() { Text = "Tennessee", Value = "TN" });
            states.Add(new SelectListItem() { Text = "Texas", Value = "TX" });
            states.Add(new SelectListItem() { Text = "Utah", Value = "UT" });
            states.Add(new SelectListItem() { Text = "Vermont", Value = "VT" });
            states.Add(new SelectListItem() { Text = "Virginia", Value = "VA" });
            states.Add(new SelectListItem() { Text = "Washington", Value = "WA" });
            states.Add(new SelectListItem() { Text = "West Virginia", Value = "WV" });
            states.Add(new SelectListItem() { Text = "Wisconsin", Value = "WI" });
            states.Add(new SelectListItem() { Text = "Wyoming", Value = "WY" });
            return states;
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
