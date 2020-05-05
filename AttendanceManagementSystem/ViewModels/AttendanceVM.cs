using AttendanceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.ViewModels
{
    public class AttendanceVM
    {
        public List<Attendance> Attendances { get; set; }
        public ICollection<Student> Students { get; set; }
       

    }
}