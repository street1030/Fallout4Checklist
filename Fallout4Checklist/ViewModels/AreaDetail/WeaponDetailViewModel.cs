using Fallout4Checklist.Entities;
using Fallout4Checklist.Models;
using Fallout4Checklist.Repositories;
using Fallout4Checklist.ViewModels.Base;
using System.Linq;
using System;

namespace Fallout4Checklist.ViewModels
{
    public class WeaponDetailViewModel : CollectableItemViewModel
    {
        public WeaponDetailViewModel(Weapon weapon)
        {
            InitializeViewModel(weapon);
        }

        public Weapon Weapon { get; set; }
        public WeaponStatsViewModel WeaponStats { get; set; }
        public QuestListItemViewModel Quest { get; set; }
        public bool HasQuest => Quest != null;
        public override string Walkthrough => string.Empty;
        public override bool IsPurchased => Weapon.IsPurchased;
        public override bool IsWornByNPC => Weapon.IsWornByNPC;

        public override bool IsChecked
        {
            get { return Weapon.IsChecked; }
            set
            {
                Weapon.IsChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
                MenuRepository.SaveMenuSubItem(Weapon);
                MenuRepository.UpdateRelatedQuest(Weapon as IQuestReward, value);
            }
        }

        private void InitializeViewModel(Weapon weapon)
        {
            Weapon = weapon;
            WeaponStats = new WeaponStatsViewModel(weapon);
            
            if (weapon.Quests.Count > 0)
                Quest = new QuestListItemViewModel(weapon.Quests.First());
        }
    }
}
