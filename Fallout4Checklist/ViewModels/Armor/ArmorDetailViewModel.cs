using Fallout4Checklist.Entities;
using Fallout4Checklist.Models;
using Fallout4Checklist.ViewModels.Base;
using System.Collections.Generic;
using Fallout4Checklist.Repositories;

namespace Fallout4Checklist.ViewModels
{
    public class ArmorDetailViewModel : CollectableItemViewModel
    {
        public ArmorDetailViewModel(Armor armor)
        {
            Armor = armor;
            IsExpanded = !IsChecked;
            Stats = new ArmorStatsViewModel(armor);
        }

        public Armor Armor { get; set; }
        public override string Walkthrough => string.Empty;
        public override bool IsPurchased => Armor.IsPurchased;
        public override bool IsWornByNPC => Armor.IsWornByNPC;
        public override bool IsChecked
        {
            get { return Armor.IsChecked; }
            set
            {
                Armor.IsChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
                MenuRepository.SaveMenuSubItem(Armor);
                MenuRepository.UpdateRelatedQuest(Armor as IQuestReward, value);
            }
        }

        public List<ArmorEffect> Effects { get; set; }
        public ArmorStatsViewModel Stats { get; set; }
    }
}
