using Caliburn.Micro;
using Fallout4Checklist.Entities;
using Fallout4Checklist.Events;
using Fallout4Checklist.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Fallout4Checklist.ViewModels
{
    public class QuestListItemViewModel : CheckableItem
    {
        public QuestListItemViewModel(Quest quest)
        {
            Quest = quest;
            InitializeViewModel(quest);
        }

        public override bool IsChecked
        {
            get
            {
                return Quest.IsChecked;
            }
            set
            {
                Quest.IsChecked = value;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }

        public Quest Quest { get; set; }
        public List<QuestRewardViewModel> Rewards { get; set; }

        public void QuestClicked() => CaliburnBootstrapper.EventAggregator.PublishOnUIThreadAsync(new QuestClicked(Quest.ID));

        private void InitializeViewModel(Quest quest)
        {
            Rewards = new List<QuestRewardViewModel>();

            quest.OtherRewards
                .DistinctBy(x => x.Reward)
                .ToList()
                .ForEach(x => Rewards.Add(new QuestRewardViewModel(x)));

            quest.ArmorRewards
                .DistinctBy(x => x.ID)
                .ToList()
                .ForEach(x => Rewards.Add(new QuestRewardViewModel(x)));

            quest.CompanionRewards
                .DistinctBy(x => x.Name)
                .ToList()
                .ForEach(x => Rewards.Add(new QuestRewardViewModel(x)));

            quest.SettlementRewards
                .DistinctBy(x => x.ID)
                .ToList()
                .ForEach(x => Rewards.Add(new QuestRewardViewModel(x)));

            quest.WeaponRewards
                .DistinctBy(x => x.ID)
                .ToList()
                .ForEach(x => Rewards.Add(new QuestRewardViewModel(x)));

            Rewards = Rewards.OrderBy(x => x.IsCapImageVisible).ToList();
        }
    }
}
