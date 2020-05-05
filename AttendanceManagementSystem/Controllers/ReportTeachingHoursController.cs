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
    public class ReportTeachingHoursController : Controller
    {
        // GET: ExploreTeachingHours
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? SemesterID)
        {

            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterName");

            String sql = " SELECT t.TeacherName, c.CourseName, t.Phone, t.Email, t.TeachingHours ,(sum (DATEDIFF(minute, r.starttime, r.EndTime))/60) as TeachHours, tt.TypeName  , t.TeachingHours " +
                "FROM teachers t join teachertypes tt on t.TeacherTypeID = tt.TeacherTypeID " +

                " join teachercourses tc on tc.TeacherID = t.TeacherID " +

               " join Courses c on c.CourseID = tc.CourseID or c.courseID = tc.CourseID" +

               " join FacultySemesterCourses fsc on fsc.CourseID = c.CourseID " +

                "join semesters s on s.SemesterID = fsc.SemesterID " +

                "join Faculties f on f.FacultyID = fsc.FacultyID " +

                "join Routines r on c.CourseID = r.CourseID " +
                " group by t.TeacherName, t.Phone, t.Email, t.TeachingHours, s.SemesterID, tt.typename, s.SemesterID, c.CourseName having " +
                "s.semesterid = '" + SemesterID + "'" + " order by TeachHours";

            var dt = db.List(sql);
            var model = new ExploreTeachingHoursVM().List(dt);

            ViewBag.Explore = model;

            return View();
        }
    }
}