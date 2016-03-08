namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestStagePowerArmor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestStagePowerArmor",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        PowerArmorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.StageID, t.PowerArmorID })
                .ForeignKey("dbo.QuestStage", t => new { t.QuestID, t.StageID }, cascadeDelete: true)
                .ForeignKey("dbo.PowerArmor", t => t.PowerArmorID, cascadeDelete: true)
                .Index(t => new { t.QuestID, t.StageID })
                .Index(t => t.PowerArmorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestStagePowerArmor", "PowerArmorID", "dbo.PowerArmor");
            DropForeignKey("dbo.QuestStagePowerArmor", new[] { "QuestID", "StageID" }, "dbo.QuestStage");
            DropIndex("dbo.QuestStagePowerArmor", new[] { "PowerArmorID" });
            DropIndex("dbo.QuestStagePowerArmor", new[] { "QuestID", "StageID" });
            DropTable("dbo.QuestStagePowerArmor");
        }
    }
}
