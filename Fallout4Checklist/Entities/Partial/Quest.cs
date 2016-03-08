using Caliburn.Micro;
using Fallout4Checklist.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Fallout4Checklist.Entities
{
    public partial class Quest : PropertyChangedBase
    {
        public bool IsChecked
        {
            get { return Completed; }
            set
            {
                Completed = value;

                ArmorRewards
                .Where(x => x.IsMenuItem)
                .ToList()
                .ForEach(x => x.IsChecked = value);

                WeaponRewards
                    .Where(x => x.IsMenuItem)
                    .ToList()
                    .ForEach(x => x.IsChecked = value);

                CompanionRewards.ForEach(x => x.IsChecked = value);

                QuestRepository.UpdateQuestCompleted(this);

                NotifyOfPropertyChange(() => IsChecked);
            }
        }

        public string XPReward => $"{XP} XP";
        public bool Failed { get; set; }
        public QuestStage FirstStage => QuestStages.FirstOrDefault(x => x.Stage == 1);
        public List<Weapon> WeaponRewards => QuestStages.SelectMany(x => x.Weapons).ToList();
        public List<Armor> ArmorRewards => QuestStages.SelectMany(x => x.Armor).ToList();
        public List<Companion> CompanionRewards => QuestStages.SelectMany(x => x.Companions).ToList();
        public List<Area> SettlementRewards => QuestStages.SelectMany(x => x.Settlements).ToList();
        public List<QuestStageReward> OtherRewards => QuestStages.SelectMany(x => x.OtherRewards).ToList();
    }
}
