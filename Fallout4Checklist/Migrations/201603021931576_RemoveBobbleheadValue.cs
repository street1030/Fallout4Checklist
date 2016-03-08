namespace Fallout4Checklist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Text;
    public partial class RemoveBobbleheadValue : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bobblehead", "Value");

            var deleteAndInsertPaths = Encoding.Default.GetString(Properties.Resources._03042016DeleteThenInsertPath);
            var moreUpdatedPaths = Encoding.Default.GetString(Properties.Resources._03042016UpdatePaths);
            var moreNewPaths = Encoding.Default.GetString(Properties.Resources._03042016InsertPaths);
            var updateImagePaths = Encoding.Default.GetString(Properties.Resources.UpdateImagePaths);
            var fixMagazineAreaID = Encoding.Default.GetString(Properties.Resources._03042016FixMagazineAreaID);
            var insertNewImagePaths = Encoding.Default.GetString(Properties.Resources._03042016InsertMissingWeaponImagePaths);
            var updateWeaponImagePath = Encoding.Default.GetString(Properties.Resources._03042016WeaponImagePaths);
            var magazineWalkthrough = Encoding.Default.GetString(Properties.Resources._03072016MagazineWalkthroughs);

            Sql(deleteAndInsertPaths);
            Sql(moreUpdatedPaths);
            Sql(moreNewPaths);
            Sql(updateImagePaths);
            Sql(fixMagazineAreaID);
            Sql(insertNewImagePaths);
            Sql(updateWeaponImagePath);
            Sql(magazineWalkthrough);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bobblehead", "Value", c => c.Int(nullable: false));
        }
    }
}
