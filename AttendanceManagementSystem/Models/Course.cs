using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class Course
    {
        List<Course> list = new List<Course>();
        public Course() { }
        public List<Course> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Course courseObj = new Course();
                courseObj.CourseID = Convert.ToInt32(dt.Rows[i]["CourseID"]);
                courseObj.CourseName = dt.Rows[i]["CourseName"].ToString();
                courseObj.CourseCode = dt.Rows[i]["CourseCode"].ToString();
                courseObj.CreditHour = Convert.ToInt32(dt.Rows[i]["CreditHour"]);

                list.Add(courseObj);
            }
            return list;
        }



        [Key]
        public int CourseID { get; set; }

        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Please enter the course name")]
        public string CourseName { get; set; }

        [Display(Name = "Course Code")]
        [Required(ErrorMessage = "Please enter the course code")]
        public string CourseCode { get; set; }

        [Display(Name = "Credit Hour")]
        [Required(ErrorMessage = "Please enter the course hour")]
        public int CreditHour { get; set; }

        public virtual List<TeacherCourse> TeacherCourses { get; set; }
    }
}