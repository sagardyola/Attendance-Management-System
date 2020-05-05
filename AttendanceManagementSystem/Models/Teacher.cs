using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class Teacher
    {
        List<Teacher> list = new List<Teacher>();
        public Teacher() { }
        public List<Teacher> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Teacher teacherObj = new Teacher();
                teacherObj.TeacherID = Convert.ToInt32(dt.Rows[i]["TeacherID"]);
                teacherObj.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                teacherObj.Phone = dt.Rows[i]["Phone"].ToString();
                teacherObj.Email = dt.Rows[i]["Email"].ToString();
                teacherObj.TeachingHours = Convert.ToInt32(dt.Rows[i]["TeachingHours"]);
                teacherObj.TeacherTypeID = Convert.ToInt32(dt.Rows[i]["TeacherTypeID"]);

                TeacherType teacherTypeObj = new TeacherType();
                teacherTypeObj.TypeName = dt.Rows[i]["TypeName"].ToString();
                teacherObj.TeacherType = teacherTypeObj;

                list.Add(teacherObj);
            }
            return list;
        }

        [Key]
        public int TeacherID { get; set; }

        [Display(Name = "Teacher Name")]
        [Required(ErrorMessage = "Please enter teacher name.")]
        public string TeacherName { get; set; }

        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "You need to enter email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Teaching Hours")]
        [Required(ErrorMessage = "Teaching hours is required.")]
        public int TeachingHours { get; set; }

        public int TeacherTypeID { get; set; }

        [ForeignKey("TeacherTypeID")]
        public virtual TeacherType TeacherType { get; set; }

        //public string UserID { get; set; }

        //[ForeignKey("UserID")]
        //public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual List<TeacherCourse> TeacherCourses { get; set; }
    }
}