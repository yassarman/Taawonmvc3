namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsInHoushToTableProjects : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "IsBuildingInHoush", c => c.Byte());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "IsBuildingInHoush");
        }
    }
}
