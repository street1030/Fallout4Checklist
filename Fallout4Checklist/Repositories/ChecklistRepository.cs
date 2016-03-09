using Fallout4Checklist.Entities;
using System.Linq;

namespace Fallout4Checklist.Repositories
{
    public static class ChecklistRepository
    {
        public static Checklist CurrentChecklist { get; set; }

        public static Checklist GetCurrentChecklist(int id)
        {
            CurrentChecklist = Repository.Checklists.FirstOrDefault(x => x.ID == id);
            return CurrentChecklist;
        }
    }
}
