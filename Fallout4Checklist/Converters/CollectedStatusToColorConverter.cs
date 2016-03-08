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
    public class CollectedStatusToColorConverter : IValueConverter
    {
        private ColorConverter _colorConverter = new ColorConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CollectedStatuses val;
            var result = Enum.TryParse(value.ToString(), out val);

            if (val == CollectedStatuses.AllGear)
                return (Color)(_colorConverter.ConvertFrom("#5cb85c"));
            else if (val == CollectedStatuses.Incomplete)
                return (Color)(_colorConverter.ConvertFrom("#DB4105"));
            else if (val == CollectedStatuses.NonPurchasableOrLootableGear)
                return (Color)(_colorConverter.ConvertFrom("#337ab7"));

            return (Color)(_colorConverter.ConvertFrom("#CCCCCC"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
