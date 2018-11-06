namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableApplications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "PropertyOwnerShipId", c => c.Int(nullable: false));
            AlterColumn("dbo.Applications", "previousRestorationSource", c => c.String(maxLength: 255));
            AlterColumn("dbo.Applications", "interestedRepairingEntityName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applications", "interestedRepairingEntityName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Applications", "previousRestorationSource", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Applications", "PropertyOwnerShipId");
        }
    }
}
