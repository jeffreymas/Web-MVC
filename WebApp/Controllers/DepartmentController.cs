using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Contexts;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        MyContext myCon = new MyContext();
        // GET: Department
        public ActionResult Index()
        {
            return View(myCon.Department.ToList());
        }
        public ActionResult Details(int id)
        {
            return View(myCon.Department.Find(id));
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            try
            {
                // TODO: Add insert logic here
                var input = myCon.Department.Add(department);
                myCon.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int id)
        {
            return View(myCon.Department.Find(id));
        }

        // POST: Tests/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            try
            {
                // TODO: Add update logic here
                var edit = myCon.Department.Find(id);
                edit.name = department.name;
                myCon.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int id)
        {
            return View(myCon.Department.Find(id));
        }

        // POST: Tests/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Department department)
        {
            try
            {
                // TODO: Add delete logic here
                var delete = myCon.Department.Find(id);
                myCon.Department.Remove(delete);
                myCon.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}