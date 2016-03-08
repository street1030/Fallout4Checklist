namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Text;
    public partial class RemoveIndoorImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AreaIndoorImage", "ImagePathID", "dbo.ImagePath");
            DropForeignKey("dbo.Area", "ImagePathID", "dbo.ImagePath");
            DropForeignKey("dbo.AreaIndoorImage", "AreaID", "dbo.Area");
            DropIndex("dbo.Area", new[] { "ImagePathID" });
            DropIndex("dbo.AreaIndoorImage", new[] { "AreaID" });
            DropIndex("dbo.AreaIndoorImage", new[] { "ImagePathID" });
            DropColumn("dbo.Area", "ImagePathID");
            DropTable("dbo.AreaIndoorImage");

            var removeIndoorImagePaths = Encoding.Default.GetString(Properties.Resources.RemoveIndoorImagePaths);
            Sql(removeIndoorImagePaths);
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AreaIndoorImage",
                c => new
                    {
                        AreaID = c.Int(nullable: false),
                        ImagePathID = c.Int(nullable: false),
                        IndoorAreaName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.AreaID, t.ImagePathID });
            
            AddColumn("dbo.Area", "ImagePathID", c => c.Int());
            CreateIndex("dbo.AreaIndoorImage", "ImagePathID");
            CreateIndex("dbo.AreaIndoorImage", "AreaID");
            CreateIndex("dbo.Area", "ImagePathID");
            AddForeignKey("dbo.AreaIndoorImage", "AreaID", "dbo.Area", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Area", "ImagePathID", "dbo.ImagePath", "ID");
            AddForeignKey("dbo.AreaIndoorImage", "ImagePathID", "dbo.ImagePath", "ID", cascadeDelete: true);
        }
    }
}
