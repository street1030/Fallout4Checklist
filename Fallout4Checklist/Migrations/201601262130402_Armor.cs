namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Armor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        DamageResist = c.Int(nullable: false),
                        EnergyResist = c.Int(nullable: false),
                        RadiationResist = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Value = c.Int(nullable: false),
                        ArmorSetID = c.String(maxLength: 100),
                        ImagePathID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ArmorSets", t => t.ArmorSetID)
                .ForeignKey("dbo.ImagePath", t => t.ImagePathID)
                .Index(t => t.ArmorSetID)
                .Index(t => t.ImagePathID);
            
            CreateTable(
                "dbo.ArmorSets",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ArmorEffects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArmorID = c.Int(nullable: false),
                        Effect = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Armors", t => t.ArmorID, cascadeDelete: true)
                .Index(t => t.ArmorID);
            
            CreateTable(
                "dbo.ArmorSlots",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ArmorSlotArmor",
                c => new
                    {
                        ArmorID = c.Int(nullable: false),
                        SlotID = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.ArmorID, t.SlotID })
                .ForeignKey("dbo.Armors", t => t.ArmorID, cascadeDelete: true)
                .ForeignKey("dbo.ArmorSlots", t => t.SlotID, cascadeDelete: true)
                .Index(t => t.ArmorID)
                .Index(t => t.SlotID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArmorSlotArmor", "SlotID", "dbo.ArmorSlots");
            DropForeignKey("dbo.ArmorSlotArmor", "ArmorID", "dbo.Armors");
            DropForeignKey("dbo.Armors", "ImagePathID", "dbo.ImagePath");
            DropForeignKey("dbo.ArmorEffects", "ArmorID", "dbo.Armors");
            DropForeignKey("dbo.Armors", "ArmorSetID", "dbo.ArmorSets");
            DropIndex("dbo.ArmorSlotArmor", new[] { "SlotID" });
            DropIndex("dbo.ArmorSlotArmor", new[] { "ArmorID" });
            DropIndex("dbo.ArmorEffects", new[] { "ArmorID" });
            DropIndex("dbo.Armors", new[] { "ImagePathID" });
            DropIndex("dbo.Armors", new[] { "ArmorSetID" });
            DropTable("dbo.ArmorSlotArmor");
            DropTable("dbo.ArmorSlots");
            DropTable("dbo.ArmorEffects");
            DropTable("dbo.ArmorSets");
            DropTable("dbo.Armors");
        }
    }
}
