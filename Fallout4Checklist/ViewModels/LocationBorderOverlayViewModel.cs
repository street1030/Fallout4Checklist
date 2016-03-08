using Caliburn.Micro;
using Fallout4Checklist.Entities;
using Fallout4Checklist.Events;
using Fallout4Checklist.Repositories;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Fallout4Checklist.ViewModels
{
    public class LocationBorderOverlayViewModel : Screen, IHandle<MenuItemClicked>
    {
        public LocationBorderOverlayViewModel()
        {
            _eventAggregator.Subscribe(this);
            Paths = Repository.AreaPaths;
            Paths.ForEach(x => x.SetCollectedStatus());
        }

        public List<AreaPath> Paths { get; set; }

        public Visibility Visible { get; set; }
        private static IEventAggregator _eventAggregator = CaliburnBootstrapper.EventAggregator;

        public void PathClicked(AreaPath path)
        {
            _eventAggregator.PublishOnUIThreadAsync(new LocationBorderClick(path.AreaID));
        }

        public void Handle(MenuItemClicked message)
        {
            var path = Paths.FirstOrDefault(x => x.AreaID == message.AreaID);
            if (path == null) return;

            Paths.ForEach(x => x.IsAnimating = false);
            path.IsAnimating = true;
        }
    }
}
