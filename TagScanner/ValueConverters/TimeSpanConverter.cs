namespace TagScanner.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Models;

    public class TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is TimeSpan span ? span.AsString(false) : value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
