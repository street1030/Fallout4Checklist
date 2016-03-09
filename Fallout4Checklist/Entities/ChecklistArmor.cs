namespace Fallout4Checklist.Entities
{
    public partial class ChecklistArmor
    {
        public int ChecklistID { get; set; }
        public int ArmorID { get; set; }
        public bool IsCollected { get; set; }

        public virtual Checklist Checklist { get; set; }
        public virtual Armor Armor { get; set; }
    }
}
