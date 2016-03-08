namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WeaponMerchant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeaponMerchant",
                c => new
                    {
                        WeaponID = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WeaponID, t.CharacterID })
                .ForeignKey("dbo.Weapon", t => t.WeaponID, cascadeDelete: true)
                .ForeignKey("dbo.Character", t => t.CharacterID, cascadeDelete: true)
                .Index(t => t.WeaponID)
                .Index(t => t.CharacterID);
            
            CreateTable(
                "dbo.WeaponWornByCharacter",
                c => new
                    {
                        WeaponID = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WeaponID, t.CharacterID })
                .ForeignKey("dbo.Weapon", t => t.WeaponID, cascadeDelete: true)
                .ForeignKey("dbo.Character", t => t.CharacterID, cascadeDelete: true)
                .Index(t => t.WeaponID)
                .Index(t => t.CharacterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeaponWornByCharacter", "CharacterID", "dbo.Character");
            DropForeignKey("dbo.WeaponWornByCharacter", "WeaponID", "dbo.Weapon");
            DropForeignKey("dbo.WeaponMerchant", "CharacterID", "dbo.Character");
            DropForeignKey("dbo.WeaponMerchant", "WeaponID", "dbo.Weapon");
            DropIndex("dbo.WeaponWornByCharacter", new[] { "CharacterID" });
            DropIndex("dbo.WeaponWornByCharacter", new[] { "WeaponID" });
            DropIndex("dbo.WeaponMerchant", new[] { "CharacterID" });
            DropIndex("dbo.WeaponMerchant", new[] { "WeaponID" });
            DropTable("dbo.WeaponWornByCharacter");
            DropTable("dbo.WeaponMerchant");
        }
    }
}
