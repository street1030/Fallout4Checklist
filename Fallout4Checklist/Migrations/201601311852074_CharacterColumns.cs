namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "IsDead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Character", "IsSpawned", c => c.Boolean(nullable: false));
            AddColumn("dbo.Character", "IsEssential", c => c.Boolean(nullable: false));
            AddColumn("dbo.Character", "IsDoctor", c => c.Boolean(nullable: false));
            AddColumn("dbo.Character", "IsMerchant", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Character", "IsMerchant");
            DropColumn("dbo.Character", "IsDoctor");
            DropColumn("dbo.Character", "IsEssential");
            DropColumn("dbo.Character", "IsSpawned");
            DropColumn("dbo.Character", "IsDead");
        }
    }
}
