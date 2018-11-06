namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHousingSinceToTableApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "housingSince", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "housingSince");
        }
    }
}
