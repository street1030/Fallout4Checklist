namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveWeaponCharacteristics : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Weapon", "WikiaID");
            DropColumn("dbo.Weapon", "Description");
            DropColumn("dbo.Weapon", "Characteristics");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weapon", "Characteristics", c => c.String());
            AddColumn("dbo.Weapon", "Description", c => c.String(maxLength: 4000));
            AddColumn("dbo.Weapon", "WikiaID", c => c.String(maxLength: 10));
        }
    }
}
