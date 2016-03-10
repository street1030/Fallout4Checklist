using Caliburn.Micro;
using Fallout4Checklist.Events;
using System.Collections.ObjectModel;

namespace Fallout4Checklist.ViewModels
{
    public class ShellViewModel : Conductor<Screen>, IHandle<LocationBorderClick>, IHandle<NavigationItemClicked>, 
        IHandle<QuestClicked>, IHandle<MenuItemClicked>
    {
        public ShellViewModel()
        {
            _eventAggregator.Subscribe(this);
            Navigation = new NavigationViewModel();
            Menu = new MenuViewModel();
            QuestTracker = new QuestViewModel();
            QuestDetails = new QuestDetailsViewModel();
            Info = new AreaDetailViewModel();
            Map = new MapViewModel();
            ChecklistPicker = new ChecklistPickerViewModel();
            DisplayName = "Fallout 4 Checklist";
            ActivateItem(ChecklistPicker);
        }

        public bool IsMenuVisible
        {
            get
            {
                return isMenuVisible;
            }
            set
            {
                isMenuVisible = value;
                NotifyOfPropertyChange(() => IsMenuVisible);
            }
        }

        public bool IsChecklistPickerVisible
        {
            get
            {
                return _isChecklistPickerVisible;
            }
            set
            {
                _isChecklistPickerVisible = value;
                NotifyOfPropertyChange(() => IsChecklistPickerVisible);
            }
        }

        public NavigationViewModel Navigation { get; set; }
        public MenuViewModel Menu { get; set; }
        public MapViewModel Map { get; set; }
        public QuestViewModel QuestTracker { get; set; }
        public QuestDetailsViewModel QuestDetails { get; set; }
        public AreaDetailViewModel Info { get; set; }
        public ObservableCollection<Screen> Maps { get; set; }
        public ChecklistPickerViewModel ChecklistPicker { get; set; }
        private IEventAggregator _eventAggregator = CaliburnBootstrapper.EventAggregator;
        private bool _isChecklistPickerVisible;
        private bool isMenuVisible = true;

        public void ChangeMenuVisibility() => IsMenuVisible = !isMenuVisible;
        public void Handle(QuestClicked message) => ActivateItem(QuestDetails);
        public void Handle(LocationBorderClick message) => ActivateItem(Info);
        public void Handle(MenuItemClicked message) => ActivateItem(Info);

        public void Handle(NavigationItemClicked message)
        {
            if (Menu.GetType() == message.ControlType)
                ActivateItem(Menu);
            else if (Info.GetType() == message.ControlType)
                ActivateItem(Info);
            else if (QuestTracker.GetType() == message.ControlType)
                ActivateItem(QuestTracker);
            else if (QuestDetails.GetType() == message.ControlType)
                ActivateItem(QuestDetails);
            else if (ChecklistPicker.GetType() == message.ControlType)
                ActivateItem(ChecklistPicker);
        }
    }
}
