namespace Fallout4Checklist.Entities
{
    public partial class ChecklistBobblehead
    {
        public int ChecklistID { get; set; }
        public string BobbleheadID { get; set; }
        public bool IsCollected { get; set; }

        public virtual Checklist Checklist { get; set; }
        public virtual Bobblehead Bobblehead { get; set; }
    }
}
