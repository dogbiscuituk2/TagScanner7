namespace TagScanner.Terms
{
    using System;
    using System.Text.RegularExpressions;

    public static class DateTimeParser
    {
        public const string
            TimePattern = @"(\d\d?)\:(\d\d?)(?:\:(\d\d?)(\.\d+)?)?",
            DateTimePattern = @"^\[(\d{4})-(\d\d?)\-(\d\d?)(?: " + TimePattern + @")?\]",
            TimeSpanPattern = @"^\[(?:(\d+)\.)?" + TimePattern + @"\]";

        public static DateTime ParseDateTime(string token)
        {
            // DateTimePattern captures 8 Groups.
            // [0] is the full DateTime (unused),
            // [1] is year,
            // [2] is month,
            // [3] is day,
            // [4] is hours,
            // [5] is minutes,
            // [6] is seconds,
            // [7] is fraction of a second, including a leading decimal point.
            var groups = Regex.Match(token, DateTimePattern).Groups;
            int year = int.Parse(groups[1].Value),
                month = int.Parse(groups[2].Value),
                day = int.Parse(groups[3].Value);
            int.TryParse(groups[4].Value, out var hours);
            int.TryParse(groups[5].Value, out var minutes);
            int.TryParse(groups[6].Value, out var seconds);
            double.TryParse(groups[7].Value, out var ms);
            return new DateTime(year, month, day, hours, minutes, seconds, (int)(ms * 1000));
        }

        public static TimeSpan ParseTimeSpan(string token)
        {
            // TimeSpan pattern captures 6 Groups.
            // [0] is the full TimeSpan (unused),
            // [1] is days,
            // [2] is hours,
            // [3] is minutes,
            // [4] is seconds,
            // [5] is fraction of a second, including a leading decimal point.
            var groups = Regex.Match(token, TimeSpanPattern).Groups;
            int.TryParse(groups[1].Value, out var days);
            int hours = int.Parse(groups[2].Value),
                minutes = int.Parse(groups[3].Value);
            int.TryParse(groups[4].Value, out var seconds);
            double.TryParse(groups[5].Value, out var ms);
            return new TimeSpan(days, hours, minutes, seconds, (int)(ms * 1000));
        }
    }
}
