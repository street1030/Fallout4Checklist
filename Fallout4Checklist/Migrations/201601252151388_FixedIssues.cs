namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedIssues : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quest", "ImagePathID", "dbo.ImagePath");
            DropIndex("dbo.Quest", new[] { "ImagePathID" });
            AlterColumn("dbo.Weapon", "Characteristics", c => c.String());
            AlterColumn("dbo.Quest", "ImagePathID", c => c.Int());
            CreateIndex("dbo.Quest", "ImagePathID");
            AddForeignKey("dbo.Quest", "ImagePathID", "dbo.ImagePath", "ID");
            DropColumn("dbo.OverlayImage", "IsNotifying");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OverlayImage", "IsNotifying", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Quest", "ImagePathID", "dbo.ImagePath");
            DropIndex("dbo.Quest", new[] { "ImagePathID" });
            AlterColumn("dbo.Quest", "ImagePathID", c => c.Int(nullable: false));
            AlterColumn("dbo.Weapon", "Characteristics", c => c.String(maxLength: 4000));
            CreateIndex("dbo.Quest", "ImagePathID");
            AddForeignKey("dbo.Quest", "ImagePathID", "dbo.ImagePath", "ID", cascadeDelete: true);
        }
    }
}
