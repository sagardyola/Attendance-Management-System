using AttendanceManagementSystem.Models;
using AttendanceManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace AttendanceManagementSystem.Controllers
{
    [Authorize]
    public class ReportEnrollmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnrollmentReport
        public ActionResult Index(int? CourseID)
        {
            EnrollmentReportVM modelVM = new EnrollmentReportVM();
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            
            String sql = "SELECT Distinct (s.StudentID), f.facultyName, sem.semesterName, s.name, s.email, s.contactNo, s.address, s.gender, s.dob, s.enrollmentdate FROM semesters sem, students s, studentfacultysemesters sfs, faculties f, facultysemestercourses fsc, courses c where s.studentId = sfs.studentId and f.facultyid = sfs.facultyid and sem.semesterID = sfs.semesterID and fsc.facultyid = f.facultyid and fsc.courseid = c.courseid and c.courseid = '" + CourseID + "' order by enrollmentdate";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);

            //return View(model);
            modelVM.Students = model;

            return View(modelVM);
        }
    }
}