namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeColumnDonorFromTableProject : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "donor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "donor", c => c.String());
        }
    }
}
