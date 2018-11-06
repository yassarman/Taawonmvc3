namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsConvertedToTableApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "IsApplicationConvertedToProject", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "IsApplicationConvertedToProject");
        }
    }
}
