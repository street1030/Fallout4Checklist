namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestStageWeapon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestStageWeapon",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        WeaponID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.StageID, t.WeaponID })
                .ForeignKey("dbo.QuestStage", t => new { t.QuestID, t.StageID }, cascadeDelete: true)
                .ForeignKey("dbo.Weapon", t => t.WeaponID, cascadeDelete: true)
                .Index(t => new { t.QuestID, t.StageID })
                .Index(t => t.WeaponID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestStageWeapon", "WeaponID", "dbo.Weapon");
            DropForeignKey("dbo.QuestStageWeapon", new[] { "QuestID", "StageID" }, "dbo.QuestStage");
            DropIndex("dbo.QuestStageWeapon", new[] { "WeaponID" });
            DropIndex("dbo.QuestStageWeapon", new[] { "QuestID", "StageID" });
            DropTable("dbo.QuestStageWeapon");
        }
    }
}
