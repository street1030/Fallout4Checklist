using System;

namespace Fallout4Checklist.Converters.TypeConverters
{
    public static class BooleanConverter
    {
        public static object Convert(object value, object trueOutput, object falseOutput)
        {
            return (GetValue(value)) ? trueOutput : falseOutput;
        }

        private static bool GetValue(object value)
        {
            bool val;
            var result = Boolean.TryParse(value.ToString(), out val);
            if (!result) return false;
            return val;
        }
    }
}
