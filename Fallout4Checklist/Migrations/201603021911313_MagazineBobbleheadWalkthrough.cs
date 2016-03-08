namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MagazineBobbleheadWalkthrough : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bobblehead", "Walkthrough", c => c.String());
            AddColumn("dbo.Magazine", "Walkthrough", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Magazine", "Walkthrough");
            DropColumn("dbo.Bobblehead", "Walkthrough");
        }
    }
}
