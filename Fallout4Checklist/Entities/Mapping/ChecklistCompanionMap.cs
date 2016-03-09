using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ChecklistCompanionMap : MappingBase<ChecklistCompanion>
    {
        public ChecklistCompanionMap()
        {
            HasKey(x => new { x.ChecklistID, x.CompanionID });

            HasRequired(x => x.Checklist)
                .WithMany(x => x.CompanionCollectedStatus)
                .HasForeignKey(x => x.ChecklistID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Companion)
                .WithMany(x => x.ChecklistCollectedStatus)
                .HasForeignKey(x => x.CompanionID)
                .WillCascadeOnDelete(false);
        }
    }
}
