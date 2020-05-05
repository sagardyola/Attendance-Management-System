using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class Semester
    {
        List<Semester> list = new List<Semester>();
        public Semester() { }
        public List<Semester> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Semester semesterObj = new Semester();
                semesterObj.SemesterID = Convert.ToInt32(dt.Rows[i]["SemesterID"]);
                semesterObj.SemesterName = dt.Rows[i]["SemesterName"].ToString();
                list.Add(semesterObj);
            }
            return list;
        }

        [Key]
        public int SemesterID { get; set; }

        [Required(ErrorMessage = "Please enter semester name")]
        [Display(Name = "Semester")]
        public string SemesterName { get; set; }
    }
}