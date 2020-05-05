namespace AttendanceManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationOne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "Date", c => c.DateTime(nullable: false));
        }
    }
}
