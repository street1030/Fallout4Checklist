using Fallout4Checklist.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Fallout4Checklist.Converters
{
    public class CollectedStatusToStrokeConverter : IValueConverter
    {
        private BrushConverter _brushConverter = new BrushConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CollectedStatuses val;
            var result = Enum.TryParse(value.ToString(), out val);

            if (val == CollectedStatuses.AllGear)
                return (SolidColorBrush)(_brushConverter.ConvertFrom("#5cb85c"));
            else if (val == CollectedStatuses.Incomplete)
                return (SolidColorBrush)(_brushConverter.ConvertFrom("#DB4105"));
            else if (val == CollectedStatuses.NonPurchasableOrLootableGear)
                return (SolidColorBrush)(_brushConverter.ConvertFrom("#337ab7"));

            return (SolidColorBrush)(_brushConverter.ConvertFrom("#CCCCCC"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
