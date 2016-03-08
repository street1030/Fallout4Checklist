namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArmorMerchant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArmorMerchant",
                c => new
                    {
                        ArmorID = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArmorID, t.CharacterID })
                .ForeignKey("dbo.Armor", t => t.ArmorID, cascadeDelete: true)
                .ForeignKey("dbo.Character", t => t.CharacterID, cascadeDelete: true)
                .Index(t => t.ArmorID)
                .Index(t => t.CharacterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArmorMerchant", "CharacterID", "dbo.Character");
            DropForeignKey("dbo.ArmorMerchant", "ArmorID", "dbo.Armor");
            DropIndex("dbo.ArmorMerchant", new[] { "CharacterID" });
            DropIndex("dbo.ArmorMerchant", new[] { "ArmorID" });
            DropTable("dbo.ArmorMerchant");
        }
    }
}
