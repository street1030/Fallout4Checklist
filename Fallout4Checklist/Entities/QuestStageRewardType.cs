using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class QuestStageRewardType
    {
        public QuestStageRewardType()
        {
            QuestStageRewards = new List<QuestStageReward>();
        }

        public string RewardType { get; set; }

        public virtual ICollection<QuestStageReward> QuestStageRewards { get; set; }
    }
}
