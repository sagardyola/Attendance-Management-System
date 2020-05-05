using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class TeacherType
    {
        List<TeacherType> list = new List<TeacherType>();
        public TeacherType() { }
        public List<TeacherType> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TeacherType teachType = new TeacherType();
                teachType.TeacherTypeID = Convert.ToInt32(dt.Rows[i]["TeacherTypeID"]);
                teachType.TypeName = dt.Rows[i]["TypeName"].ToString();
                list.Add(teachType);
            }
            return list;
        }

        [Key]
        public int TeacherTypeID { get; set; }

        [Display(Name = "Teacher Type")]
        [Required(ErrorMessage = "You need to enter type.")]
        public string TypeName { get; set; }

        public virtual List<Teacher> Teachers { get; set; }
    }
}