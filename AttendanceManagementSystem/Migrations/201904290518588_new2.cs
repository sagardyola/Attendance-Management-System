namespace AttendanceManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "Status", c => c.String());
            AlterColumn("dbo.Attendances", "EntryTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "EntryTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Attendances", "Status");
        }
    }
}
