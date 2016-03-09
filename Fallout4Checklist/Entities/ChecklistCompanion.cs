namespace Fallout4Checklist.Entities
{
    public partial class ChecklistCompanion
    {
        public int ChecklistID { get; set; }
        public string CompanionID { get; set; }
        public bool IsCollected { get; set; }

        public virtual Checklist Checklist { get; set; }
        public virtual Companion Companion { get; set; }
    }
}
