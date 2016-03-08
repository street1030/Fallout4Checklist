using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class QuestStageRewardMap : MappingBase<QuestStageReward>
    {
        public QuestStageRewardMap()
        {
            HasKey(x => x.ID);
            Property(x => x.Prerequisite).HasMaxLength(200);
            Property(x => x.RewardTypeID).HasMaxLength(50);
            Property(x => x.Reward).HasMaxLength(100);
            HasRequired(x => x.RewardType)
                .WithMany(x => x.QuestStageRewards)
                .HasForeignKey(x => x.RewardTypeID);
        }
    }
}
