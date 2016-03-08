namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AreaPathPrecision : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AreaPath", "Height", c => c.Decimal(precision: 18, scale: 4));
            AlterColumn("dbo.AreaPath", "Width", c => c.Decimal(precision: 18, scale: 4));
            AlterColumn("dbo.AreaPath", "CanvasTop", c => c.Decimal(precision: 18, scale: 4));
            AlterColumn("dbo.AreaPath", "CanvasLeft", c => c.Decimal(precision: 18, scale: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AreaPath", "CanvasLeft", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AreaPath", "CanvasTop", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AreaPath", "Width", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AreaPath", "Height", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
