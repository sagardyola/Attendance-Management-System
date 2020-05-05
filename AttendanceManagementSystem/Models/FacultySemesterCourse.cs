using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class FacultySemesterCourse
    {
        List<FacultySemesterCourse> list = new List<FacultySemesterCourse>();
        public FacultySemesterCourse() { }
        public List<FacultySemesterCourse> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FacultySemesterCourse fscObj = new FacultySemesterCourse();
                fscObj.FacultyID = Convert.ToInt32(dt.Rows[i]["FacultyID"]);
                fscObj.SemesterID = Convert.ToInt32(dt.Rows[i]["SemesterID"]);
                fscObj.CourseID = Convert.ToInt32(dt.Rows[i]["CourseID"]);


                Faculty facultyObj = new Faculty();
                facultyObj.FacultyName = dt.Rows[i]["FacultyName"].ToString();
                fscObj.Faculty = facultyObj;

                Semester semesterObj = new Semester();
                semesterObj.SemesterName = dt.Rows[i]["SemesterName"].ToString();
                fscObj.Semester = semesterObj;

                Course courseObj = new Course();
                courseObj.CourseName = dt.Rows[i]["CourseName"].ToString();
                fscObj.Course = courseObj;

                list.Add(fscObj);
            }
            return list;
        }


        [Key]
        [Column(Order = 1)]
        public int FacultyID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int SemesterID { get; set; }

        [Key]
        [Column(Order = 3)]
        public int CourseID { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Course Course { get; set; }
    }
}