using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AttendanceManagementSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        //public virtual ICollection<Teacher> Teachers { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<TeacherType> TeacherTypes { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<StudentFacultySemester> StudentFacultySemesters { get; set; }
        public DbSet<FacultySemesterCourse> FacultySemesterCourses { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //new
        public void Create(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                //ifcon oppen close
                con.Close();
            }
        }


        public void Edit(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                //ifcon oppen close
                con.Close();
            }
        }

        public void Delete(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                //ifcon oppen close
                con.Close();
            }
        }

        public DataTable List(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(dt);

            }
            finally
            {

                con.Close();
            }
            return dt;
        }


        public void Find(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                //ifcon oppen close
                con.Close();
            }
        }
    }
}