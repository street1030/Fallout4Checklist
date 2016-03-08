namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestStageRemoveShortDescription : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.QuestStage", "ShortDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestStage", "ShortDescription", c => c.String(maxLength: 4000));
        }
    }
}
