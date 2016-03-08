namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArmorWornByCharacter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArmorWornByCharacter",
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
            DropForeignKey("dbo.ArmorWornByCharacter", "CharacterID", "dbo.Character");
            DropForeignKey("dbo.ArmorWornByCharacter", "ArmorID", "dbo.Armor");
            DropIndex("dbo.ArmorWornByCharacter", new[] { "CharacterID" });
            DropIndex("dbo.ArmorWornByCharacter", new[] { "ArmorID" });
            DropTable("dbo.ArmorWornByCharacter");
        }
    }
}
