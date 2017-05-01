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
    public class ResponseMessage
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class CategoriesController : Controller
    {
        private StoreDB db = new StoreDB();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }



        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,CategoryName")] Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Categories.Add(category);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(category);
        //}


        //[HttpPost]
        //public JsonResult SaveCategoryData(string CategoryName)
        //{
            
        //        var a = CategoryName;
     

        //    return Json("Success");
        //}


        [HttpPost]
        public JsonResult SaveCategoryData(Category category)
        {
            ResponseMessage responseMessage;
            if (!string.IsNullOrEmpty(category.CategoryName))
            {
                var checkCategory = db.Categories.Where(c => c.CategoryName == category.CategoryName).ToList();

                if (checkCategory.Count==0)
                {
                    db.Categories.Add(category);
                    var response = db.SaveChanges();
                    responseMessage = new ResponseMessage()
                    {
                        Success = true,
                        Message = "Category information successfully saved."
                    };

                }
                else
                {
                    responseMessage = new ResponseMessage()
                    {
                        Success = false,
                        Message = "Category "+ category.CategoryName + " already exists in database."
                    };
                }       
                return Json(responseMessage);

            }
            else
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Category name is empty"
                };
                return Json(responseMessage);
            }
            
        }



        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,CategoryName")] Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(category).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
        //}


        [HttpPost]
        public JsonResult Edit(Category category)
        {
            ResponseMessage responseMessage;

            if (category.Id != 0 && !string.IsNullOrEmpty(category.CategoryName))
            {
                var checkCategory = db.Categories.Where(c => c.CategoryName == category.CategoryName).ToList();
                if (checkCategory.Count == 0)
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();

                    responseMessage = new ResponseMessage()
                    {
                        Success = true,
                        Message = "Category information successfully updated."
                    };

                }
                else
                {
                    responseMessage = new ResponseMessage()
                    {
                        Success = false,
                        Message = "Category "+ category.CategoryName + " already exists in database."
                    };
                }

            }
            else
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Please provide category information properly"
                };
            }           
            

            return Json(responseMessage);
        }


        //GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

    

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
