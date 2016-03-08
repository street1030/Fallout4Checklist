namespace Fallout4Checklist.Events
{
    public class QuestClicked
    {
        public QuestClicked(int questID)
        {
            QuestID = questID;
        }

        public int QuestID { get; set; }
    }
}
