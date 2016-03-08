using Caliburn.Micro;
using Fallout4Checklist.Events;
using Fallout4Checklist.Repositories;
using System.Linq;

namespace Fallout4Checklist.Models.Menu
{
    public class MenuItem : CheckableItem
    {
        public MenuItem(IMenuItem entity)
        {
            Entity = entity;
        }

        public override bool IsChecked
        {
            get { return Entity.IsChecked; }
            set
            {
                Entity.IsChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
                NotifyOfPropertyChange(() => IsVisible);
                MenuRepository.SaveMenuSubItem(Entity);
                MenuRepository.UpdateRelatedQuest(Entity as IQuestReward, value);
            }
        }

        public IMenuItem Entity { get; private set; }

        public void ContentClicked()
        {
            var menuItem = (IAreaItem)Entity;
            if (menuItem == null || !menuItem.AreaID.HasValue) return;
            CaliburnBootstrapper.EventAggregator.PublishOnUIThreadAsync(new MenuItemClicked(menuItem.AreaID.Value));
        }
    }
}
