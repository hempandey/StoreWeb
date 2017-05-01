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
    public class EmployeesController : Controller
    {
        private StoreDB db = new StoreDB();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

   
        public ActionResult Create()
        {
           

            return View();
        }

        
        //POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            //validation for firsat name, email, login-this validation will make sure textbox is not null 

            ResponseMessage responseMessage;
            if (string.IsNullOrEmpty(employee.FirstName))
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "First Name is required."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrEmpty(employee.Email))
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Email Name is required."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrEmpty(employee.Login))
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Login Name is required."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }





            //validation as will - this validation will look duplicate data. such as same email or login 
            //id can not be created again 

            var checkLogin = db.Employees.Where(e => e.Login == employee.Login).ToList();
            var checkEmail = db.Employees.Where(e => e.Email == employee.Email).ToList();

            if (checkLogin.Count != 0)
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Login " + employee.Login + " already exists."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }
            if (checkEmail.Count != 0)
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Email " + employee.Email + " already exists."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }
            // lastly, if all the validaion parts done/checked successfully, call will go to success block cotherwise error.
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                responseMessage = new ResponseMessage()
                {
                    Success = true,
                    Message = "Employee information successfully saved."
                };

            }
            catch (Exception)
            {

                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Something went wrong."
                };
            }

            return Json(responseMessage, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }


        

        
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            //validation for firsat name, email, login-this validation will make sure textbox is not null 
            ResponseMessage responseMessage;


            if (employee.Id<=0)
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Employee id is empty."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(employee.FirstName))
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "First Name is required."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrEmpty(employee.Email))
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Email Name is required."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrEmpty(employee.Login))
            {
                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Login Name is required."
                };
                return Json(responseMessage, JsonRequestBehavior.AllowGet);
            }

            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();

                responseMessage = new ResponseMessage()
                {
                    Success = true,
                    Message = "Done"
                };
            }
            catch (Exception)
            {

                responseMessage = new ResponseMessage()
                {
                    Success = false,
                    Message = "Something went wrong."
                };
            }

            return Json(responseMessage, JsonRequestBehavior.AllowGet);
        }




        ////// GET: Employees/Delete/5
        ////public ActionResult Delete(int? id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    Employee employee = db.Employees.Find(id);
        ////    if (employee == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(employee);
        ////}

        ////// POST: Employees/Delete/5
        ////[HttpPost, ActionName("Delete")]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult DeleteConfirmed(int id)
        ////{
        ////    Employee employee = db.Employees.Find(id);
        ////    db.Employees.Remove(employee);
        ////    db.SaveChanges();
        ////    return RedirectToAction("Index");
        ////}

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
