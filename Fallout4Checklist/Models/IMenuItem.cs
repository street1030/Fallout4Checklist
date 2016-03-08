namespace Fallout4Checklist.Models
{
    public interface IMenuItem
    {
        object EntityKey { get; }
        string Name { get; }
        string Location { get; }
        int? AreaID { get; }
        bool IsChecked { get; set; }
    }
}
