namespace Fallout4Checklist.Events
{
    public class MenuItemClicked
    {
        public MenuItemClicked(int areaID)
        {
            AreaID = areaID;
        }

        public int AreaID { get; set; }
    }
}
