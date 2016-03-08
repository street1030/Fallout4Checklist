namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestStageShortDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestStage", "ShortDescription", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestStage", "ShortDescription");
        }
    }
}
