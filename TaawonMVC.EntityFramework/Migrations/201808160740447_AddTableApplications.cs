namespace TaawonMVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableApplications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fullName = c.String(nullable: false, maxLength: 255),
                        phoneNumber1 = c.Int(nullable: false),
                        phoneNumber2 = c.Int(),
                        isThereFundingOrPreviousRestoration = c.Byte(nullable: false),
                        previousRestorationSource = c.String(nullable: false, maxLength: 255),
                        isThereInterestedRepairingEntity = c.Byte(nullable: false),
                        interestedRepairingEntityName = c.String(nullable: false, maxLength: 255),
                        housingSince = c.DateTime(nullable: false),
                        interventionTypeId = c.Int(nullable: false),
                        restorationTypeIds = c.Binary(),
                        otherOwnershipType = c.String(maxLength: 255),
                        otherRestorationType = c.String(maxLength: 255),
                        propertyStatusDescription = c.String(),
                        requiredRestoration = c.String(),
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
                    { "DynamicFilter_Applications_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterventionTypes", t => t.interventionTypeId, cascadeDelete: true)
                .Index(t => t.interventionTypeId);
            
            //DropTable("dbo.Applications",
            //    removedAnnotations: new Dictionary<string, object>
            //    {
            //        { "DynamicFilter_Application_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
            //    });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        idNumber = c.Int(nullable: false),
                        propertytId = c.Int(nullable: false),
                        houseHoldNumber = c.Int(nullable: false),
                        phoneNumber = c.String(nullable: false, maxLength: 30),
                        specialNeeds = c.Byte(nullable: false),
                        specialNeedType = c.String(nullable: false, maxLength: 30),
                        alternativeResidence = c.Byte(nullable: false),
                        previousRestortion = c.String(nullable: false, maxLength: 30),
                        previousRestortionDate = c.DateTime(nullable: false),
                        previousRestortionAmount = c.String(maxLength: 30),
                        previousRestortionSource = c.String(nullable: false, maxLength: 30),
                        previousRestortionType = c.String(nullable: false, maxLength: 30),
                        interrestedRepairingEntity = c.Byte(nullable: false),
                        interrestedRepairingEntityName = c.String(nullable: false, maxLength: 30),
                        housingSince = c.DateTime(nullable: false),
                        legalDispute = c.Byte(nullable: false),
                        ownerAgreementEnsured = c.Byte(nullable: false),
                        appliedForMunicipality = c.Byte(nullable: false),
                        restortionType = c.Int(nullable: false),
                        residentStatus = c.Int(nullable: false),
                        ownership = c.Int(nullable: false),
                        propertyType = c.Int(nullable: false),
                        ApplicationRecivedDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        BuildingUnitID = c.Int(nullable: false),
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
                    { "DynamicFilter_Application_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Applications", "interventionTypeId", "dbo.InterventionTypes");
            DropIndex("dbo.Applications", new[] { "interventionTypeId" });
            DropTable("dbo.Applications",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Applications_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
