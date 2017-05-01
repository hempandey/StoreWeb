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
    public class ShippingCompaniesController : Controller
    {
        private StoreDB db = new StoreDB();

        // GET: ShippingCompanies
        public ActionResult Index()
        {
            return View(db.ShippingCompanies.ToList());
        }

        // GET: ShippingCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingCompany shippingCompany = db.ShippingCompanies.Find(id);
            if (shippingCompany == null)
            {
                return HttpNotFound();
            }
            return View(shippingCompany);
        }

        // GET: ShippingCompanies/Create=====================.========================================
        public ActionResult Create()
        {

            ViewBag.StateList = GetStateList();
            return View();
        }

        // POST: ShippingCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Company,ContactPerson,Email,BusinessPhone,Fax,Address,Address2,City,State,ZipCode,Web,Note")] ShippingCompany shippingCompany)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ShippingCompanies.Add(shippingCompany);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(shippingCompany);
        //}


        [HttpPost]
        //// [ValidateAntiForgeryToken]
        public JsonResult Create(ShippingCompany shippingCompany)
        {

            ResponseMessage responseMessage;
            if (string.IsNullOrEmpty(shippingCompany.Company))
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Company is required."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(shippingCompany.Email))
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Email is required."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }


            var checkCompany = db.ShippingCompanies.Where(e => e.Company == shippingCompany.Company).ToList();
            var checkEmail = db.ShippingCompanies.Where(e => e.Email == shippingCompany.Email).ToList();

            if (checkCompany.Count != 0)
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Company " + shippingCompany.Company + " already exists."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }
            if (checkEmail.Count != 0)
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Email " + shippingCompany.Email + " already exists."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }

            try
            {
                db.ShippingCompanies.Add(shippingCompany);
                //var response = db.SaveChanges();
                db.SaveChanges();
                responseMessage = new ResponseMessage()
                {
                    Success = true,
                    Message = "Shipping Company information successfully saved."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                var a = ex;
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message ="Error: "+ ex.Message
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }
            
           
        }



        // GET: ShippingCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingCompany shippingCompany = db.ShippingCompanies.Find(id);

            ViewBag.State = new SelectList(GetStateList(), "Value", "Text", shippingCompany.State);
            if (shippingCompany == null)
            {
                return HttpNotFound();
            }
            return View(shippingCompany);
        }

        // POST: ShippingCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit( ShippingCompany shippingCompany)
        {

            ResponseMessage responseMessage;
            if (ModelState.IsValid)
            {

                try
                {
                    db.Entry(shippingCompany).State = EntityState.Modified;
                    db.SaveChanges();
              
                    
                }
                catch (Exception ex)
                {

                   responseMessage = new ResponseMessage()
                    {
                        Success = false,
                        Message = "Error : "+ex.Message
                    };
                    return Json(responseMessage, JsonRequestBehavior.AllowGet);
                }

                

            }

            responseMessage = new ResponseMessage()
            {
                Success = true,
                Message = "Shipping Company information successfully saved."
            };
            return Json(responseMessage, JsonRequestBehavior.AllowGet);
        }

        // GET: ShippingCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingCompany shippingCompany = db.ShippingCompanies.Find(id);
            if (shippingCompany == null)
            {
                return HttpNotFound();
            }
            return View(shippingCompany);
        }

        // POST: ShippingCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingCompany shippingCompany = db.ShippingCompanies.Find(id);
            db.ShippingCompanies.Remove(shippingCompany);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult ViewData()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult SaveData(Contractor contractor)
        {

            //var a = Name;
            //var b = Email;
            //var c = State;
            //var d = Married;
            //var e = Gender;
            //var f = Skills;
            ViewBag.StateList = GetStateList();

            // save data into database



            return Json("success", JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult SaveData(int Name, string Email, string State, bool Married, string Gender, string Skills)
        //{

        //    var a = Name;
        //    var b = Email;
        //    var c = State;
        //    var d = Married;
        //    var e = Gender;
        //    var f = Skills; 
        //    ViewBag.StateList = GetStateList();

        //    // save data into database



        //    return Json("success", JsonRequestBehavior.AllowGet);
        //}






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


    public class Contractor
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public bool Married { get; set; }
        public string Gender { get; set; }
        public string Skills { get; set; }
    }

  
}
