namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterArea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterArea",
                c => new
                    {
                        CharacterID = c.Int(nullable: false),
                        AreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CharacterID, t.AreaID })
                .ForeignKey("dbo.Character", t => t.CharacterID, cascadeDelete: true)
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .Index(t => t.CharacterID)
                .Index(t => t.AreaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharacterArea", "AreaID", "dbo.Area");
            DropForeignKey("dbo.CharacterArea", "CharacterID", "dbo.Character");
            DropIndex("dbo.CharacterArea", new[] { "AreaID" });
            DropIndex("dbo.CharacterArea", new[] { "CharacterID" });
            DropTable("dbo.CharacterArea");
        }
    }
}
