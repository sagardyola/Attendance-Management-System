using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class TeacherCourse
    {
        List<TeacherCourse> list = new List<TeacherCourse>();
        public TeacherCourse() { }
        public List<TeacherCourse> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TeacherCourse tcObj = new TeacherCourse();
                tcObj.TeacherID = Convert.ToInt32(dt.Rows[i]["TeacherID"]);
                tcObj.CourseID = Convert.ToInt32(dt.Rows[i]["CourseID"]);


                Teacher teacherObj = new Teacher();
                teacherObj.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                tcObj.Teacher = teacherObj;


                Course courseObj = new Course();
                courseObj.CourseName = dt.Rows[i]["CourseName"].ToString();
                tcObj.Course = courseObj;

                list.Add(tcObj);
            }
            return list;
        }

        [Key]
        [Column(Order = 1)]
        public int TeacherID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int CourseID { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }
    }
}