using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class Attendance
    {
        List<Attendance> list = new List<Attendance>();
        public Attendance() { }
        public List<Attendance> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Attendance attendanceObj = new Attendance();
                attendanceObj.AttendanceID = Convert.ToInt32(dt.Rows[i]["AttendanceID"]);
                attendanceObj.StudentID = Convert.ToInt32(dt.Rows[i]["StudentID"]);
                attendanceObj.RoutineID = Convert.ToInt32(dt.Rows[i]["RoutineID"]);
                attendanceObj.Date = Convert.ToDateTime(dt.Rows[i]["Date"]);
                attendanceObj.EntryTime = Convert.ToDateTime(dt.Rows[i]["EntryTime"]);


                Student studentObj = new Student();
                studentObj.Name = dt.Rows[i]["Name"].ToString();
                attendanceObj.Student = studentObj;

                Routine routineObj = new Routine();
                routineObj.CourseID = Convert.ToInt32(dt.Rows[i]["CourseID"]);
                attendanceObj.Routine = routineObj;

                Course courseObj = new Course();
                courseObj.CourseName = Convert.ToString(dt.Rows[i]["CourseName"]);
                routineObj.Course = courseObj;
                list.Add(attendanceObj);
            }
            return list;
        }





        [Key]
        public int AttendanceID { get; set; }

        public int StudentID { get; set; }

        public int RoutineID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        public DateTime EntryTime { get; set; }

        public string  Status { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }

        [ForeignKey("RoutineID")]
        public virtual Routine Routine { get; set; }
    }
}