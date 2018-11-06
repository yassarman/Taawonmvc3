namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableApplicationAddFireignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Applications", "PropertyOwnerShipId");
            AddForeignKey("dbo.Applications", "PropertyOwnerShipId", "dbo.PropertyOwnerships", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "PropertyOwnerShipId", "dbo.PropertyOwnerships");
            DropIndex("dbo.Applications", new[] { "PropertyOwnerShipId" });
        }
    }
}
