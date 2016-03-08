namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestTypeDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestType", "Description", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestType", "Description");
        }
    }
}
