using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fallout4Checklist.Controls
{
    public class BubblingScrollViewer : ScrollViewer
    {
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            var isScrollingDown = (e.Delta <= 0);
            if ((isScrollingDown && VerticalOffset == ScrollableHeight) ||
                (!isScrollingDown && VerticalOffset == 0))
            {
                if (Parent == null) return;
                var parent = (UIElement)Parent;
                parent.RaiseEvent(e);
                return;
            }

            base.OnMouseWheel(e);
        }
    }
}
