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
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            String sql = "SELECT * FROM courses c";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt);

            return View(model);
        }


        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", null);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterName", null);

            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseVM model)
        {
            if (ModelState.IsValid)
            {
                //String sql = "Insert into Courses (CourseName, CourseCode, CreditHour) values ('" + course.CourseName + "', '" + course.CourseCode + "', '" + course.CreditHour + "')";

                //db.Create(sql);

                db.Courses.Add(model.Course);

                var facSemCouObj = new FacultySemesterCourse();
                facSemCouObj = new FacultySemesterCourse()
                {
                    FacultyID = model.FacultyID,
                    SemesterID = model.SemesterID,
                    CourseID = model.Course.CourseID
                };
                db.FacultySemesterCourses.Add(facSemCouObj);


                db.SaveChanges();


                return RedirectToAction("Index");
            }

            return View(model.Course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Course course = db.Courses.Find(id);

            CourseVM model = new CourseVM();
            model.Course = db.Courses.Find(id);
            var sfs = db.FacultySemesterCourses.Where(x => x.CourseID == id).FirstOrDefault();


            if (model.Course == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", null);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterName", null);
            return View(model);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseVM model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model.Course).State = EntityState.Modified;
                db.SaveChanges();

                //String sql = "Update Courses set CourseName = " + "'" + course.CourseName + "'" + ", CourseCode = " + "'" + course.CourseCode + "'" + ", CreditHour = " + "'" + course.CreditHour + "'" + " where CourseID = " + course.CourseID;
                //db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(model.Course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            String sql = "Delete From Courses where CourseID = " + course.CourseID;
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
