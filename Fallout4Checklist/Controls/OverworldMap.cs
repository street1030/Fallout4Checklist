using Caliburn.Micro;
using Fallout4Checklist.Events;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using System.Windows.Input;

namespace Fallout4Checklist.Controls
{
    public class OverworldMap : GMapControl
    {
        public OverworldMap() : base()
        {
            _eventAggregator.Subscribe(this);
            MapProvider = new OverworldMapProvider();
            Position = new PointLatLng(0, 0);
            Manager.Mode = AccessMode.ServerOnly;
            DragButton = MouseButton.Left;
            MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            ShowCenter = false;
            MinZoom = 0;
            MaxZoom = 6;
            IgnoreMarkerOnMouseWheel = true;
            Overlay = new LocationBorderOverlay(new PointLatLng(90, -180));
            Markers.Add(Overlay);
            OnMapZoomChanged += OverworldMap_OnMapZoomChanged;
            PreviewMouseDoubleClick += OverworldMap_PreviewMouseDoubleClick;
        }

        private LocationBorderOverlay Overlay;
        private IEventAggregator _eventAggregator = CaliburnBootstrapper.EventAggregator;
        
        void OverworldMap_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _eventAggregator.PublishOnBackgroundThread(new MapDoubleClick());
        }

        void OverworldMap_OnMapZoomChanged()
        {
           Overlay.Resize((int)Zoom);
        }
    }
}
