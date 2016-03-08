using Fallout4Checklist.Converters.TypeConverters;
using System;
using System.Windows;
using System.Windows.Data;

namespace Fallout4Checklist.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return BooleanConverter.Convert(value, Visibility.Visible, Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
