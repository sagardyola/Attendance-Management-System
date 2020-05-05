namespace AttendanceManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationSix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Attendances", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "Status", c => c.String());
        }
    }
}
