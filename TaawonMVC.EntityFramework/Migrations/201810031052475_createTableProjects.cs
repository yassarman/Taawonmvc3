namespace TaawonMVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class createTableProjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        projectArabicName = c.String(nullable: false),
                        projectEnglishName = c.String(nullable: false),
                        donor = c.String(),
                        budget = c.Double(),
                        contractor = c.String(),
                        locationFromMap = c.Double(),
                        projectPeriod = c.Int(),
                        year = c.Int(),
                        numberOfFamilies = c.Int(),
                        numberOfIndividuals = c.Int(),
                        location = c.Double(),
                        numberOfRooms = c.Int(),
                        isBuildingHasRoof = c.Byte(),
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
                    { "DynamicFilter_Projects_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Projects_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
