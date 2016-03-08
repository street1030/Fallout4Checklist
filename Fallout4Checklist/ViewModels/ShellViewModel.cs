using Caliburn.Micro;
using Fallout4Checklist.Events;
using System.Collections.ObjectModel;
using Fallout4Checklist.Repositories;
using System;
using System.Dynamic;
using System.Windows;
using Fallout4Checklist.Views;

namespace Fallout4Checklist.ViewModels
{
    public class ShellViewModel : Conductor<Screen>, IHandle<LocationBorderClick>, IHandle<NavigationItemClicked>, 
        IHandle<QuestClicked>, IHandle<MenuItemClicked>
    {
        private IEventAggregator _eventAggregator = CaliburnBootstrapper.EventAggregator;
        public ShellViewModel()
        {
            _eventAggregator.Subscribe(this);
            //Points = new ObservableCollection<MarkerInfo>();
            Navigation = new NavigationViewModel();
            Menu = new MenuViewModel();
            QuestTracker = new QuestViewModel();
            QuestDetails = new QuestDetailsViewModel();
            Info = new AreaDetailViewModel();
            Map = new MapViewModel();
            DisplayName = "Fallout 4 Checklist";
            ActivateItem(Menu);
        }

        public string XY { get; set; }

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

        public NavigationViewModel Navigation { get; set; }
        public MenuViewModel Menu { get; set; }
        public MapViewModel Map { get; set; }
        public QuestViewModel QuestTracker { get; set; }
        public QuestDetailsViewModel QuestDetails { get; set; }
        public AreaDetailViewModel Info { get; set; }
        public ObservableCollection<Screen> Maps { get; set; }
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
        }

        //public void Handle(DeleteMe message)
        //{
        //    Points.Add(new MarkerInfo(message.Point, currentType));
        //}

        //public void CheckChanged(RadioButton button)
        //{
        //    if (!button.IsChecked.Value) return;
        //    currentType = button.Content.ToString();
        //}

        //public string currentType { get; set; }
        //public ObservableCollection<MarkerInfo> Points { get; set; }
    }

    //public class MarkerInfo
    //{
    //    public MarkerInfo(PointLatLng point, string type)
    //    {
    //        MarkerType = type;
    //        Point = point;
    //    }

    //    public string MarkerType { get; set; }
    //    public PointLatLng Point { get; set; }

    //    public string Text => $"{Point.Lat}, {Point.Lng}: {MarkerType}";
    //}
}
