namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestArea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestArea",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        AreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.AreaID })
                .ForeignKey("dbo.Quest", t => t.QuestID, cascadeDelete: true)
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .Index(t => t.QuestID)
                .Index(t => t.AreaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestArea", "AreaID", "dbo.Area");
            DropForeignKey("dbo.QuestArea", "QuestID", "dbo.Quest");
            DropIndex("dbo.QuestArea", new[] { "AreaID" });
            DropIndex("dbo.QuestArea", new[] { "QuestID" });
            DropTable("dbo.QuestArea");
        }
    }
}
