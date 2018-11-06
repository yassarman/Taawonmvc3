namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUnitContents : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BuildingContents (UnitPartName,IsDeleted,CreationTime) VALUES ('kitchen',0,CURRENT_TIMESTAMP) ");
            Sql("INSERT INTO BuildingContents (UnitPartName,IsDeleted,CreationTime) VALUES ('Bedroom',0,CURRENT_TIMESTAMP) ");
            Sql("INSERT INTO BuildingContents (UnitPartName,IsDeleted,CreationTime) VALUES ('livingroom',0,CURRENT_TIMESTAMP) ");
            Sql("INSERT INTO BuildingContents (UnitPartName,IsDeleted,CreationTime) VALUES ('Roof',0,CURRENT_TIMESTAMP) ");
            Sql("INSERT INTO BuildingContents (UnitPartName,IsDeleted,CreationTime) VALUES ('General Store',0,CURRENT_TIMESTAMP) ");
            Sql("INSERT INTO BuildingContents (UnitPartName,IsDeleted,CreationTime) VALUES ('Yard',0,CURRENT_TIMESTAMP) ");
            Sql("INSERT INTO BuildingContents (UnitPartName,IsDeleted,CreationTime) VALUES ('Institution Rooms',0,CURRENT_TIMESTAMP) ");
            Sql("INSERT INTO BuildingContents (UnitPartName,IsDeleted,CreationTime) VALUES ('Two Rooms',0,CURRENT_TIMESTAMP) ");
            Sql("INSERT INTO BuildingContents (UnitPartName,IsDeleted,CreationTime) VALUES ('Three Rooms',0,CURRENT_TIMESTAMP) ");
            Sql("INSERT INTO BuildingContents (UnitPartName,IsDeleted,CreationTime) VALUES ('Four Rooms',0,CURRENT_TIMESTAMP) ");

        }
        
        public override void Down()
        {
        }
    }
}
