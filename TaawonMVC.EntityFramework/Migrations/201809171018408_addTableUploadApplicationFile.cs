namespace TaawonMVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addTableUploadApplicationFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadApplicationFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        applicationId = c.Int(),
                        FileName = c.String(maxLength: 100),
                        FileData = c.Binary(),
                        Type = c.String(maxLength: 50),
                        SourceTable = c.String(maxLength: 50),
                        SourceTableId = c.Int(),
                        Description = c.String(maxLength: 50),
                        NoOfFiles = c.Int(),
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
                    { "DynamicFilter_UploadApplicationFiles_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UploadApplicationFiles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UploadApplicationFiles_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
