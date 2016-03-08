using Fallout4Checklist.Entities;

namespace Fallout4Checklist.ViewModels
{
    public class QuestRewardViewModel
    {
        public QuestRewardViewModel(Area area)
        {
            Content = $"{area.Name} as a settlement";
        }

        public QuestRewardViewModel(Companion companion)
        {
            Content = $"{companion.Name} as a companion";
        }

        public QuestRewardViewModel(Weapon weapon)
        {
            Content = weapon.Name;
        }

        public QuestRewardViewModel(Armor armor)
        {
            Content = armor.Name;
        }

        public QuestRewardViewModel(QuestStageReward reward)
        {
            if (reward.RewardTypeID == QuestStageRewardType.RewardTypes.Caps.ToString())
                IsCapImageVisible = true;
            else if (reward.RewardTypeID == QuestStageRewardType.RewardTypes.Title.ToString())
                Content = "Title: ";

            if (string.IsNullOrWhiteSpace(reward.Prerequisite))
                Content += $"{reward.Reward}";
            else
                Content += $"{reward.Reward} {reward.Prerequisite}";
        }

        public string Content { get; set; }
        public bool IsCapImageVisible { get; set; }
    }
}
