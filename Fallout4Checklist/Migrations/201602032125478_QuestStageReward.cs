namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestStageReward : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestStageReward",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        Reward = c.String(maxLength: 100),
                        Prerequisite = c.String(maxLength: 200),
                        RewardTypeID = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestStageRewardType", t => t.RewardTypeID, cascadeDelete: true)
                .ForeignKey("dbo.QuestStage", t => new { t.QuestID, t.StageID }, cascadeDelete: true)
                .Index(t => new { t.QuestID, t.StageID })
                .Index(t => t.RewardTypeID);
            
            CreateTable(
                "dbo.QuestStageRewardType",
                c => new
                    {
                        RewardType = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RewardType);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestStageReward", new[] { "QuestID", "StageID" }, "dbo.QuestStage");
            DropForeignKey("dbo.QuestStageReward", "RewardTypeID", "dbo.QuestStageRewardType");
            DropIndex("dbo.QuestStageReward", new[] { "RewardTypeID" });
            DropIndex("dbo.QuestStageReward", new[] { "QuestID", "StageID" });
            DropTable("dbo.QuestStageRewardType");
            DropTable("dbo.QuestStageReward");
        }
    }
}
