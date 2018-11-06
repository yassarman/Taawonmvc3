namespace TaawonMVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class changeBuildingContentsTableToBuildingUnitContents : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BuildingContents", newName: "BuildingUnitContents");
            AlterTableAnnotations(
                "dbo.BuildingUnitContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitPartName = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        BuildingUnits_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BuildingContents_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_BuildingUnitContents_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
        
        public override void Down()
        {
            AlterTableAnnotations(
                "dbo.BuildingUnitContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitPartName = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        BuildingUnits_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BuildingContents_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_BuildingUnitContents_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            RenameTable(name: "dbo.BuildingUnitContents", newName: "BuildingContents");
        }
    }
}
