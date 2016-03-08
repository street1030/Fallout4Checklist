namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArmorArea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArmorArea",
                c => new
                    {
                        ArmorID = c.Int(nullable: false),
                        AreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArmorID, t.AreaID })
                .ForeignKey("dbo.Armor", t => t.ArmorID, cascadeDelete: true)
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .Index(t => t.ArmorID)
                .Index(t => t.AreaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArmorArea", "AreaID", "dbo.Area");
            DropForeignKey("dbo.ArmorArea", "ArmorID", "dbo.Armor");
            DropIndex("dbo.ArmorArea", new[] { "AreaID" });
            DropIndex("dbo.ArmorArea", new[] { "ArmorID" });
            DropTable("dbo.ArmorArea");
        }
    }
}
