using AttendanceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.ViewModels
{
    public class EnrollmentReportVM
    {
        public int CourseID { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }
    }

    public class ExploreModulesVM
    {
        List<ExploreModulesVM> list = new List<ExploreModulesVM>();
        public ExploreModulesVM() { }
        public List<ExploreModulesVM> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ExploreModulesVM exploreObj = new ExploreModulesVM();
                exploreObj.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                exploreObj.CourseName = dt.Rows[i]["CourseName"].ToString();
                exploreObj.SemesterName = dt.Rows[i]["SemesterName"].ToString();
                exploreObj.TypeName = dt.Rows[i]["TypeName"].ToString();

                list.Add(exploreObj);
            }
            return list;
        }

        //public int TeacherTypeID { get; set; }
        public int CourseID { get; set; }
        public int SemesterID { get; set; }

        public string TeacherName { get; set; }
        public string CourseName { get; set; }
        public string TypeName { get; set; }
        public string SemesterName { get; set; }

        public virtual IEnumerable<TeacherType> TeacherTypes { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }
        public virtual IEnumerable<Semester> Semesters { get; set; }
    }



    public class ExploreTeachingHoursVM
    {
        List<ExploreTeachingHoursVM> list = new List<ExploreTeachingHoursVM>();
        public ExploreTeachingHoursVM() { }
        public List<ExploreTeachingHoursVM> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ExploreTeachingHoursVM exploreObj = new ExploreTeachingHoursVM();
                exploreObj.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                exploreObj.Phone = dt.Rows[i]["Phone"].ToString();
                exploreObj.Email = dt.Rows[i]["Email"].ToString();
                exploreObj.CourseName = dt.Rows[i]["CourseName"].ToString();
                exploreObj.TeachingHours = Convert.ToInt32(dt.Rows[i]["TeachingHours"]);

                list.Add(exploreObj);
            }
            return list;
        }

        public int SemesterID { get; set; }

        public int TeachingHours { get; set; }

        public string TeacherName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CourseName { get; set; }
    }




    public class ExploreStudentReportVM
    {

        List<ExploreStudentReportVM> list = new List<ExploreStudentReportVM>();
        public ExploreStudentReportVM() { }
        public List<ExploreStudentReportVM> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ExploreStudentReportVM exploreObj = new ExploreStudentReportVM();
                exploreObj.Name = dt.Rows[i]["Name"].ToString();
                exploreObj.Date = Convert.ToDateTime(dt.Rows[i]["Date"]);
                exploreObj.Status = dt.Rows[i]["Status"].ToString();

                list.Add(exploreObj);
            }
            return list;
        }



        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Status { get; set; }



        public int StudentID { get; set; }

        public IEnumerable<Attendance> Attendances { get; set; }
        public IEnumerable<Student> Student { get; set; }
        //public ICollection<Routine> Routines { get; set; }
    }
}