namespace Fallout4Checklist.Entities
{
    public partial class ChecklistMagazine
    {
        public int ChecklistID { get; set; }
        public int MagazineID { get; set; }
        public bool IsCollected { get; set; }

        public virtual Checklist Checklist { get; set; }
        public virtual Magazine Magazine { get; set; }
    }
}
