using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class Faculty
    {
        List<Faculty> list = new List<Faculty>();
        public Faculty() { }
        public List<Faculty> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Faculty fac = new Faculty();
                fac.FacultyID = Convert.ToInt32(dt.Rows[i]["FacultyID"]);
                fac.FacultyName = dt.Rows[i]["FacultyName"].ToString();
                list.Add(fac);
            }
            return list;
        }

        [Key]
        public int FacultyID { get; set; }

        [Display(Name = "Faculty Name")]
        [Required(ErrorMessage = "Please enter the faculty name")]
        public string FacultyName { get; set; }
    }
}