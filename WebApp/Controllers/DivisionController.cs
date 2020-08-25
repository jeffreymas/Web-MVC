using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Contexts;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DivisionController : Controller
    {
        // GET: Division
        MyContext myCon = new MyContext();
        // GET: Department
        public ActionResult Index()
        {
            var division = myCon.Division.Include("Department");
            return View(division.ToList());
        }
        public ActionResult Details(int id)
        {
            Division divisi = myCon.Division.Find(id);
            return View(divisi);
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            ViewBag.id_depart = new SelectList(myCon.Department, "id", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Division division)
        {
            try
            {
                // TODO: Add insert logic here
                myCon.Division.Add(division);
                myCon.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Divisions", "Create"));
            }
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int id)
        {
            if (id.Equals(null))
            {
                return HttpNotFound();
            }
            Division divisi = myCon.Division.Find(id);
            ViewBag.id_depart = new SelectList(myCon.Department, "id", "name", divisi.id_depart);
            return View(divisi);
        }

        // POST: Tests/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Division division)
        {
            try
            {
                // TODO: Add update logic here
                var edit = myCon.Division.Find(id);
                if (ModelState.IsValid)
                {
                    edit.Id = division.Id;
                    edit.Name = division.Name;
                    edit.id_depart = division.id_depart;
                    myCon.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Divisions", "Edit"));
            }
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int id)
        {
            Division divisi = myCon.Division.Find(id);
            if (divisi == null)
            {
                return HttpNotFound();
            }
            return View(divisi);
        }

        // POST: Tests/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Division division)
        {
            try
            {
                // TODO: Add delete logic here
                var del = myCon.Division.Find(id);
                myCon.Division.Remove(del);
                myCon.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Divisions", "Edit"));
            }
        }
    }
}