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
    public class FacultySemesterCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FacultySemesterCourses
        public ActionResult Index()
        {
            String sql = "SELECT * FROM faculties f, Courses co, semesters s, facultysemestercourses fsc where fsc.courseid  = co.courseid and f.facultyid = fsc.facultyid and s.semesterid = fsc.semesterid";
            db.List(sql);
            var dt = db.List(sql);
            var model = new FacultySemesterCourse().List(dt);

            return View(model);
        }
    }
}
