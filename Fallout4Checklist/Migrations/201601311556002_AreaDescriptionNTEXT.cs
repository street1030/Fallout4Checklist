namespace Fallout4Checklist.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AreaDescriptionNTEXT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Area", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Area", "Description", c => c.String(maxLength: 4000));
        }
    }
}
