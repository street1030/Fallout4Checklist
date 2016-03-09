using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ChecklistMagazineMap : MappingBase<ChecklistMagazine>
    {
        public ChecklistMagazineMap()
        {
            HasKey(x => new { x.ChecklistID, x.MagazineID });

            HasRequired(x => x.Checklist)
                .WithMany(x => x.MagazineCollectedStatus)
                .HasForeignKey(x => x.ChecklistID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Magazine)
                .WithMany(x => x.ChecklistCollectedStatus)
                .HasForeignKey(x => x.MagazineID)
                .WillCascadeOnDelete(false);
        }
    }
}
