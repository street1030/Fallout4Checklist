using GMap.NET.MapProviders;
using GMap.NET.Projections;
using GMap.NET.WindowsPresentation;
using System;
using System.IO;

namespace Fallout4Checklist.Controls
{
    public class OverworldMapProvider : GMapProvider
    {
        private readonly Guid id = new Guid("09d366d6-95c3-4e88-b60d-c7ebfa90df23");
        public override Guid Id
        {
            get
            {
                return id;
            }
        }

        private readonly string name = "OverworldMap";
        public override string Name
        {
            get
            {
                return name;
            }
        }

        private GMapProvider[] overlays;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                    overlays = new GMapProvider[] { this };

                return overlays;
            }
        }

        public override GMap.NET.PureImage GetTileImage(GMap.NET.GPoint pos, int zoom)
        {
            var path = $"{Environment.CurrentDirectory}\\Images\\Map\\{zoom}\\{pos.X}\\{pos.Y}.png";
            if (File.Exists(path)) return GMapImageProxy.Instance.FromArray(File.ReadAllBytes(path));

            var blankImagePath = $"{Environment.CurrentDirectory}\\Images\\blank.png";
            return GMapImageProxy.Instance.FromArray(File.ReadAllBytes(blankImagePath));
        }

        public override GMap.NET.PureProjection Projection
        {
            get
            {
                return MercatorProjection.Instance;
            }
        }
    }
}
