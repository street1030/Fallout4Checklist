using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class QuestStageRewardTypeMap : MappingBase<QuestStageRewardType>
    {
        public QuestStageRewardTypeMap()
        {
            HasKey(x => x.RewardType);
            Property(x => x.RewardType).HasMaxLength(50);
        }
    }
}
