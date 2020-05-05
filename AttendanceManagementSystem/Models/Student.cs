using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceManagementSystem.Models
{
    public class Student
    {
        List<Student> list = new List<Student>();
        public Student() { }
        public List<Student> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student studentObj = new Student();
                studentObj.StudentID = Convert.ToInt32(dt.Rows[i]["StudentID"]);
                studentObj.Name = dt.Rows[i]["Name"].ToString();
                studentObj.Email = dt.Rows[i]["Email"].ToString();
                studentObj.ContactNo = dt.Rows[i]["ContactNo"].ToString();
                studentObj.Address = dt.Rows[i]["Address"].ToString();
                studentObj.Gender = Convert.ToString(dt.Rows[i]["Gender"]);
                studentObj.DOB = Convert.ToDateTime(dt.Rows[i]["DOB"]);
                studentObj.EnrollmentDate = Convert.ToDateTime(dt.Rows[i]["EnrollmentDate"]);
                studentObj.FacultyName = Convert.ToString(dt.Rows[i]["FacultyName"]);
                studentObj.SemesterName = Convert.ToString(dt.Rows[i]["SemesterName"]);

                list.Add(studentObj);
            }
            return list;
        }

        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "You need to enter your email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ContactNo { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "You need to enter address.")]
        public string Address { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public virtual List<Attendance> Attendances { get; set; }


        [NotMapped]
        [Display(Name = "Faculty")]
        public string FacultyName { get; set; }

        [NotMapped]
        [Display(Name = "Semester")]
        public string SemesterName { get; set; }

    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}