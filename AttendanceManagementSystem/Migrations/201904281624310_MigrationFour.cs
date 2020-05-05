namespace AttendanceManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationFour : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teachers", "TeachingHours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "TeachingHours", c => c.Int(nullable: false));
        }
    }
}
