namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToTableApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "ApplicationStatus", c => c.Byte());
            AddColumn("dbo.Applications", "RejectDate", c => c.DateTime());
            AddColumn("dbo.Applications", "ApprovedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "ApprovedDate");
            DropColumn("dbo.Applications", "RejectDate");
            DropColumn("dbo.Applications", "ApplicationStatus");
        }
    }
}
