namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableApplicationsAddBuildingUnitId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "buildingUnitId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "buildingUnitId");
        }
    }
}
