namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PowerArmorAndEffects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PowerArmor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        DamageResist = c.Int(nullable: false),
                        EnergyResist = c.Int(nullable: false),
                        RadiationResist = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PowerArmorEffect",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PowerArmorID = c.Int(nullable: false),
                        Effect = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PowerArmor", t => t.PowerArmorID, cascadeDelete: true)
                .Index(t => t.PowerArmorID);
            
            CreateTable(
                "dbo.ArmorSlotPowerArmor",
                c => new
                    {
                        PowerArmorID = c.Int(nullable: false),
                        SlotID = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.PowerArmorID, t.SlotID })
                .ForeignKey("dbo.PowerArmor", t => t.PowerArmorID, cascadeDelete: true)
                .ForeignKey("dbo.ArmorSlot", t => t.SlotID, cascadeDelete: true)
                .Index(t => t.PowerArmorID)
                .Index(t => t.SlotID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArmorSlotPowerArmor", "SlotID", "dbo.ArmorSlot");
            DropForeignKey("dbo.ArmorSlotPowerArmor", "PowerArmorID", "dbo.PowerArmor");
            DropForeignKey("dbo.PowerArmorEffect", "PowerArmorID", "dbo.PowerArmor");
            DropIndex("dbo.ArmorSlotPowerArmor", new[] { "SlotID" });
            DropIndex("dbo.ArmorSlotPowerArmor", new[] { "PowerArmorID" });
            DropIndex("dbo.PowerArmorEffect", new[] { "PowerArmorID" });
            DropTable("dbo.ArmorSlotPowerArmor");
            DropTable("dbo.PowerArmorEffect");
            DropTable("dbo.PowerArmor");
        }
    }
}
