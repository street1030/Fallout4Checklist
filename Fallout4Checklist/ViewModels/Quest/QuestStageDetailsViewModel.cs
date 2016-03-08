using Fallout4Checklist.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Fallout4Checklist.ViewModels
{
    public class QuestStageDetailsViewModel
    {
        public QuestStageDetailsViewModel(QuestStage stage)
        {
            InitializeViewModel(stage);
        }

        public bool HasOtherRewards { get; set; }
        public List<WeaponStatsViewModel> WeaponRewards { get; set; }
        public List<ArmorStatsViewModel> ArmorRewards { get; set; }
        public List<QuestRewardViewModel> QuestRewards { get; set; }
        public List<QuestStageDetailsViewModel> NextStages { get; set; }
        public string Description { get; set; }
        public int QuestID { get; set; }
        public int Stage { get; set; }

        private void InitializeViewModel(QuestStage stage)
        {
            WeaponRewards = new List<WeaponStatsViewModel>();
            ArmorRewards = new List<ArmorStatsViewModel>();
            QuestRewards = new List<QuestRewardViewModel>();
            NextStages = new List<QuestStageDetailsViewModel>();
            QuestID = stage.QuestID;
            Stage = stage.Stage;
            Description = stage.Description;

            WeaponRewards.AddRange(stage.Weapons.Select(x => new WeaponStatsViewModel(x)));
            ArmorRewards.AddRange(stage.Armor.Select(x => new ArmorStatsViewModel(x)));
            QuestRewards.AddRange(stage.Companions.Select(x => new QuestRewardViewModel(x)));
            QuestRewards.AddRange(stage.Settlements.Select(x => new QuestRewardViewModel(x)));
            QuestRewards.AddRange(stage.OtherRewards.Select(x => new QuestRewardViewModel(x)));

            var nextStages = stage.GetNextStages();
            foreach (var item in nextStages)
                NextStages.Add(new QuestStageDetailsViewModel(item));

            HasOtherRewards = QuestRewards.Count > 0;
        }
    }
}
