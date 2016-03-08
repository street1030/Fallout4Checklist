namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AreaIndoorImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Area", "IndoorImagePathID", "dbo.ImagePath");
            DropIndex("dbo.Area", new[] { "IndoorImagePathID" });
            CreateTable(
                "dbo.AreaIndoorImage",
                c => new
                    {
                        AreaID = c.Int(nullable: false),
                        ImagePathID = c.Int(nullable: false),
                        IndoorAreaName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.AreaID, t.ImagePathID })
                .ForeignKey("dbo.ImagePath", t => t.ImagePathID, cascadeDelete: true)
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .Index(t => t.AreaID)
                .Index(t => t.ImagePathID);
            
            DropColumn("dbo.Area", "IndoorImagePathID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Area", "IndoorImagePathID", c => c.Int());
            DropForeignKey("dbo.AreaIndoorImage", "AreaID", "dbo.Area");
            DropForeignKey("dbo.AreaIndoorImage", "ImagePathID", "dbo.ImagePath");
            DropIndex("dbo.AreaIndoorImage", new[] { "ImagePathID" });
            DropIndex("dbo.AreaIndoorImage", new[] { "AreaID" });
            DropTable("dbo.AreaIndoorImage");
            CreateIndex("dbo.Area", "IndoorImagePathID");
            AddForeignKey("dbo.Area", "IndoorImagePathID", "dbo.ImagePath", "ID");
        }
    }
}
