using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ChecklistQuestMap : MappingBase<ChecklistQuest>
    {
        public ChecklistQuestMap()
        {
            HasKey(x => new { x.ChecklistID, x.QuestID });

            HasRequired(x => x.Checklist)
                .WithMany(x => x.QuestCollectedStatus)
                .HasForeignKey(x => x.ChecklistID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Quest)
                .WithMany(x => x.ChecklistCollectedStatus)
                .HasForeignKey(x => x.QuestID)
                .WillCascadeOnDelete(false);
        }
    }
}
