namespace Fallout4Checklist.Entities
{
    public partial class ChecklistQuest
    {
        public int ChecklistID { get; set; }
        public int QuestID { get; set; }
        public bool IsCollected { get; set; }

        public virtual Checklist Checklist { get; set; }
        public virtual Quest Quest { get; set; }
    }
}
