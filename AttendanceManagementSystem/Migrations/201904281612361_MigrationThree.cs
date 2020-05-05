namespace AttendanceManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationThree : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Attendances");
            AddColumn("dbo.Attendances", "AttendanceID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Attendances", "AttendanceID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Attendances");
            DropColumn("dbo.Attendances", "AttendanceID");
            AddPrimaryKey("dbo.Attendances", new[] { "StudentID", "RoutineID" });
        }
    }
}
