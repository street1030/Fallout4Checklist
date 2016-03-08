using Fallout4Checklist.Converters.TypeConverters;
using System;
using System.Windows.Data;

namespace Fallout4Checklist.Converters
{
    public class BoolToCollapseButtonContentConverter : IValueConverter
    {
        private readonly string trueValue = ((char)0xE0A6).ToString();
        private readonly string falseValue = ((char)0xE0AB).ToString();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return BooleanConverter.Convert(value, trueValue, falseValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
