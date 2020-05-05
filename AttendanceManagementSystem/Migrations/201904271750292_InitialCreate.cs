namespace AttendanceManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        RoutineID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        EntryTime = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => new { t.StudentID, t.RoutineID })
                .ForeignKey("dbo.Routines", t => t.RoutineID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.RoutineID);
            
            CreateTable(
                "dbo.Routines",
                c => new
                    {
                        RoutineID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                        ClassTypeID = c.Int(nullable: false),
                        Day = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RoutineID)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.ClassTypes", t => t.ClassTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.ClassID)
                .Index(t => t.ClassTypeID);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "dbo.ClassTypes",
                c => new
                    {
                        ClassTypeID = c.Int(nullable: false, identity: true),
                        ClassTypeName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ClassTypeID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        CourseCode = c.String(nullable: false),
                        CreditHour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.TeacherCourses",
                c => new
                    {
                        TeacherID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherID, t.CourseID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false),
                        Phone = c.String(),
                        Email = c.String(nullable: false),
                        TeachingHours = c.Int(nullable: false),
                        TeacherTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherID)
                .ForeignKey("dbo.TeacherTypes", t => t.TeacherTypeID, cascadeDelete: true)
                .Index(t => t.TeacherTypeID);
            
            CreateTable(
                "dbo.TeacherTypes",
                c => new
                    {
                        TeacherTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherTypeID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(),
                        Address = c.String(nullable: false),
                        Gender = c.String(),
                        DOB = c.DateTime(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyID = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyID);
            
            CreateTable(
                "dbo.FacultySemesterCourses",
                c => new
                    {
                        FacultyID = c.Int(nullable: false),
                        SemesterID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FacultyID, t.SemesterID, t.CourseID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.FacultyID, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterID, cascadeDelete: true)
                .Index(t => t.FacultyID)
                .Index(t => t.SemesterID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterID = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SemesterID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StudentFacultySemesters",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        FacultyID = c.Int(nullable: false),
                        SemesterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.FacultyID, t.SemesterID })
                .ForeignKey("dbo.Faculties", t => t.FacultyID, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.FacultyID)
                .Index(t => t.SemesterID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentFacultySemesters", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentFacultySemesters", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.StudentFacultySemesters", "FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FacultySemesterCourses", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.FacultySemesterCourses", "FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.FacultySemesterCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Routines", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Teachers", "TeacherTypeID", "dbo.TeacherTypes");
            DropForeignKey("dbo.TeacherCourses", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.TeacherCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Routines", "ClassTypeID", "dbo.ClassTypes");
            DropForeignKey("dbo.Routines", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.Attendances", "RoutineID", "dbo.Routines");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.StudentFacultySemesters", new[] { "SemesterID" });
            DropIndex("dbo.StudentFacultySemesters", new[] { "FacultyID" });
            DropIndex("dbo.StudentFacultySemesters", new[] { "StudentID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FacultySemesterCourses", new[] { "CourseID" });
            DropIndex("dbo.FacultySemesterCourses", new[] { "SemesterID" });
            DropIndex("dbo.FacultySemesterCourses", new[] { "FacultyID" });
            DropIndex("dbo.Teachers", new[] { "TeacherTypeID" });
            DropIndex("dbo.TeacherCourses", new[] { "CourseID" });
            DropIndex("dbo.TeacherCourses", new[] { "TeacherID" });
            DropIndex("dbo.Routines", new[] { "ClassTypeID" });
            DropIndex("dbo.Routines", new[] { "ClassID" });
            DropIndex("dbo.Routines", new[] { "CourseID" });
            DropIndex("dbo.Attendances", new[] { "RoutineID" });
            DropIndex("dbo.Attendances", new[] { "StudentID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StudentFacultySemesters");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Semesters");
            DropTable("dbo.FacultySemesterCourses");
            DropTable("dbo.Faculties");
            DropTable("dbo.Students");
            DropTable("dbo.TeacherTypes");
            DropTable("dbo.Teachers");
            DropTable("dbo.TeacherCourses");
            DropTable("dbo.Courses");
            DropTable("dbo.ClassTypes");
            DropTable("dbo.Classes");
            DropTable("dbo.Routines");
            DropTable("dbo.Attendances");
        }
    }
}
