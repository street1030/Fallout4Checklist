namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestDisplayOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Weapon", "Quest_ID", "dbo.Quest");
            DropIndex("dbo.Weapon", new[] { "Quest_ID" });
            AddColumn("dbo.Quest", "DisplayOrder", c => c.Int(nullable: false, defaultValue: 0));
            AddColumn("dbo.QuestType", "DisplayOrder", c => c.Int(nullable: false, defaultValue: 0));
            DropColumn("dbo.Weapon", "Quest_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weapon", "Quest_ID", c => c.Int());
            DropColumn("dbo.QuestType", "DisplayOrder");
            DropColumn("dbo.Quest", "DisplayOrder");
            CreateIndex("dbo.Weapon", "Quest_ID");
            AddForeignKey("dbo.Weapon", "Quest_ID", "dbo.Quest", "ID");
        }
    }
}
