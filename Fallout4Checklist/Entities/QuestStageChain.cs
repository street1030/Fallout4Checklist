namespace Fallout4Checklist.Entities
{
    public partial class QuestStageChain
    {
        public int QuestID { get; set; }
        public int StageID { get; set; }
        public virtual QuestStage QuestStage { get; set; }

        public int NextStageID { get; set; }
        public virtual QuestStage NextQuestStage { get; set; }
    }
}
