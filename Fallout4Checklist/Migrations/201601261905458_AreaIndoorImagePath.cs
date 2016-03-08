namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AreaIndoorImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Area", "IndoorImagePathID", c => c.Int());
            CreateIndex("dbo.Area", "IndoorImagePathID");
            AddForeignKey("dbo.Area", "IndoorImagePathID", "dbo.ImagePath", "ID");
            //DropColumn("dbo.OverlayImage", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OverlayImage", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Area", "IndoorImagePathID", "dbo.ImagePath");
            DropIndex("dbo.Area", new[] { "IndoorImagePathID" });
            DropColumn("dbo.Area", "IndoorImagePathID");
        }
    }
}
