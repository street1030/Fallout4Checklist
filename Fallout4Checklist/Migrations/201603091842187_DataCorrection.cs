using System.Data.Entity.Migrations;
using System.Text;

namespace Fallout4Checklist.Migrations
{
    public partial class DataCorrection : DbMigration
    {
        public override void Up()
        {
            var dataCorrection = Encoding.Default.GetString(Properties.Resources._03092016DataCorrection);
            Sql(dataCorrection);
        }
        
        public override void Down()
        {
        }
    }
}
