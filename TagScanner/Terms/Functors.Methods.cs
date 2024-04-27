namespace TagScanner.Terms
{
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System.Text.RegularExpressions;
    using Utils;

    public partial class Functors
    {
        #region Public Extension Methods

        public static int Compare(this string strA, string strB, bool caseSensitive) =>
            string.Compare(strA, strB, ignoreCase: !caseSensitive);

        public static string Concat_2(this string s, string t) => string.Concat(s, t);
        public static string Concat_3(this string s, string t, string u) => string.Concat(s, t, u);
        public static string Concat_4(this string s, string t, string u, string v) => string.Concat(s, t, u, v);

        public static bool Contains(this string input, string pattern, bool caseSensitive) =>
            input.ContainsX(Regex.Escape(pattern), caseSensitive);

        public static bool ContainsX(this string input, string pattern, bool caseSensitive) =>
            Regex.IsMatch(input, pattern, caseSensitive.AsRegexOptions());

        public static bool Empty(this string input) => string.IsNullOrWhiteSpace(input);

        public static bool EndsWith(this string input, string pattern, bool caseSensitive) =>
            input.EndsWithX($"{Regex.Escape(pattern)}$", caseSensitive);

        public static bool EndsWithX(this string input, string pattern, bool caseSensitive) =>
            Regex.IsMatch(input, $"{pattern}$", caseSensitive.AsRegexOptions());

        public static bool Equals(this string input, string pattern, bool caseSensitive) =>
            input.EqualsX(Regex.Escape(pattern), caseSensitive);

        public static bool EqualsX(this string input, string pattern, bool caseSensitive) =>
            input.ContainsX($"^{pattern}$", caseSensitive);

        public static int IndexOf(string input, string pattern, bool caseSensitive) =>
            input.IndexOf(pattern, caseSensitive, useRegex: false, first: true);

        public static int IndexOfX(string input, string pattern, bool caseSensitive) =>
            input.IndexOf(pattern, caseSensitive, useRegex: true, first: true);

        public static string Insert(this string input, int startIndex, string value) =>
            input.Insert(startIndex, value);

        public static int LastIndexOf(string input, string pattern, bool caseSensitive) =>
            input.IndexOf(pattern, caseSensitive, useRegex: false, first: false);

        public static int LastIndexOfX(string input, string pattern, bool caseSensitive) =>
            input.IndexOf(pattern, caseSensitive, useRegex: true, first: false);

        public static int Length(this string input) => input.Length;

        public static string Lowercase(this string input) => input.ToLowerInvariant();

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

        public static string Substring(this string input, int startIndex, int length) =>
            input.Substring(startIndex, length);

        public static string ToString(this object input) => input?.ToString() ?? string.Empty;

        public static string Trim(this string input) => input?.Trim() ?? string.Empty;

        public static string Uppercase(this string input) => input.ToUpperInvariant();

        #endregion

        #region Private Methods

        private static int IndexOf(this string input, string pattern, bool caseSensitive, bool useRegex, bool first)
        {
            if (!useRegex)
                pattern = Regex.Escape(pattern);
            var matches = Regex.Matches(input, pattern, caseSensitive.AsRegexOptions());
            var count = matches.Count;
            return count == 0 ? -1 : matches[first ? 0 : count - 1].Index;
        }

        #endregion
    }
}
