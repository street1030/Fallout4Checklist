namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedStuff : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Area", "PrimaAreaID");
            DropColumn("dbo.Area", "Description");
            DropColumn("dbo.Companion", "QuestID");
            DropColumn("dbo.Quest", "WikiaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quest", "WikiaID", c => c.String(maxLength: 100));
            AddColumn("dbo.Companion", "QuestID", c => c.Int());
            AddColumn("dbo.Area", "Description", c => c.String());
            AddColumn("dbo.Area", "PrimaAreaID", c => c.String(maxLength: 10));
        }
    }
}
