namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePowerArmor : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Armor", "ArmorSetID", "dbo.ArmorSets");
            //DropForeignKey("dbo.Armor", "BaseArmorID", "dbo.Armor");
            //DropForeignKey("dbo.PowerArmorEffect", "PowerArmorID", "dbo.PowerArmor");
            //DropForeignKey("dbo.ArmorSlotPowerArmor", "PowerArmorID", "dbo.PowerArmor");
            //DropForeignKey("dbo.ArmorSlotPowerArmor", "SlotID", "dbo.ArmorSlot");
            //DropForeignKey("dbo.QuestStagePowerArmor", new[] { "QuestID", "StageID" }, "dbo.QuestStage");
            //DropForeignKey("dbo.QuestStagePowerArmor", "PowerArmorID", "dbo.PowerArmor");
            //DropIndex("dbo.Armor", new[] { "BaseArmorID" });
            //DropIndex("dbo.Armor", new[] { "ArmorSetID" });
            //DropIndex("dbo.PowerArmorEffect", new[] { "PowerArmorID" });
            //DropIndex("dbo.ArmorSlotPowerArmor", new[] { "PowerArmorID" });
            //DropIndex("dbo.ArmorSlotPowerArmor", new[] { "SlotID" });
            //DropIndex("dbo.QuestStagePowerArmor", new[] { "QuestID", "StageID" });
            //DropIndex("dbo.QuestStagePowerArmor", new[] { "PowerArmorID" });
            AddColumn("dbo.Armor", "Health", c => c.Int());
            AddColumn("dbo.Armor", "IsPowerArmor", c => c.Boolean(nullable: false));
            DropColumn("dbo.Armor", "BaseArmorID");
            DropColumn("dbo.Armor", "ArmorSetID");
            //DropTable("dbo.ArmorSet");
            //DropTable("dbo.PowerArmor");
            //DropTable("dbo.PowerArmorEffect");
            //DropTable("dbo.ArmorSlotPowerArmor");
            //DropTable("dbo.QuestStagePowerArmor");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuestStagePowerArmor",
                c => new
                    {
                        QuestID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        PowerArmorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestID, t.StageID, t.PowerArmorID });
            
            CreateTable(
                "dbo.ArmorSlotPowerArmor",
                c => new
                    {
                        PowerArmorID = c.Int(nullable: false),
                        SlotID = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.PowerArmorID, t.SlotID });
            
            CreateTable(
                "dbo.PowerArmorEffect",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Effect = c.String(maxLength: 200),
                        PowerArmorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Value = c.Int(nullable: false),
                        IsMenuItem = c.Boolean(nullable: false),
                        Collected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ArmorSet",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Armor", "ArmorSetID", c => c.String(maxLength: 100));
            AddColumn("dbo.Armor", "BaseArmorID", c => c.Int());
            DropColumn("dbo.Armor", "IsPowerArmor");
            DropColumn("dbo.Armor", "Health");
            CreateIndex("dbo.QuestStagePowerArmor", "PowerArmorID");
            CreateIndex("dbo.QuestStagePowerArmor", new[] { "QuestID", "StageID" });
            CreateIndex("dbo.ArmorSlotPowerArmor", "SlotID");
            CreateIndex("dbo.ArmorSlotPowerArmor", "PowerArmorID");
            CreateIndex("dbo.PowerArmorEffect", "PowerArmorID");
            CreateIndex("dbo.Armor", "ArmorSetID");
            CreateIndex("dbo.Armor", "BaseArmorID");
            AddForeignKey("dbo.QuestStagePowerArmor", "PowerArmorID", "dbo.PowerArmor", "ID", cascadeDelete: true);
            AddForeignKey("dbo.QuestStagePowerArmor", new[] { "QuestID", "StageID" }, "dbo.QuestStage", new[] { "QuestID", "Stage" }, cascadeDelete: true);
            AddForeignKey("dbo.ArmorSlotPowerArmor", "SlotID", "dbo.ArmorSlot", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ArmorSlotPowerArmor", "PowerArmorID", "dbo.PowerArmor", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PowerArmorEffect", "PowerArmorID", "dbo.PowerArmor", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Armor", "BaseArmorID", "dbo.Armor", "ID");
            AddForeignKey("dbo.Armor", "ArmorSetID", "dbo.ArmorSet", "ID");
        }
    }
}
