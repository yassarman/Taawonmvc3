namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveHousingSinceFromTableApplications : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Applications", "housingSince");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "housingSince", c => c.DateTime(nullable: false));
        }
    }
}
