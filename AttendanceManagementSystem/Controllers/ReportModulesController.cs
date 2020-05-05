using AttendanceManagementSystem.Models;
using AttendanceManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceManagementSystem.Controllers
{
    [Authorize]
    public class ReportModulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExploreModules
        public ActionResult Index(int? CourseID, int? SemesterID)
        {
            //ExploreModulesVM modelVM = new ExploreModulesVM();
            //ViewBag.TeacherTypeID = new SelectList(db.TeacherTypes, "TeacherTypeID", "TypeName");
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterName");

            String sql = "SELECT Distinct (t.TeacherID), t.teacherName, s.semesterName, c.CourseName, tt.TypeName " +
                "FROM teachers t, teachertypes tt, teachercourses tc, courses c, facultysemesterCourses fsc, semesters s " +
                "where t.TeacherTypeID = tt.TeacherTypeID and t.teacherId = tc.teacherId and tc.courseId = c.courseId and c.courseId = fsc.courseId and fsc.semesterid = s.semesterid" +
                " and c.CourseID = '" + CourseID +"' and s.semesterid = '"+ SemesterID + "' order by t.teacherName";
            //db.List(sql);
            var dt = db.List(sql);
            var model = new ExploreModulesVM().List(dt);


            ViewBag.Explore = model;

            return View();
        }
    }
}