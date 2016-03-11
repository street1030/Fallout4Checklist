namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChecklistAndRelatedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChecklistArmor",
                c => new
                    {
                        ChecklistID = c.Int(nullable: false),
                        ArmorID = c.Int(nullable: false),
                        IsCollected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChecklistID, t.ArmorID })
                .ForeignKey("dbo.Armor", t => t.ArmorID)
                .ForeignKey("dbo.Checklist", t => t.ChecklistID)
                .Index(t => t.ChecklistID)
                .Index(t => t.ArmorID);
            
            CreateTable(
                "dbo.Checklist",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(nullable: true),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ChecklistBobblehead",
                c => new
                    {
                        ChecklistID = c.Int(nullable: false),
                        BobbleheadID = c.String(nullable: false, maxLength: 50),
                        IsCollected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChecklistID, t.BobbleheadID })
                .ForeignKey("dbo.Bobblehead", t => t.BobbleheadID)
                .ForeignKey("dbo.Checklist", t => t.ChecklistID)
                .Index(t => t.ChecklistID)
                .Index(t => t.BobbleheadID);
            
            CreateTable(
                "dbo.ChecklistCompanion",
                c => new
                    {
                        ChecklistID = c.Int(nullable: false),
                        CompanionID = c.String(nullable: false, maxLength: 100),
                        IsCollected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChecklistID, t.CompanionID })
                .ForeignKey("dbo.Checklist", t => t.ChecklistID)
                .ForeignKey("dbo.Companion", t => t.CompanionID)
                .Index(t => t.ChecklistID)
                .Index(t => t.CompanionID);
            
            CreateTable(
                "dbo.ChecklistQuest",
                c => new
                    {
                        ChecklistID = c.Int(nullable: false),
                        QuestID = c.Int(nullable: false),
                        IsCollected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChecklistID, t.QuestID })
                .ForeignKey("dbo.Checklist", t => t.ChecklistID)
                .ForeignKey("dbo.Quest", t => t.QuestID)
                .Index(t => t.ChecklistID)
                .Index(t => t.QuestID);
            
            CreateTable(
                "dbo.ChecklistWeapon",
                c => new
                    {
                        ChecklistID = c.Int(nullable: false),
                        WeaponID = c.Int(nullable: false),
                        IsCollected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChecklistID, t.WeaponID })
                .ForeignKey("dbo.Checklist", t => t.ChecklistID)
                .ForeignKey("dbo.Weapon", t => t.WeaponID)
                .Index(t => t.ChecklistID)
                .Index(t => t.WeaponID);
            
            CreateTable(
                "dbo.ChecklistMagazine",
                c => new
                    {
                        ChecklistID = c.Int(nullable: false),
                        MagazineID = c.Int(nullable: false),
                        IsCollected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChecklistID, t.MagazineID })
                .ForeignKey("dbo.Checklist", t => t.ChecklistID)
                .ForeignKey("dbo.Magazine", t => t.MagazineID)
                .Index(t => t.ChecklistID)
                .Index(t => t.MagazineID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChecklistArmor", "ChecklistID", "dbo.Checklist");
            DropForeignKey("dbo.ChecklistBobblehead", "ChecklistID", "dbo.Checklist");
            DropForeignKey("dbo.ChecklistBobblehead", "BobbleheadID", "dbo.Bobblehead");
            DropForeignKey("dbo.ChecklistMagazine", "MagazineID", "dbo.Magazine");
            DropForeignKey("dbo.ChecklistMagazine", "ChecklistID", "dbo.Checklist");
            DropForeignKey("dbo.ChecklistWeapon", "WeaponID", "dbo.Weapon");
            DropForeignKey("dbo.ChecklistWeapon", "ChecklistID", "dbo.Checklist");
            DropForeignKey("dbo.ChecklistQuest", "QuestID", "dbo.Quest");
            DropForeignKey("dbo.ChecklistQuest", "ChecklistID", "dbo.Checklist");
            DropForeignKey("dbo.ChecklistCompanion", "CompanionID", "dbo.Companion");
            DropForeignKey("dbo.ChecklistCompanion", "ChecklistID", "dbo.Checklist");
            DropForeignKey("dbo.ChecklistArmor", "ArmorID", "dbo.Armor");
            DropIndex("dbo.ChecklistMagazine", new[] { "MagazineID" });
            DropIndex("dbo.ChecklistMagazine", new[] { "ChecklistID" });
            DropIndex("dbo.ChecklistWeapon", new[] { "WeaponID" });
            DropIndex("dbo.ChecklistWeapon", new[] { "ChecklistID" });
            DropIndex("dbo.ChecklistQuest", new[] { "QuestID" });
            DropIndex("dbo.ChecklistQuest", new[] { "ChecklistID" });
            DropIndex("dbo.ChecklistCompanion", new[] { "CompanionID" });
            DropIndex("dbo.ChecklistCompanion", new[] { "ChecklistID" });
            DropIndex("dbo.ChecklistBobblehead", new[] { "BobbleheadID" });
            DropIndex("dbo.ChecklistBobblehead", new[] { "ChecklistID" });
            DropIndex("dbo.ChecklistArmor", new[] { "ArmorID" });
            DropIndex("dbo.ChecklistArmor", new[] { "ChecklistID" });
            DropTable("dbo.ChecklistMagazine");
            DropTable("dbo.ChecklistWeapon");
            DropTable("dbo.ChecklistQuest");
            DropTable("dbo.ChecklistCompanion");
            DropTable("dbo.ChecklistBobblehead");
            DropTable("dbo.Checklist");
            DropTable("dbo.ChecklistArmor");
        }
    }
}
