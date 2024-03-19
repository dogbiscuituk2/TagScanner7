namespace TagScanner.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Utils;

    public class FileSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is long ? ((long)value).AsString(false) : value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
