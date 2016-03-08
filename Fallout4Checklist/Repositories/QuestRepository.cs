using Fallout4Checklist.Entities;
using System.Linq;
using System.Data.Entity;

namespace Fallout4Checklist.Repositories
{
    public static class QuestRepository
    {
        public static Quest GetQuestByID(int id)
        {
            return Repository.Quests.FirstOrDefault(x => x.ID == id);
        }

        public static void UpdateQuestCompleted(Quest quest)
        {
            using (var context = new Fallout4ChecklistContext())
            {
                var dbMatch = context.Quests
                    .Include(x => x.QuestStages.Select(y => y.Armor))
                    .Include(x => x.QuestStages.Select(y => y.Weapons))
                    .Include(x => x.QuestStages.Select(y => y.Companions))
                    .FirstOrDefault(x => x.ID == quest.ID);

                if (dbMatch == null) return;
                dbMatch.Completed = quest.IsChecked;
                dbMatch.ArmorRewards.ForEach(x => x.IsChecked = quest.IsChecked);
                dbMatch.WeaponRewards.ForEach(x => x.IsChecked = quest.IsChecked);
                dbMatch.CompanionRewards.ForEach(x => x.IsChecked = quest.IsChecked);

                context.SaveChanges();
            }
        }
    }
}
