using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AttendanceManagementSystem.Models;
using AttendanceManagementSystem.ViewModels;

namespace AttendanceManagementSystem.Controllers
{
    [Authorize]
    public class RoutinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Routines
        public ActionResult Index()
        {
            String sql = "SELECT * FROM classes c, Courses co, ClassTypes ct, Routines r " +
                "where c.classid  = r.classid and r.courseid = co.courseId and r.classtypeid = ct.classtypeid" +
                " order by day";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Routine().List(dt);

            return View(model);
        }

        // GET: Routines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = db.Routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }


        // GET: Routines/Create
        public ActionResult Create()
        {

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
            ViewBag.ClassTypeID = new SelectList(db.ClassTypes, "ClassTypeID", "ClassTypeName");
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            return View();
        }

        // POST: Routines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoutineID,CourseID,ClassID,ClassTypeID,Day,StartTime,EndTime")] Routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Routines.Add(routine);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", routine.ClassID);
            ViewBag.ClassTypeID = new SelectList(db.ClassTypes, "ClassTypeID", "ClassTypeName", routine.ClassTypeID);
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", routine.CourseID);
            return View(routine);
        }

        // GET: Routines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = db.Routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", routine.ClassID);
            ViewBag.ClassTypeID = new SelectList(db.ClassTypes, "ClassTypeID", "ClassTypeName");
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", routine.CourseID);
            return View(routine);
        }

        // POST: Routines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoutineID,CourseID,ClassID,ClassTypeID,Day,StartTime,EndTime")] Routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", routine.ClassID);
            ViewBag.ClassTypeID = new SelectList(db.ClassTypes, "ClassTypeID", "ClassTypeName");
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", routine.CourseID);
            return View(routine);
        }

        // POST: Routines/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Routine routine = db.Routines.Find(id);
            db.Routines.Remove(routine);
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
