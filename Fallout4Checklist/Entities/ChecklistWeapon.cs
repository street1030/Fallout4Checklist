namespace Fallout4Checklist.Entities
{
    public partial class ChecklistWeapon
    {
        public int ChecklistID { get; set; }
        public int WeaponID { get; set; }
        public bool IsCollected { get; set; }

        public virtual Checklist Checklist { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
