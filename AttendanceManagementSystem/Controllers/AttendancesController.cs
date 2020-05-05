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
    public class AttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attendances
        public ActionResult Index(int? RoutineID)
        {

            var chkDay = db.Routines.AsEnumerable().Where(x => x.Day.Equals(Convert.ToString(DateTime.Now.DayOfWeek)));


            ViewBag.RoutineID = new SelectList(chkDay, "RoutineID", "CourseClass");

            String sql = "select * from students std" +
                " join StudentFacultySemesters sfs on std.StudentID = sfs.StudentID" +
                " join Semesters sem on sem.SemesterID = sfs.SemesterID" +
                " join FacultySemesterCourses fsc on fsc.SemesterID = sem.SemesterID" +
                " join Faculties f on f.FacultyID = fsc.FacultyID" +
                " and f.FacultyID = sfs.FacultyID" +
                " join Courses c on c.CourseID = fsc.CourseID" +
                " join Routines r on r.CourseID = c.CourseID" +
                //" and r.Day = (SELECT DATENAME(WEEKDAY,GETDATE()))" +
                " and RoutineID = '" + RoutineID + "'";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);

            //modelVM.Students = model;

            ViewBag.Students = model;


            return View();

        }



        [HttpPost]
        public ActionResult Index(Attendance attendance)
        {
            
            var startTime = db.Attendances.Where(x => x.RoutineID == attendance.RoutineID).Select(x => x.Routine.StartTime).FirstOrDefault();
            var entryTime =(attendance.EntryTime).ToString("HH:mm tt");
            if (attendance.EntryTime.ToString() == "1/1/0001 12:00:00 AM") {
                attendance.EntryTime = Convert.ToDateTime("1/1/2022 12:00:00 PM");
            }
            var st = startTime.ToString("HH:mm tt");
            var diff = (DateTime.Parse(entryTime) - DateTime.Parse(st)).TotalMinutes;
            if (attendance.EntryTime.ToString() == "1/1/2022 12:00:00 PM") {
                attendance.Status = "A";
            }

            else if (diff>5)
            {
                attendance.Status = "L";
            }else if (diff <= 5)
            {
                attendance.Status = "P";
            }
          
            ViewBag.RoutineID = new SelectList(db.Routines, "RoutineID", "CourseClass");
            
            db.Attendances.Add(attendance);
            db.SaveChanges();
            return View();
        }
    }
}
