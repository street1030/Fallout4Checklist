using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Specialized;
using Caliburn.Micro;
using Fallout4Checklist.Repositories;
using Fallout4Checklist.Events;

namespace Fallout4Checklist.ViewModels
{
    public class NavigationViewModel : IHandle<LocationBorderClick>, IHandle<QuestClicked>, IHandle<MenuItemClicked>
    {
        private IEventAggregator _eventAggregator = CaliburnBootstrapper.EventAggregator;
        public NavigationViewModel()
        {
            _eventAggregator.Subscribe(this);
            NavigationItems = GetNavigationItems();
        }

        public NavigationItemCollection NavigationItems { get; set; }
        public void Handle(LocationBorderClick message) => ActivateAreaDetails(message.AreaID);
        public void Handle(MenuItemClicked message) => ActivateAreaDetails(message.AreaID);

        public void NavigationItemClicked(NavigationItem item)
        {
            item.IsSelected = true;
            _eventAggregator.PublishOnUIThreadAsync(new NavigationItemClicked(item.ViewModelType));
        }

        public void ActivateAreaDetails(int areaID)
        {
            var area = Repository.Areas.FirstOrDefault(x => x.ID == areaID);
            if (area == null) return;

            var lastItem = NavigationItems.FirstOrDefault(x => x.ViewModelType == typeof(AreaDetailViewModel));
            if (lastItem == null) return;
            if (lastItem.IsVisible == false) lastItem.IsVisible = true;

            lastItem.Content = area.Name;
            lastItem.IsSelected = true;
        }

        public void Handle(QuestClicked message)
        {
            var quest = QuestRepository.GetQuestByID(message.QuestID);
            if (quest == null) return;

            var navItem = NavigationItems.FirstOrDefault(x => x.ViewModelType == typeof(QuestDetailsViewModel));
            if (navItem == null) return;
            if (navItem.IsVisible == false) navItem.IsVisible = true;

            navItem.Content = quest.Name;
            navItem.IsSelected = true;
        }

        private static NavigationItemCollection GetNavigationItems()
        {
            var items = new NavigationItemCollection();

            var checklistPicker = new NavigationItem("Checklist Picker", typeof(ChecklistPickerViewModel));
            var checklist = new NavigationItem("Checklist", typeof(MenuViewModel));
            var questTracker = new NavigationItem("Quest Tracker", typeof(QuestViewModel));
            var questDetails = new NavigationItem("Quest Details", typeof(QuestDetailsViewModel), false);
            var areaDetails = new NavigationItem("Area Details", typeof(AreaDetailViewModel), false);
            items.Add(checklistPicker);
            items.Add(checklist);
            items.Add(questTracker);
            items.Add(questDetails);
            items.Add(areaDetails);
            return items;
        }
    }

    public class NavigationItem : PropertyChangedBase
    {
        public NavigationItem(string content, Type viewModelType, bool isVisible = true)
        {
            ViewModelType = viewModelType;
            Content = content;
            IsVisible = isVisible;
        }

        public Type ViewModelType { get; set; }

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                NotifyOfPropertyChange(() => Content);
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }

        private bool _isVisible;
        private string _content;
        private bool _isSelected;
    }

    public class NavigationItemCollection : ObservableCollection<NavigationItem>
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in this)
                item.PropertyChanged += Item_PropertyChanged;

            var defaultItem = this.FirstOrDefault();
            if (defaultItem == null) return;

            defaultItem.IsSelected = true;
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var item = (NavigationItem)sender;
            if (e.PropertyName != PropertyInspector.GetPropertyName(() => item.IsSelected)) return;

            if (item.IsSelected == false) return;
            var otherItems = this.Where(x => x != item);

            foreach (var otherItem in otherItems)
                otherItem.IsSelected = false;
        }
    }
}
