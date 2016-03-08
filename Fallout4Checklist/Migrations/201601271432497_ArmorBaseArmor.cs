namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArmorBaseArmor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Armors", newName: "Armor");
            RenameTable(name: "dbo.ArmorSets", newName: "ArmorSet");
            RenameTable(name: "dbo.ArmorEffects", newName: "ArmorEffect");
            RenameTable(name: "dbo.ArmorSlots", newName: "ArmorSlot");
            AddColumn("dbo.Armor", "BaseArmorID", c => c.Int());
            CreateIndex("dbo.Armor", "BaseArmorID");
            AddForeignKey("dbo.Armor", "BaseArmorID", "dbo.Armor", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Armor", "BaseArmorID", "dbo.Armor");
            DropIndex("dbo.Armor", new[] { "BaseArmorID" });
            DropColumn("dbo.Armor", "BaseArmorID");
            RenameTable(name: "dbo.ArmorSlot", newName: "ArmorSlots");
            RenameTable(name: "dbo.ArmorEffect", newName: "ArmorEffects");
            RenameTable(name: "dbo.ArmorSet", newName: "ArmorSets");
            RenameTable(name: "dbo.Armor", newName: "Armors");
        }
    }
}
