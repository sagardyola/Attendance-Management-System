using AttendanceManagementSystem.Models;
using AttendanceManagementSystem.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.User = user;
            HomeVM model = new HomeVM();
            model = new HomeVM()
            {
                CountFaculties = db.Faculties.Count(),
                CountCourse = db.Courses.Count(),
                CountTeacher = db.Teachers.Count(),
                CountStudent = db.Students.Count(),
                CountPresent = db.Attendances.AsEnumerable().Where(x => x.Status == "P").Select(x => x.StudentID).Count(),
                CountLate = db.Attendances.AsEnumerable().Where(x => x.Status == "L").Select(x => x.StudentID).Count(),
                CountAbsent = db.Attendances.AsEnumerable().Where(x => x.Status == "A").Select(x => x.StudentID).Count(),

                CountNet = db.StudentFacultySemesters.Where(x => x.FacultyID == 1).Select(x => x.Student).Count(),
                CountMgm = db.StudentFacultySemesters.Where(x => x.FacultyID == 2).Select(x => x.Student).Count(),
                CountCom = db.StudentFacultySemesters.Where(x => x.FacultyID == 3).Select(x => x.Student).Count(),
                CountMul = db.StudentFacultySemesters.Where(x => x.FacultyID == 4).Select(x => x.Student).Count()
            };


 




            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}