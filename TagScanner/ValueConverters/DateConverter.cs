﻿namespace TagScanner.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is DateTime dateTime ? dateTime.ToString("g") : value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
