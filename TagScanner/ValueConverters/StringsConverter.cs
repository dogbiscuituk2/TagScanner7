namespace TagScanner.ValueConverters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;

    public class StringsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is IEnumerable<string> strings)) return value;
            var stringArray = strings as string[] ?? strings.ToArray();
            return stringArray.Any() ? stringArray.Aggregate((p, q) => $"{p}{Environment.NewLine}{q}") : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
