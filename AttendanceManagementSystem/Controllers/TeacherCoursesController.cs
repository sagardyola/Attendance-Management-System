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
    public class TeacherCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherCourses
        public ActionResult Index()
        {
            String sql = "SELECT * FROM teachercourses f, Courses co, teachers s where f.courseid  = co.courseid and f.teacherid = s.teacherid";
            db.List(sql);
            var dt = db.List(sql);
            var model = new TeacherCourse().List(dt);

            return View(model);
        }

        // GET: TeacherCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName");
            return View();
        }

        // POST: TeacherCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherID,CourseID")] TeacherCourse teacherCourse)
        {
            if (ModelState.IsValid)
            {
                db.TeacherCourses.Add(teacherCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", teacherCourse.CourseID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", teacherCourse.TeacherID);
            return View(teacherCourse);
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
