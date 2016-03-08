using System;
using Fallout4Checklist.Entities;
using Fallout4Checklist.ViewModels.Base;
using Fallout4Checklist.Repositories;
using Fallout4Checklist.Models;

namespace Fallout4Checklist.ViewModels
{
    public class CompanionDetailViewModel : CollectableItemViewModel
    {
        public CompanionDetailViewModel(Companion companion)
        {
            Companion = companion;
            IsExpanded = !IsChecked;            
        }

        public Companion Companion { get; set; }
        public override string Walkthrough => string.Empty;
        public override bool IsPurchased => false;
        public override bool IsWornByNPC => false;
        public override bool IsChecked
        {
            get { return Companion.IsChecked; }
            set
            {
                Companion.IsChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
                MenuRepository.SaveMenuSubItem(Companion);
                MenuRepository.UpdateRelatedQuest(Companion as IQuestReward, value);
            }
        }

        public bool HasPerkDescription => !string.IsNullOrWhiteSpace(Companion.PerkDescription);
    }
}
