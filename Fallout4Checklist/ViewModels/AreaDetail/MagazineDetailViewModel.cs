using Fallout4Checklist.Entities;
using Fallout4Checklist.Models;
using Fallout4Checklist.Repositories;
using Fallout4Checklist.ViewModels.Base;
using System;

namespace Fallout4Checklist.ViewModels
{
    public class MagazineDetailViewModel : CollectableItemViewModel
    {
        public MagazineDetailViewModel(Magazine magazine)
        {
            Magazine = magazine;
            IsExpanded = !IsChecked;
        }

        public Magazine Magazine { get; set; }
        public override string Walkthrough => Magazine.WalkthroughWithLineBreaks;
        public override bool IsPurchased => false;
        public override bool IsWornByNPC => false;
        public override bool IsChecked
        {
            get { return Magazine.IsChecked; }
            set
            {
                Magazine.IsChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
                MenuRepository.SaveMenuSubItem(Magazine);
                MenuRepository.UpdateRelatedQuest(Magazine as IQuestReward, value);
            }
        }
    }
}
