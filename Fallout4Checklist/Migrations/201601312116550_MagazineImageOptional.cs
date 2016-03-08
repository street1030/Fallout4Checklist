namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MagazineImageOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Magazine", "ImagePathID", "dbo.ImagePath");
            DropIndex("dbo.Magazine", new[] { "ImagePathID" });
            AlterColumn("dbo.Magazine", "ImagePathID", c => c.Int());
            CreateIndex("dbo.Magazine", "ImagePathID");
            AddForeignKey("dbo.Magazine", "ImagePathID", "dbo.ImagePath", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Magazine", "ImagePathID", "dbo.ImagePath");
            DropIndex("dbo.Magazine", new[] { "ImagePathID" });
            AlterColumn("dbo.Magazine", "ImagePathID", c => c.Int(nullable: false));
            CreateIndex("dbo.Magazine", "ImagePathID");
            AddForeignKey("dbo.Magazine", "ImagePathID", "dbo.ImagePath", "ID", cascadeDelete: true);
        }
    }
}
