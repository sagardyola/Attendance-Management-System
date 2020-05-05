using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class Class
    {
        List<Class> list = new List<Class>();
        public Class() { }
        public List<Class> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Class classObj = new Class();
                classObj.ClassID = Convert.ToInt32(dt.Rows[i]["ClassID"]);
                classObj.ClassName = dt.Rows[i]["ClassName"].ToString();

                list.Add(classObj);
            }
            return list;
        }

        [Key]
        public int ClassID { get; set; }

        [Required]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

    }
}