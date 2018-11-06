namespace TaawonMVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addBuildingUnitsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingId = c.Int(nullable: false),
                        ResidentName = c.String(nullable: false, maxLength: 50),
                        ResidenceStatus = c.String(maxLength: 70),
                        NumberOfFamilyMembers = c.Int(nullable: false),
                        Floor = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BuildingUnits_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BuildingContents", "BuildingUnits_Id", c => c.Int());
            CreateIndex("dbo.BuildingContents", "BuildingUnits_Id");
            AddForeignKey("dbo.BuildingContents", "BuildingUnits_Id", "dbo.BuildingUnits", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuildingContents", "BuildingUnits_Id", "dbo.BuildingUnits");
            DropIndex("dbo.BuildingContents", new[] { "BuildingUnits_Id" });
            DropColumn("dbo.BuildingContents", "BuildingUnits_Id");
            DropTable("dbo.BuildingUnits",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BuildingUnits_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
