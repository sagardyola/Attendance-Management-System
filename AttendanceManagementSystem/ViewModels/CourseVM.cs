using AttendanceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.ViewModels
{
    public class CourseVM
    {
        [Display(Name = "Faculty")]
        public int FacultyID { get; set; }

        [Display(Name = "Semester")]
        public int SemesterID { get; set; }

        public virtual Course Course { get; set; }
    }
}