using Fallout4Checklist.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fallout4Checklist.Entities.Mapping
{
    public class QuestStageChainMap : MappingBase<QuestStageChain>
    {
        public QuestStageChainMap()
        {
            // Primary Key
            HasKey(t => new { t.QuestID, t.StageID, t.NextStageID });

            // Properties
            Property(t => t.QuestID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.StageID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.NextStageID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Relationships
            HasRequired(t => t.QuestStage)
                .WithMany(t => t.NextQuestStages)
                .HasForeignKey(d => new { d.QuestID, d.StageID })
                .WillCascadeOnDelete(false);

            HasRequired(t => t.NextQuestStage)
                .WithMany(t => t.PreviousQuestStages)
                .HasForeignKey(d => new { d.QuestID, d.NextStageID })
                .WillCascadeOnDelete(false);
        }
    }
}
