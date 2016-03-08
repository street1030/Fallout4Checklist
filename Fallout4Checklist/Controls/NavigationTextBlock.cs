using System.Windows;
using System.Windows.Controls;

namespace Fallout4Checklist.Controls
{
    public class NavigationTextBlock : TextBlock
    {
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(NavigationTextBlock), new UIPropertyMetadata(false));

        public bool IsSelected
        {
            get
            {
                return (bool)GetValue(IsSelectedProperty);
            }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }
    }
}
