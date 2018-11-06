namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColomnProjectIdToApplications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "projectId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "projectId");
        }
    }
}
