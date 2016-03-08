using Fallout4Checklist.Converters.TypeConverters;
using System;
using System.Windows.Data;

namespace Fallout4Checklist.Converters
{
    public class BoolToColumnVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return BooleanConverter.Convert(value, "1.5*", "0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
