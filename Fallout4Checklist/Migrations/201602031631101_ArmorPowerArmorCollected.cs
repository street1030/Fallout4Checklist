namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArmorPowerArmorCollected : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Armor", "Collected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Armor", "IsMenuItem", c => c.Boolean(nullable: false));
            AddColumn("dbo.PowerArmor", "Collected", c => c.Boolean(nullable: false));
            AddColumn("dbo.PowerArmor", "IsMenuItem", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PowerArmor", "IsMenuItem");
            DropColumn("dbo.PowerArmor", "Collected");
            DropColumn("dbo.Armor", "IsMenuItem");
            DropColumn("dbo.Armor", "Collected");
        }
    }
}
