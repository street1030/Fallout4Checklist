using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fallout4Checklist.Controls
{
    public class HoverCheckBox : CheckBox
    {
        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.Register("HoverBackground", typeof(Brush), typeof(HoverCheckBox), new UIPropertyMetadata(Brushes.Transparent));

        public Brush HoverBackground
        {
            get
            {
                return (Brush)GetValue(HoverBackgroundProperty);
            }
            set
            {
                SetValue(HoverBackgroundProperty, value);
            }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(HoverCheckBox), new UIPropertyMetadata(new CornerRadius(0)));

        public CornerRadius CornerRadius
        {
            get
            {
                return (CornerRadius)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }
    }
}
