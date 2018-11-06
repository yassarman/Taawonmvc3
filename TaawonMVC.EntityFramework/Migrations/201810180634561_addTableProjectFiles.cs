namespace TaawonMVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addTableProjectFiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadProjectFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(),
                        FileName = c.String(maxLength: 150),
                        FileData = c.Binary(),
                        Type = c.String(maxLength: 100),
                        SourceTable = c.String(maxLength: 100),
                        SourceTableId = c.Int(),
                        Description = c.String(maxLength: 100),
                        NoOfFiles = c.Int(),
                        Status = c.Byte(),
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
                    { "DynamicFilter_UploadProjectFiles_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UploadProjectFiles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UploadProjectFiles_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
