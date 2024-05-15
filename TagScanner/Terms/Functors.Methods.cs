namespace TagScanner.Terms
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Models;
    using Utils;

    public partial class Functors
    {
        #region Public Extension Methods - Math

        public static double Max(this double x, double y) => Math.Max(x, y);
        public static double Min(this double x, double y) => Math.Min(x, y);
        public static double Pow(this double x, double y) => Math.Pow(x, y);
        public static double Round(this double value) => Math.Round(value);
        public static int Sign(this double value) => Math.Sign(value);
        public static double Truncate(this double value) => Math.Truncate(value);

        #endregion

        #region Public Extension Methods

        public static int Compare(this string strA, string strB, bool caseSensitive) =>
            string.Compare(strA, strB, ignoreCase: !caseSensitive);

        public static string Concat(params object[] values) =>
            Join(string.Empty, values);

        public static string Concat(this string s, string t) => string.Concat(s, t);
        public static string Concat(this string s, string t, string u) => string.Concat(s, t, u);
        public static string Concat(this string s, string t, string u, string v) => string.Concat(s, t, u, v);

        public static bool Contains(this string input, string pattern, bool caseSensitive) =>
            input.ContainsX(Regex.Escape(pattern), caseSensitive);

        public static bool ContainsX(this string input, string pattern, bool caseSensitive) =>
            Regex.IsMatch(input, pattern, caseSensitive.AsRegexOptions());

        public static int Count(this string input, string pattern, bool caseSensitive) =>
            input.CountX(Regex.Escape(pattern), caseSensitive);

        public static int CountX(this string input, string pattern, bool caseSensitive) =>
            Regex.Matches(input, pattern, caseSensitive.AsRegexOptions()).Count;

        public static bool Empty(this string input) => string.IsNullOrWhiteSpace(input);

        public static bool EndsWith(this string input, string pattern, bool caseSensitive) =>
            input.EndsWithX($"{Regex.Escape(pattern)}$", caseSensitive);

        public static bool EndsWithX(this string input, string pattern, bool caseSensitive) =>
            Regex.IsMatch(input, $"{pattern}$", caseSensitive.AsRegexOptions());

        public static bool Equals(this string input, string pattern, bool caseSensitive) =>
            input.EqualsX(Regex.Escape(pattern), caseSensitive);

        public static bool EqualsX(this string input, string pattern, bool caseSensitive) =>
            input.ContainsX($"^{pattern}$", caseSensitive);

        public static string Format(this string format, params object[] args) =>
            string.Format(format, args);

        public static int IndexOf(string input, string pattern, bool caseSensitive) =>
            input.IndexOf(pattern, caseSensitive, useRegex: false, first: true);

        public static int IndexOfX(string input, string pattern, bool caseSensitive) =>
            input.IndexOf(pattern, caseSensitive, useRegex: true, first: true);

        public static string Insert(this string input, int startIndex, string value) =>
            input.Insert(startIndex, value);

        public static string Join(this string separator, params object[] values) =>
            string.Join(separator, values);

        public static int LastIndexOf(string input, string pattern, bool caseSensitive) =>
            input.IndexOf(pattern, caseSensitive, useRegex: false, first: false);

        public static int LastIndexOfX(string input, string pattern, bool caseSensitive) =>
            input.IndexOf(pattern, caseSensitive, useRegex: true, first: false);

        public static int Length(this string input) => input.Length;

        public static string Lower(this string input) => input.ToLowerInvariant();

        public static string Remove(this string input, int startIndex, int count) =>
            input.Remove(startIndex, count);

        public static string Replace(this string input, string pattern, string replacement, bool caseSensitive) =>
            input.ReplaceX(Regex.Escape(pattern), replacement, caseSensitive);

        public static string ReplaceX(this string input, string pattern, string replacement, bool caseSensitive) =>
            Regex.Replace(input, pattern, replacement, caseSensitive.AsRegexOptions());

        public static bool StartsWith(this string input, string pattern, bool caseSensitive) =>
            input.StartsWithX($"^{Regex.Escape(pattern)}", caseSensitive);

        public static bool StartsWithX(this string input, string pattern, bool caseSensitive) =>
            Regex.IsMatch(input, $"^{pattern}", caseSensitive.AsRegexOptions());

        public static string Substring(this string input, int startIndex, int length)
        {
            var count = input.Length;
            if (startIndex >= count)
                return string.Empty;
            if (length > count - startIndex)
                length = count - startIndex;
            return input.Substring(startIndex, length);
        }

        public static string ToString(this object input) => input?.ToString() ?? string.Empty;

        public static string Trim(this string input) => input?.Trim() ?? string.Empty;

        public static string Upper(this string input) => input.ToUpperInvariant();

        public static Selection Where(this Selection list, Func<Track, bool> func) =>
            new Selection(list.Tracks.Where(p => func(p)));

        #endregion

        #region Private Methods

        private static int IndexOf(this string input, string pattern, bool caseSensitive, bool useRegex, bool first)
        {
            if (!useRegex)
                pattern = Regex.Escape(pattern);
            var options = caseSensitive.AsRegexOptions();
            var matches = Regex.Matches(input, pattern, options);
            var count = matches.Count;
            return count == 0 ? -1 : matches[first ? 0 : count - 1].Index;
        }

        #endregion
    }
}
