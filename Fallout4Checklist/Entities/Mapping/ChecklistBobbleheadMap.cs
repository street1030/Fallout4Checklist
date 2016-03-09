using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ChecklistBobbleheadMap : MappingBase<ChecklistBobblehead>
    {
        public ChecklistBobbleheadMap()
        {
            HasKey(x => new { x.ChecklistID, x.BobbleheadID });

            HasRequired(x => x.Checklist)
                .WithMany(x => x.BobbleheadCollectedStatus)
                .HasForeignKey(x => x.ChecklistID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Bobblehead)
                .WithMany(x => x.ChecklistCollectedStatus)
                .HasForeignKey(x => x.BobbleheadID)
                .WillCascadeOnDelete(false);
        }
    }
}
