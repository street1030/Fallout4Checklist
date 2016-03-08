namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestNPC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestNPC",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.CharacterID })
                .ForeignKey("dbo.Quest", t => t.QuestID, cascadeDelete: true)
                .ForeignKey("dbo.Character", t => t.CharacterID, cascadeDelete: true)
                .Index(t => t.QuestID)
                .Index(t => t.CharacterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestNPC", "CharacterID", "dbo.Character");
            DropForeignKey("dbo.QuestNPC", "QuestID", "dbo.Quest");
            DropIndex("dbo.QuestNPC", new[] { "CharacterID" });
            DropIndex("dbo.QuestNPC", new[] { "QuestID" });
            DropTable("dbo.QuestNPC");
        }
    }
}
