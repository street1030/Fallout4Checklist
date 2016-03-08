namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOverlay : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OverlayImage", "AreaID", "dbo.Area");
            DropIndex("dbo.OverlayImage", new[] { "AreaID" });
            DropTable("dbo.OverlayImage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OverlayImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AreaID = c.Int(nullable: false),
                        Source = c.String(nullable: false, maxLength: 100),
                        Height = c.Decimal(precision: 18, scale: 2),
                        Width = c.Decimal(precision: 18, scale: 2),
                        CanvasTop = c.Decimal(precision: 18, scale: 2),
                        CanvasLeft = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.OverlayImage", "AreaID");
            AddForeignKey("dbo.OverlayImage", "AreaID", "dbo.Area", "ID", cascadeDelete: true);
        }
    }
}
