namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBuildingIdToUploadFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UploadFiles", "buildingId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UploadFiles", "buildingId");
        }
    }
}
