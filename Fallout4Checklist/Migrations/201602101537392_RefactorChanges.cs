namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PowerArmor", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PowerArmor", "Weight", c => c.Int(nullable: false));
        }
    }
}
