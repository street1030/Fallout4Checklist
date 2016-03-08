namespace Fallout4Checklist.Entities
{
    public partial class QuestStageReward
    {
        public int ID { get; set; }
        public string Reward { get; set; }
        public string Prerequisite { get; set; }

        public string RewardTypeID { get; set; }
        public virtual QuestStageRewardType RewardType { get; set; }

        public int QuestID { get; set; }
        public int StageID { get; set; }
        public virtual QuestStage QuestStage { get; set; }
    }
}
