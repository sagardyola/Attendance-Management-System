namespace AttendanceManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Routines", "Day", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Routines", "Day", c => c.DateTime(nullable: false));
        }
    }
}
