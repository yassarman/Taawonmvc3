namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnNumberOfFloorsToTableProjects : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "numberOfFloors", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "numberOfFloors");
        }
    }
}
