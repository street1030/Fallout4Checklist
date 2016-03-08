namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestStageCompanion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestStage", "Companion_Name", "dbo.Companion");
            DropIndex("dbo.QuestStage", new[] { "Companion_Name" });
            CreateTable(
                "dbo.QuestStageCompanion",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        CompanionID = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => new { t.QuestID, t.StageID, t.CompanionID })
                .ForeignKey("dbo.QuestStage", t => new { t.QuestID, t.StageID }, cascadeDelete: true)
                .ForeignKey("dbo.Companion", t => t.CompanionID, cascadeDelete: true)
                .Index(t => new { t.QuestID, t.StageID })
                .Index(t => t.CompanionID);
            
            DropColumn("dbo.QuestStage", "Companion_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestStage", "Companion_Name", c => c.String(maxLength: 100));
            DropForeignKey("dbo.QuestStageCompanion", "CompanionID", "dbo.Companion");
            DropForeignKey("dbo.QuestStageCompanion", new[] { "QuestID", "StageID" }, "dbo.QuestStage");
            DropIndex("dbo.QuestStageCompanion", new[] { "CompanionID" });
            DropIndex("dbo.QuestStageCompanion", new[] { "QuestID", "StageID" });
            DropTable("dbo.QuestStageCompanion");
            CreateIndex("dbo.QuestStage", "Companion_Name");
            AddForeignKey("dbo.QuestStage", "Companion_Name", "dbo.Companion", "Name");
        }
    }
}
