namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestStageStuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestReward", "QuestID", "dbo.Quest");
            DropForeignKey("dbo.QuestReward", new[] { "QuestID", "QuestStageID" }, "dbo.QuestStage");
            DropForeignKey("dbo.WeaponQuest", "QuestID", "dbo.Quest");
            DropForeignKey("dbo.WeaponQuest", "WeaponID", "dbo.Weapon");
            DropIndex("dbo.QuestReward", new[] { "QuestID" });
            DropIndex("dbo.QuestReward", new[] { "QuestID", "QuestStageID" });
            DropIndex("dbo.WeaponQuest", new[] { "QuestID" });
            DropIndex("dbo.WeaponQuest", new[] { "WeaponID" });
            CreateTable(
                "dbo.QuestStageArmor",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        ArmorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.StageID, t.ArmorID })
                .ForeignKey("dbo.QuestStage", t => new { t.QuestID, t.StageID }, cascadeDelete: true)
                .ForeignKey("dbo.Armor", t => t.ArmorID, cascadeDelete: true)
                .Index(t => new { t.QuestID, t.StageID })
                .Index(t => t.ArmorID);
            
            CreateTable(
                "dbo.QuestStageNPC",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.StageID, t.CharacterID })
                .ForeignKey("dbo.QuestStage", t => new { t.QuestID, t.StageID }, cascadeDelete: true)
                .ForeignKey("dbo.Character", t => t.CharacterID, cascadeDelete: true)
                .Index(t => new { t.QuestID, t.StageID })
                .Index(t => t.CharacterID);
            
            CreateTable(
                "dbo.QuestStageSettlement",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        SettlementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.StageID, t.SettlementID })
                .ForeignKey("dbo.QuestStage", t => new { t.QuestID, t.StageID }, cascadeDelete: true)
                .ForeignKey("dbo.Area", t => t.SettlementID, cascadeDelete: true)
                .Index(t => new { t.QuestID, t.StageID })
                .Index(t => t.SettlementID);
            
            AddColumn("dbo.Weapon", "Quest_ID", c => c.Int());
            AddColumn("dbo.QuestStage", "Companion_Name", c => c.String(maxLength: 100));
            CreateIndex("dbo.Weapon", "Quest_ID");
            CreateIndex("dbo.QuestStage", "Companion_Name");
            AddForeignKey("dbo.Weapon", "Quest_ID", "dbo.Quest", "ID");
            AddForeignKey("dbo.QuestStage", "Companion_Name", "dbo.Companion", "Name");
            DropTable("dbo.QuestReward");
            DropTable("dbo.WeaponQuest");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WeaponQuest",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        WeaponID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.WeaponID });
            
            CreateTable(
                "dbo.QuestReward",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestID = c.Int(nullable: false),
                        QuestStageID = c.Int(nullable: false),
                        Reward = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.QuestStage", "Companion_Name", "dbo.Companion");
            DropForeignKey("dbo.QuestStageSettlement", "SettlementID", "dbo.Area");
            DropForeignKey("dbo.QuestStageSettlement", new[] { "QuestID", "StageID" }, "dbo.QuestStage");
            DropForeignKey("dbo.QuestStageNPC", "CharacterID", "dbo.Character");
            DropForeignKey("dbo.QuestStageNPC", new[] { "QuestID", "StageID" }, "dbo.QuestStage");
            DropForeignKey("dbo.Weapon", "Quest_ID", "dbo.Quest");
            DropForeignKey("dbo.QuestStageArmor", "ArmorID", "dbo.Armor");
            DropForeignKey("dbo.QuestStageArmor", new[] { "QuestID", "StageID" }, "dbo.QuestStage");
            DropIndex("dbo.QuestStageSettlement", new[] { "SettlementID" });
            DropIndex("dbo.QuestStageSettlement", new[] { "QuestID", "StageID" });
            DropIndex("dbo.QuestStageNPC", new[] { "CharacterID" });
            DropIndex("dbo.QuestStageNPC", new[] { "QuestID", "StageID" });
            DropIndex("dbo.QuestStageArmor", new[] { "ArmorID" });
            DropIndex("dbo.QuestStageArmor", new[] { "QuestID", "StageID" });
            DropIndex("dbo.QuestStage", new[] { "Companion_Name" });
            DropIndex("dbo.Weapon", new[] { "Quest_ID" });
            DropColumn("dbo.QuestStage", "Companion_Name");
            DropColumn("dbo.Weapon", "Quest_ID");
            DropTable("dbo.QuestStageSettlement");
            DropTable("dbo.QuestStageNPC");
            DropTable("dbo.QuestStageArmor");
            CreateIndex("dbo.WeaponQuest", "WeaponID");
            CreateIndex("dbo.WeaponQuest", "QuestID");
            CreateIndex("dbo.QuestReward", new[] { "QuestID", "QuestStageID" });
            CreateIndex("dbo.QuestReward", "QuestID");
            AddForeignKey("dbo.WeaponQuest", "WeaponID", "dbo.Weapon", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WeaponQuest", "QuestID", "dbo.Quest", "ID", cascadeDelete: true);
            AddForeignKey("dbo.QuestReward", new[] { "QuestID", "QuestStageID" }, "dbo.QuestStage", new[] { "QuestID", "Stage" }, cascadeDelete: true);
            AddForeignKey("dbo.QuestReward", "QuestID", "dbo.Quest", "ID", cascadeDelete: true);
        }
    }
}
