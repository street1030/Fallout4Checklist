using Fallout4Checklist.Entities;
using Fallout4Checklist.Models;
using Fallout4Checklist.Repositories;
using Fallout4Checklist.ViewModels.Base;
using System.Linq;

namespace Fallout4Checklist.ViewModels
{
    public class BobbleheadDetailViewModel : CollectableItemViewModel
    {
        public BobbleheadDetailViewModel(Bobblehead bobblehead)
        {
            Bobblehead = bobblehead;
            IsExpanded = !IsChecked;
        }

        public Bobblehead Bobblehead { get; set; }
        public override string Walkthrough => Bobblehead.Walkthrough;
        public override bool IsPurchased => false;
        public override bool IsWornByNPC => false;
        public override bool IsChecked
        {
            get { return Bobblehead.IsChecked; }
            set
            {
                Bobblehead.IsChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
                MenuRepository.SaveMenuSubItem(Bobblehead);
                MenuRepository.UpdateRelatedQuest(Bobblehead as IQuestReward, value);
            }
        }
    }
}
