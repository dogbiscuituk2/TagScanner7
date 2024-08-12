namespace TagScanner.Core
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class StringUtils
    {
        public static string AsOrdinal(this ulong number) => string.Concat(number, GetSuffix(number));

        public static RegexOptions AsRegexOptions(this bool caseSensitive) =>
            caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;

        public static StringComparison AsStringComparison(this bool caseSensitive) =>
            caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

        /// <summary>
        /// Approximate a byte count to three significant figures, using the most suitable prefix as necessary.
        /// 
        /// Examples:
        /// 
        /// 1,023 -> "1023 Bytes"
        /// 1,024 -> "1.00 KB"
        /// 2,345,678 -> "2.24 MB"
        /// 9,012,345,678 -> "8.39 GB"
        /// 
        /// </summary>
        /// <param name="bytes">The exact number of bytes to be represented.</param>
        /// <param name="binary">When true, use the appropriate IEC-preferred binary prefix:
        /// 1 KiB = 1,024 bytes; 1 MiB = 1,048,576 bytes; etc.
        /// When false, use the appropriate SI decimal prefix:
        /// 1 KB = 1,000 bytes; 1 MB = 1,000,000 bytes; etc.</param>
        /// <returns>A string representation of the byte count to three significant figures,
        /// using the most suitable prefix if necessary.</returns>
        public static string AsString(this long bytes, bool binary)
        {
            const string units = "KMGTPE";
            for (var scale = units.Length; scale > 0; scale--)
            {
                var chunk = binary ? 1L << 10 * scale : (long)Math.Pow(1000, scale);
                if (bytes >= chunk)
                {
                    var value = decimal.Divide(bytes, chunk);
                    return string.Format(
                        $"{{0:{(value >= 100 ? "#" : value >= 10 ? "#.#" : "#.##")}}} {{1}}{{2}}B",
                            value, units[scale - 1], binary ? "i" : "");
                }
            }
            return $"{bytes} Bytes";
        }

        public static string AsString(this TimeSpan t, bool exact)
        {
            var format = @"d\.hh\:mm\:ss".Substring(t.Days > 0 ? 0 : t.Hours > 0 ? 4 : 8);
            if (exact)
                format += @"\.fff";
            return t.ToString(format);
        }

        public static string Escape(this string s, char c = '&') => s.Replace($"{c}", $"{c}{c}");
        public static string GetIndex(this string s) => string.IsNullOrWhiteSpace(s) ? " " : (s.ToUpper() + " ").Substring(0, 1);

        public static string GetSuffix(ulong number)
        {
            switch (number % 100)
            {
                case 11:
                case 12:
                case 13:
                    return "th";
            }
            switch (number % 10)
            {
                case 1: return "st";
                case 2: return "nd";
                case 3: return "rd";
            }
            return "th";
        }

        public static bool IsComment(this string text) => text.StartsWith("/*") || text.StartsWith("//");

        public static string Join(this IEnumerable<string> strings, string separator) =>
            strings == null || !strings.Any()
            ? string.Empty
            : strings.Aggregate((p, q) => $"{p}{separator}{q}");

        public static string Range(this string s, CharacterRange range) => s.Substring(range.First, range.Length);

        public static string StringsToText(this IEnumerable<string> strings) => strings.Join(Environment.NewLine);

        public static string[] TextToStrings(this string text) => text == null
            ? Array.Empty<string>()
            : text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    }
}
