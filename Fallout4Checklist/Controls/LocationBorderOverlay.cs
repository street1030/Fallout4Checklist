using Fallout4Checklist.Views;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using System.Collections.Generic;
using System.Drawing;

namespace Fallout4Checklist.Controls
{
    public class LocationBorderOverlay : GMapMarker
    {
        public LocationBorderOverlay(PointLatLng pos) : base(pos)
        {
            Resize(4);
            Shape = Overlay;
            ZIndex = 10;
        }

        private LocationBorderOverlayView Overlay = new LocationBorderOverlayView();
        private Dictionary<int, Size> OverlaySizes = new Dictionary<int, Size>
        {
            { 0, new Size(256, 256) },
            { 1, new Size(512, 512) },
            { 2, new Size(1024, 1024) },
            { 3, new Size(2048, 2048) },
            { 4, new Size(4096, 4096) },
            { 5, new Size(8192, 8192) },
            { 6, new Size(16384, 16384) }
        };

        public void Resize(int zoom)
        {
            var size = OverlaySizes.ContainsKey(zoom) ? OverlaySizes[zoom] : new Size(0, 0);
            Overlay.UserControl.Height = size.Height;
            Overlay.UserControl.Width = size.Width;
        }
    }
}
