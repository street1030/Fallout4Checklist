using Fallout4Checklist.Events;
using System.Windows.Controls;
using Caliburn.Micro;

namespace Fallout4Checklist.Views
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapView : UserControl
    {
        public MapView()
        {
            InitializeComponent();
        }

        //private void Map_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    var p = e.GetPosition(this);
        //    var latLng = Map.FromLocalToLatLng((int)p.X, (int)p.Y);
        //    CaliburnBootstrapper.EventAggregator.PublishOnUIThreadAsync(new DeleteMe(latLng));
        //}
    }
}
