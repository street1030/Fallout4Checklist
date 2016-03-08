using Fallout4Checklist.Models;
using System;
using Fallout4Checklist.Entities;
using System.Linq;

namespace Fallout4Checklist.Repositories
{
    public static class MenuRepository
    {
        public static void SaveMenuSubItem(IMenuItem item)
        {
            using (var context = new Fallout4ChecklistContext())
            {
                IMenuItem match = (IMenuItem)context.Set(item.GetType()).Find(item.EntityKey);
                if (match == null) return;

                match.IsChecked = item.IsChecked;
                context.SaveChanges();
            }
        }

        public static void UpdateRelatedQuest(IQuestReward item, bool isChecked)
        {
            if (item == null || item.QuestStages.Count == 0) return;

            var quest = item.QuestStages.First().Quest;
            quest.IsChecked = isChecked;
            quest.WeaponRewards.ForEach(x => x.IsChecked = isChecked);
            quest.ArmorRewards.ForEach(x => x.IsChecked = isChecked);
            quest.CompanionRewards.ForEach(x => x.IsChecked = isChecked);
            QuestRepository.UpdateQuestCompleted(quest);
        }
    }
}
