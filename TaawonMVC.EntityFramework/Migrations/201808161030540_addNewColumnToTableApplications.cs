namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewColumnToTableApplications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "buildingId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "buildingId");
        }
    }
}
