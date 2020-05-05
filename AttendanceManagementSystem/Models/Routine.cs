using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class Routine
    {
        List<Routine> list = new List<Routine>();
        public Routine() { }
        public List<Routine> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Routine routineObj = new Routine();
                routineObj.RoutineID = Convert.ToInt32(dt.Rows[i]["RoutineID"]);
                routineObj.CourseID = Convert.ToInt32(dt.Rows[i]["CourseID"]);
                routineObj.ClassID = Convert.ToInt32(dt.Rows[i]["ClassID"]);
                routineObj.ClassTypeID = Convert.ToInt32(dt.Rows[i]["ClassTypeID"]);
                routineObj.Day = Convert.ToString(dt.Rows[i]["Day"]);
                routineObj.StartTime = Convert.ToDateTime(dt.Rows[i]["StartTime"]);
                routineObj.EndTime = Convert.ToDateTime(dt.Rows[i]["EndTime"]);

                Course courseObj = new Course();
                courseObj.CourseName = dt.Rows[i]["CourseName"].ToString();
                routineObj.Course = courseObj;

                Class classObj = new Class();
                classObj.ClassName = dt.Rows[i]["ClassName"].ToString();
                routineObj.Class = classObj;

                ClassType classTypeObj = new ClassType();
                classTypeObj.ClassTypeName = dt.Rows[i]["ClassTypeName"].ToString();
                routineObj.ClassType = classTypeObj;



                list.Add(routineObj);
            }
            return list;
        }



        [Key]
        public int RoutineID { get; set; }

        public int CourseID { get; set; }

        public int ClassID { get; set; }

        public int ClassTypeID { get; set; }


        [Display(Name = "Day")]
        public string Day { get; set; }

        [Display(Name = "Start time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }



        [Display(Name = "Course Class")]
        public string CourseClass
        {
            get
            {
                return Course.CourseName + " (" + Class.ClassName + ")";
            }
        }


        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }

        [ForeignKey("ClassTypeID")]
        public virtual ClassType ClassType { get; set; }

        public List<Attendance> Attendances { get; set; }
    }

    public enum Day
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }
}