namespace AttendanceManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usr134 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "TeachingHours", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "TeachingHours");
        }
    }
}
