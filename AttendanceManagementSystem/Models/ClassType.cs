using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class ClassType
    {
        List<ClassType> list = new List<ClassType>();
        public ClassType() { }
        public List<ClassType> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ClassType classObj = new ClassType();
                classObj.ClassTypeID = Convert.ToInt32(dt.Rows[i]["ClassTypeID"]);
                classObj.ClassTypeName = dt.Rows[i]["ClassTypeName"].ToString();

                list.Add(classObj);
            }
            return list;
        }

        [Key]
        public int ClassTypeID { get; set; }

        [Required]
        [Display(Name = "Class Type")]
        public string ClassTypeName { get; set; }
    }
}