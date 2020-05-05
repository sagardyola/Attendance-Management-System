namespace AttendanceManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usr132 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "EntryTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "EntryTime", c => c.DateTime());
        }
    }
}
