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
    [Authorize]
    public class SemestersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Semesters
        public ActionResult Index()
        {
            String sql = "SELECT * FROM Semesters";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Semester().List(dt);

            return View(model);
        }

        // GET: Semesters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemesterID,SemesterName")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                String sql = "Insert into Semesters (SemesterName) values ('" + semester.SemesterName + "')";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            return View(semester);
        }

        // GET: Semesters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        // POST: Semesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemesterID,SemesterName")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                String sql = "Update Semesters set SemesterName = '" + semester.SemesterName + "' where SemesterID = " + semester.SemesterID;
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(semester);
        }

        // POST: Semesters/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Semester semester = db.Semesters.Find(id);
            String sql = "Delete From Semesters where SemesterID = " + semester.SemesterID;
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
