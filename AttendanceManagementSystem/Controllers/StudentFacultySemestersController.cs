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
    public class StudentFacultySemestersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentFacultySemesters
        public ActionResult Index()
        {
            String sql = "SELECT * FROM faculties f, students co, semesters s, StudentFacultySemesters fsc where fsc.studentid  = co.studentid and f.facultyid = fsc.facultyid and s.semesterid = fsc.semesterid";
            db.List(sql);
            var dt = db.List(sql);
            var model = new StudentFacultySemester().List(dt);

            return View(model);
        }
    }
}
