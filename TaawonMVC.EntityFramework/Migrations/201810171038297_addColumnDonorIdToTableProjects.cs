namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnDonorIdToTableProjects : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "donorId", c => c.Int());
            CreateIndex("dbo.Projects", "donorId");
            AddForeignKey("dbo.Projects", "donorId", "dbo.Donors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "donorId", "dbo.Donors");
            DropIndex("dbo.Projects", new[] { "donorId" });
            DropColumn("dbo.Projects", "donorId");
        }
    }
}
