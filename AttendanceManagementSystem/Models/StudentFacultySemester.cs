using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class StudentFacultySemester
    {
        List<StudentFacultySemester> list = new List<StudentFacultySemester>();
        public StudentFacultySemester() { }
        public List<StudentFacultySemester> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentFacultySemester sfsObj = new StudentFacultySemester();
                sfsObj.StudentID = Convert.ToInt32(dt.Rows[i]["StudentID"]);
                sfsObj.FacultyID = Convert.ToInt32(dt.Rows[i]["FacultyID"]);
                sfsObj.SemesterID = Convert.ToInt32(dt.Rows[i]["SemesterID"]);

                Student courseObj = new Student();
                courseObj.Name = dt.Rows[i]["Name"].ToString();
                sfsObj.Student = courseObj;

                Faculty facultyObj = new Faculty();
                facultyObj.FacultyName = dt.Rows[i]["FacultyName"].ToString();
                sfsObj.Faculty = facultyObj;

                Semester semesterObj = new Semester();
                semesterObj.SemesterName = dt.Rows[i]["SemesterName"].ToString();
                sfsObj.Semester = semesterObj;

                list.Add(sfsObj);
            }
            return list;
        }

        [Key]
        [Column(Order = 1)]
        public int StudentID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int FacultyID { get; set; }

        [Key]
        [Column(Order = 3)]
        public int SemesterID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Semester Semester { get; set; }
    }
}