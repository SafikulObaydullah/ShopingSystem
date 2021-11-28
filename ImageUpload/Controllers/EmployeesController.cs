using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImageUpload.Models;

namespace ImageUpload.Controllers
{
    public class EmployeesController : Controller
    {
 public  dbImageModel db = new dbImageModel();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());
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

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DeptID = new SelectList(db.Departments, "ID", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,DOB,DeptID")] Employee employee , HttpPostedFileBase Pic)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                try
                {
                    if (Pic != null)
                    {
                        string fPath = Path.Combine(Server.MapPath("~/"), "EmployeeImages");
                        if (!Directory.Exists(fPath))
                        {
                            Directory.CreateDirectory(fPath);
                        }
                        string fName = Pic.FileName;
                        string fExt = Path.GetExtension(fName).ToLower();
                        if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png")
                        {
                            Pic.SaveAs(Path.Combine(fPath, fName));
                            employee.PicturePath = "~/EmployeeImages/" + fName;
                            db.Employees.Add(employee);
                            if (db.SaveChanges() > 0)
                            {
                                return RedirectToAction("Index");
                            }
                        }
                        else
                        {
                            msg = "Please provide jpeg,jpg,png format file";
                        }


                    }
                    else
                    {
                        msg = "Please provide valid Annotation";
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                //return RedirectToAction("Index");
            }
            ModelState.AddModelError("", msg);
            ViewBag.DeptID = new SelectList(db.Departments, "ID", "ShortName", employee.DeptID);
            return View(employee);
        }
        [HttpGet]
        

        // GET: Employees/Edit/5
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
            ViewBag.DeptID = new SelectList(db.Departments, "ID", "ShortName", employee.DeptID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,DOB,DeptID,PicturePath")] Employee employee,HttpPostedFileBase Pic )
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                if (Pic != null)
                {
                    string fPath = Path.Combine(Server.MapPath("~/"), "EmployeeImages");
                    if (!Directory.Exists(fPath))
                    {
                        Directory.CreateDirectory(fPath);
                    }
                    string fName = Pic.FileName;
                    string fExt = Path.GetExtension(fName).ToLower();
                    if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png")
                    {
                        Pic.SaveAs(Path.Combine(fPath, fName));
                        employee.PicturePath = "~/EmployeeImages/" + fName;


                        //db.Employees.Add(employee);
                        //if (db.SaveChanges() > 0)
                        //{
                        //    return RedirectToAction("Index");
                        //}
                    }
                    else
                    {
                        msg = "Please provide jpeg,jpg,png format file";
                    }


                }
                else
                {
                    if(employee !=null)
                    {
                        employee.PicturePath = employee.PicturePath;
                    }
                    else
                    {
                        msg = "Please provide valid Annotation";
                    }
                   

                }

                db.Entry(employee).State = EntityState.Modified;
                if(db.SaveChanges() > 0)
                     return RedirectToAction("Index");
                else
                    return View(employee);
            }
            ModelState.AddModelError("", msg);
            ViewBag.DeptID = new SelectList(db.Departments, "ID", "Name", employee.DeptID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
