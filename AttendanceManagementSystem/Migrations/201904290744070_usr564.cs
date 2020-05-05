namespace AttendanceManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usr564 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "ClassName", c => c.String(nullable: false));
            AlterColumn("dbo.ClassTypes", "ClassTypeName", c => c.String(nullable: false));
            DropColumn("dbo.Classes", "Description");
            DropColumn("dbo.ClassTypes", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClassTypes", "Description", c => c.String());
            AddColumn("dbo.Classes", "Description", c => c.String());
            AlterColumn("dbo.ClassTypes", "ClassTypeName", c => c.String());
            AlterColumn("dbo.Classes", "ClassName", c => c.String());
        }
    }
}
