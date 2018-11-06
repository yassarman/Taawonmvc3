namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnToBuildingUnits : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuildingUnits", "UnitContentsIds", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BuildingUnits", "UnitContentsIds");
        }
    }
}
