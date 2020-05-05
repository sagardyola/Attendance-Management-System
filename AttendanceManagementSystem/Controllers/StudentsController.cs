using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AttendanceManagementSystem.Models;
using AttendanceManagementSystem.ViewModels;

namespace AttendanceManagementSystem.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            String sql = "Select s.*, sem.SemesterName, f.FacultyName from Students s, Semesters sem, Faculties f, StudentFacultySemesters sfs where s.StudentID = sfs.StudentID and sfs.FacultyID = f.FacultyID and sem.SemesterID = sfs.SemesterID ";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);

            return View(model);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {

            String sql = "Select s.*, sem.SemesterName, f.FacultyName from Students s, Semesters sem, Faculties f, StudentFacultySemesters sfs where s.StudentID = sfs.StudentID and sfs.FacultyID = f.FacultyID and sem.SemesterID = sfs.SemesterID and s.studentid = '" + id + "'";
            //db.Find(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);

            return View(model);
        }

        // GET: Students/Create
        public ActionResult Create(int? FacultyID, int? SemesterID)
        {
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", null);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterName", null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentVM studentVMObj)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(studentVMObj.Student);

                var stdFacSemObj = new StudentFacultySemester();
                stdFacSemObj = new StudentFacultySemester()
                {
                    StudentID = studentVMObj.Student.StudentID,
                    FacultyID = studentVMObj.FacultyID,
                    SemesterID = studentVMObj.SemesterID
                };
                db.StudentFacultySemesters.Add(stdFacSemObj);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(studentVMObj.Student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            StudentVM model = new StudentVM();
            model.Student = db.Students.Find(id);
            var sfs = db.StudentFacultySemesters.Where(x => x.StudentID == id).FirstOrDefault();

            if (model.Student == null)
            {
                return HttpNotFound();
            }

            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", null);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterName", null);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentVM model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model.Student).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult WeeklyReport(DateTime? Date, int id)
        {
            ExploreStudentReportVM modelVM = new ExploreStudentReportVM();

            if (Date != null)
            {
                //get current datetime 
                DateTime date = (DateTime)Date;

                //get year from the date
                int year = date.Date.Year;

                //set the first day of the year
                DateTime firstDay = new DateTime(year, 1, 1);

                //get Day of the week 
                DayOfWeek day = date.DayOfWeek;

                CultureInfo cul = CultureInfo.CurrentCulture;

                //get no of week for the date
                int weekNo = cul.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                //get no of day
                int days = (weekNo - 1) * 7;
                DateTime dt1 = firstDay.AddDays(days);
                DayOfWeek dow = dt1.DayOfWeek;
                DateTime startDateOfWeek = dt1.AddDays(-(int)dow);
                DateTime endDateOfWeek = startDateOfWeek.AddDays(6);

                String sql = "Select s.Name, a.Date, a.Status from Students s, Attendances a where s.StudentID = a.StudentID and a.Date " +
                    "between '" + startDateOfWeek + "' and '" + endDateOfWeek + "' and s.studentid = '"+id + "'";

                var dt = db.List(sql);
                var model = new ExploreStudentReportVM().List(dt);
                ViewBag.Explore = model;
            }
            else
            {
                ViewBag.Explore = "";
            }

            return View();

        }



        public ActionResult MonthlyReport(DateTime? Date, int id)
        {
            ExploreStudentReportVM modelVM = new ExploreStudentReportVM();

            if (Date != null)
            {
                String sql = "Select s.Name, a.Date, a.Status from Students s, Attendances a where s.StudentID = a.StudentID and month(a.Date) =" +
                    " month('" + Date + "') and year(a.Date) =" + " year('" + Date + "') and s.StudentID = '"+id+"'";

                var dt = db.List(sql);
                var model = new ExploreStudentReportVM().List(dt);
                ViewBag.Explore = model;

            }
            else
            {
                ViewBag.Explore = "";
            }

            return View();

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
