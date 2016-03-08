namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ammo",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Weapon",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        ImagePathID = c.Int(),
                        WeaponTypeID = c.String(maxLength: 100),
                        WeaponSubTypeID = c.String(maxLength: 100),
                        AttacksPerSecond = c.String(maxLength: 20),
                        DamagePerShot = c.Decimal(precision: 18, scale: 2),
                        DamagePerSecond = c.Decimal(precision: 18, scale: 2),
                        FireRate = c.Decimal(precision: 18, scale: 2),
                        Range = c.Decimal(precision: 18, scale: 2),
                        CriticalChanceMultiplier = c.Decimal(precision: 18, scale: 2),
                        CriticalHitDamage = c.Decimal(precision: 18, scale: 2),
                        ActionPointCost = c.Decimal(precision: 18, scale: 2),
                        MagazineCapacity = c.Int(),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        Value = c.Int(),
                        WikiaID = c.String(maxLength: 10),
                        AmmoID = c.String(maxLength: 100),
                        Collected = c.Boolean(nullable: false),
                        IsMenuItem = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 4000),
                        Characteristics = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ammo", t => t.AmmoID)
                .ForeignKey("dbo.ImagePath", t => t.ImagePathID)
                .ForeignKey("dbo.WeaponSubType", t => new { t.WeaponSubTypeID, t.WeaponTypeID })
                .Index(t => t.ImagePathID)
                .Index(t => new { t.WeaponSubTypeID, t.WeaponTypeID })
                .Index(t => t.AmmoID);
            
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        MinThreatLevel = c.Int(),
                        MaxThreatLevel = c.Int(),
                        PrimaAreaID = c.String(maxLength: 10),
                        Description = c.String(maxLength: 4000),
                        ImagePathID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ImagePath", t => t.ImagePathID)
                .Index(t => t.ImagePathID);
            
            CreateTable(
                "dbo.AreaPath",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AreaID = c.Int(nullable: false),
                        Data = c.String(nullable: false, maxLength: 4000),
                        Height = c.Decimal(precision: 18, scale: 2),
                        Width = c.Decimal(precision: 18, scale: 2),
                        CanvasTop = c.Decimal(precision: 18, scale: 2),
                        CanvasLeft = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .Index(t => t.AreaID);
            
            CreateTable(
                "dbo.Bobblehead",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 300),
                        AreaID = c.Int(),
                        BobbleheadTypeID = c.String(nullable: false, maxLength: 30),
                        Collected = c.Boolean(nullable: false),
                        Value = c.Int(nullable: false),
                        ImagePathID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Area", t => t.AreaID)
                .ForeignKey("dbo.BobbleheadType", t => t.BobbleheadTypeID, cascadeDelete: true)
                .ForeignKey("dbo.ImagePath", t => t.ImagePathID, cascadeDelete: true)
                .Index(t => t.AreaID)
                .Index(t => t.BobbleheadTypeID)
                .Index(t => t.ImagePathID);
            
            CreateTable(
                "dbo.BobbleheadType",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ImagePath",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Companion",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 100),
                        AreaID = c.Int(nullable: false),
                        Perk = c.String(nullable: false, maxLength: 100),
                        PerkDescription = c.String(nullable: false, maxLength: 300),
                        PerkRequirement = c.String(nullable: false, maxLength: 300),
                        QuestID = c.Int(),
                        Collected = c.Boolean(nullable: false),
                        ImagePathID = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .ForeignKey("dbo.ImagePath", t => t.ImagePathID)
                .Index(t => t.AreaID)
                .Index(t => t.ImagePathID);
            
            CreateTable(
                "dbo.Magazine",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 200),
                        MagazineTypeID = c.String(nullable: false, maxLength: 100),
                        AreaID = c.Int(),
                        Collected = c.Boolean(nullable: false),
                        ImagePathID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Area", t => t.AreaID)
                .ForeignKey("dbo.ImagePath", t => t.ImagePathID, cascadeDelete: true)
                .ForeignKey("dbo.MagazineType", t => t.MagazineTypeID, cascadeDelete: true)
                .Index(t => t.MagazineTypeID)
                .Index(t => t.AreaID)
                .Index(t => t.ImagePathID);
            
            CreateTable(
                "dbo.MagazineType",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Quest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        WikiaID = c.String(maxLength: 100),
                        QuestTypeID = c.String(nullable: false, maxLength: 100),
                        XP = c.Int(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        ImagePathID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ImagePath", t => t.ImagePathID, cascadeDelete: true)
                .ForeignKey("dbo.QuestType", t => t.QuestTypeID, cascadeDelete: true)
                .Index(t => t.QuestTypeID)
                .Index(t => t.ImagePathID);
            
            CreateTable(
                "dbo.QuestReward",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestID = c.Int(nullable: false),
                        QuestStageID = c.Int(nullable: false),
                        Reward = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Quest", t => t.QuestID, cascadeDelete: true)
                .ForeignKey("dbo.QuestStage", t => new { t.QuestID, t.QuestStageID }, cascadeDelete: true)
                .Index(t => t.QuestID)
                .Index(t => new { t.QuestID, t.QuestStageID });
            
            CreateTable(
                "dbo.QuestStage",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        Stage = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.QuestID, t.Stage })
                .ForeignKey("dbo.Quest", t => t.QuestID)
                .Index(t => t.QuestID);
            
            CreateTable(
                "dbo.QuestStageChain",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        NextStageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.StageID, t.NextStageID })
                .ForeignKey("dbo.QuestStage", t => new { t.QuestID, t.NextStageID })
                .ForeignKey("dbo.QuestStage", t => new { t.QuestID, t.StageID })
                .Index(t => new { t.QuestID, t.NextStageID })
                .Index(t => new { t.QuestID, t.StageID });
            
            CreateTable(
                "dbo.QuestType",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Type);
            
            CreateTable(
                "dbo.Faction",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.OverlayImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AreaID = c.Int(nullable: false),
                        Source = c.String(nullable: false, maxLength: 100),
                        Height = c.Decimal(precision: 18, scale: 2),
                        Width = c.Decimal(precision: 18, scale: 2),
                        CanvasTop = c.Decimal(precision: 18, scale: 2),
                        CanvasLeft = c.Decimal(precision: 18, scale: 2),
                        IsNotifying = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .Index(t => t.AreaID);
            
            CreateTable(
                "dbo.WeaponSubType",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 100),
                        WeaponTypeID = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => new { t.ID, t.WeaponTypeID })
                .ForeignKey("dbo.WeaponType", t => t.WeaponTypeID, cascadeDelete: true)
                .Index(t => t.WeaponTypeID);
            
            CreateTable(
                "dbo.WeaponType",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuestChain",
                c => new
                    {
                        NextQuestID = c.Int(nullable: false),
                        QuestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NextQuestID, t.QuestID })
                .ForeignKey("dbo.Quest", t => t.NextQuestID)
                .ForeignKey("dbo.Quest", t => t.QuestID)
                .Index(t => t.NextQuestID)
                .Index(t => t.QuestID);
            
            CreateTable(
                "dbo.WeaponQuest",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        WeaponID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.WeaponID })
                .ForeignKey("dbo.Quest", t => t.QuestID, cascadeDelete: true)
                .ForeignKey("dbo.Weapon", t => t.WeaponID, cascadeDelete: true)
                .Index(t => t.QuestID)
                .Index(t => t.WeaponID);
            
            CreateTable(
                "dbo.AreaFaction",
                c => new
                    {
                        AreaID = c.Int(nullable: false),
                        FactionID = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => new { t.AreaID, t.FactionID })
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .ForeignKey("dbo.Faction", t => t.FactionID, cascadeDelete: true)
                .Index(t => t.AreaID)
                .Index(t => t.FactionID);
            
            CreateTable(
                "dbo.WeaponArea",
                c => new
                    {
                        AreaID = c.Int(nullable: false),
                        WeaponID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AreaID, t.WeaponID })
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .ForeignKey("dbo.Weapon", t => t.WeaponID, cascadeDelete: true)
                .Index(t => t.AreaID)
                .Index(t => t.WeaponID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weapon", new[] { "WeaponSubTypeID", "WeaponTypeID" }, "dbo.WeaponSubType");
            DropForeignKey("dbo.WeaponSubType", "WeaponTypeID", "dbo.WeaponType");
            DropForeignKey("dbo.Weapon", "ImagePathID", "dbo.ImagePath");
            DropForeignKey("dbo.WeaponArea", "WeaponID", "dbo.Weapon");
            DropForeignKey("dbo.WeaponArea", "AreaID", "dbo.Area");
            DropForeignKey("dbo.OverlayImage", "AreaID", "dbo.Area");
            DropForeignKey("dbo.Area", "ImagePathID", "dbo.ImagePath");
            DropForeignKey("dbo.AreaFaction", "FactionID", "dbo.Faction");
            DropForeignKey("dbo.AreaFaction", "AreaID", "dbo.Area");
            DropForeignKey("dbo.Bobblehead", "ImagePathID", "dbo.ImagePath");
            DropForeignKey("dbo.WeaponQuest", "WeaponID", "dbo.Weapon");
            DropForeignKey("dbo.WeaponQuest", "QuestID", "dbo.Quest");
            DropForeignKey("dbo.Quest", "QuestTypeID", "dbo.QuestType");
            DropForeignKey("dbo.QuestReward", new[] { "QuestID", "QuestStageID" }, "dbo.QuestStage");
            DropForeignKey("dbo.QuestStage", "QuestID", "dbo.Quest");
            DropForeignKey("dbo.QuestStageChain", new[] { "QuestID", "StageID" }, "dbo.QuestStage");
            DropForeignKey("dbo.QuestStageChain", new[] { "QuestID", "NextStageID" }, "dbo.QuestStage");
            DropForeignKey("dbo.QuestReward", "QuestID", "dbo.Quest");
            DropForeignKey("dbo.QuestChain", "QuestID", "dbo.Quest");
            DropForeignKey("dbo.QuestChain", "NextQuestID", "dbo.Quest");
            DropForeignKey("dbo.Quest", "ImagePathID", "dbo.ImagePath");
            DropForeignKey("dbo.Magazine", "MagazineTypeID", "dbo.MagazineType");
            DropForeignKey("dbo.Magazine", "ImagePathID", "dbo.ImagePath");
            DropForeignKey("dbo.Magazine", "AreaID", "dbo.Area");
            DropForeignKey("dbo.Companion", "ImagePathID", "dbo.ImagePath");
            DropForeignKey("dbo.Companion", "AreaID", "dbo.Area");
            DropForeignKey("dbo.Bobblehead", "BobbleheadTypeID", "dbo.BobbleheadType");
            DropForeignKey("dbo.Bobblehead", "AreaID", "dbo.Area");
            DropForeignKey("dbo.AreaPath", "AreaID", "dbo.Area");
            DropForeignKey("dbo.Weapon", "AmmoID", "dbo.Ammo");
            DropIndex("dbo.WeaponArea", new[] { "WeaponID" });
            DropIndex("dbo.WeaponArea", new[] { "AreaID" });
            DropIndex("dbo.AreaFaction", new[] { "FactionID" });
            DropIndex("dbo.AreaFaction", new[] { "AreaID" });
            DropIndex("dbo.WeaponQuest", new[] { "WeaponID" });
            DropIndex("dbo.WeaponQuest", new[] { "QuestID" });
            DropIndex("dbo.QuestChain", new[] { "QuestID" });
            DropIndex("dbo.QuestChain", new[] { "NextQuestID" });
            DropIndex("dbo.WeaponSubType", new[] { "WeaponTypeID" });
            DropIndex("dbo.OverlayImage", new[] { "AreaID" });
            DropIndex("dbo.QuestStageChain", new[] { "QuestID", "StageID" });
            DropIndex("dbo.QuestStageChain", new[] { "QuestID", "NextStageID" });
            DropIndex("dbo.QuestStage", new[] { "QuestID" });
            DropIndex("dbo.QuestReward", new[] { "QuestID", "QuestStageID" });
            DropIndex("dbo.QuestReward", new[] { "QuestID" });
            DropIndex("dbo.Quest", new[] { "ImagePathID" });
            DropIndex("dbo.Quest", new[] { "QuestTypeID" });
            DropIndex("dbo.Magazine", new[] { "ImagePathID" });
            DropIndex("dbo.Magazine", new[] { "AreaID" });
            DropIndex("dbo.Magazine", new[] { "MagazineTypeID" });
            DropIndex("dbo.Companion", new[] { "ImagePathID" });
            DropIndex("dbo.Companion", new[] { "AreaID" });
            DropIndex("dbo.Bobblehead", new[] { "ImagePathID" });
            DropIndex("dbo.Bobblehead", new[] { "BobbleheadTypeID" });
            DropIndex("dbo.Bobblehead", new[] { "AreaID" });
            DropIndex("dbo.AreaPath", new[] { "AreaID" });
            DropIndex("dbo.Area", new[] { "ImagePathID" });
            DropIndex("dbo.Weapon", new[] { "AmmoID" });
            DropIndex("dbo.Weapon", new[] { "WeaponSubTypeID", "WeaponTypeID" });
            DropIndex("dbo.Weapon", new[] { "ImagePathID" });
            DropTable("dbo.WeaponArea");
            DropTable("dbo.AreaFaction");
            DropTable("dbo.WeaponQuest");
            DropTable("dbo.QuestChain");
            DropTable("dbo.Character");
            DropTable("dbo.WeaponType");
            DropTable("dbo.WeaponSubType");
            DropTable("dbo.OverlayImage");
            DropTable("dbo.Faction");
            DropTable("dbo.QuestType");
            DropTable("dbo.QuestStageChain");
            DropTable("dbo.QuestStage");
            DropTable("dbo.QuestReward");
            DropTable("dbo.Quest");
            DropTable("dbo.MagazineType");
            DropTable("dbo.Magazine");
            DropTable("dbo.Companion");
            DropTable("dbo.ImagePath");
            DropTable("dbo.BobbleheadType");
            DropTable("dbo.Bobblehead");
            DropTable("dbo.AreaPath");
            DropTable("dbo.Area");
            DropTable("dbo.Weapon");
            DropTable("dbo.Ammo");
        }
    }
}
