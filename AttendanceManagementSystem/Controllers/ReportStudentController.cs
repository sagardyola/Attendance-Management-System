using AttendanceManagementSystem.Models;
using AttendanceManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceManagementSystem.Controllers
{
    [Authorize]
    public class ReportStudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExploreStudentReport
        public ActionResult DailyReport(DateTime? Date)
        {
            ExploreStudentReportVM modelVM = new ExploreStudentReportVM();

            if (Date != null)
            {
               

                String sql = "Select s.Name, a.Date, a.Status from Students s, Attendances a where s.StudentID = a.StudentID and a.Date =" +
                    "'" + Date + "'";

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


        public ActionResult WeeklyReport(DateTime? Date)
        {
            ExploreStudentReportVM modelVM = new ExploreStudentReportVM();

            if(Date != null)
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
                    "between '"+startDateOfWeek+"' and '" +endDateOfWeek+"'";

                var dt = db.List(sql);
                var model = new ExploreStudentReportVM().List(dt);
                ViewBag.Explore = model;

            } else
            {
               
                ViewBag.Explore = "";

            }

            //modelVM.Date = Convert.ToDateTime(Date);

            return View();

        }



        public ActionResult MonthlyReport(DateTime? Date)
        {
            ExploreStudentReportVM modelVM = new ExploreStudentReportVM();

            if (Date != null)
            {
                String sql = "Select s.Name, a.Date, a.Status from Students s, Attendances a where s.StudentID = a.StudentID and month(a.Date) =" +
                    " month('" + Date + "') and year(a.Date) =" + " year('" + Date + "')";

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


    }
}