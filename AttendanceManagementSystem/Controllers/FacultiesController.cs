using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AttendanceManagementSystem.Models;

namespace AttendanceManagementSystem.Controllers
{

    [Authorize(Roles ="Admin, User")]
    public class FacultiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Faculties
        public ActionResult Index()
        {
            String sql = "SELECT * FROM faculties";
            //db.List(sql);

            //datable
            var dt = db.List(sql);

            //to list
            var model = new Faculty().List(dt);

            return View(model);
        }

        // GET: Faculties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultyID,FacultyName")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                String sql = "Insert into Faculties (FacultyName) values ('" + faculty.FacultyName + "')";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultyID,FacultyName")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                String sql = "Update Faculties set FacultyName = '" + faculty.FacultyName + "' where FacultyID = " + faculty.FacultyID;
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(faculty);
        }


        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            String sql = "Delete From Faculties where FacultyID = " + faculty.FacultyID;
            db.Delete(sql);
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
