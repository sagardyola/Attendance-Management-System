using AttendanceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.ViewModels
{
    public class StudentVM
    {

        public int FacultyID { get; set; }
        public int SemesterID { get; set; }
        public int CourseID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual StudentFacultySemester StudentFacultySemester { get; set; }
        public virtual FacultySemesterCourse FacultySemesterCourse { get; set; }
    }
}