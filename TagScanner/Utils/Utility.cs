namespace TagScanner.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    public static class Utility
    {
        #region Public Interface

        public static Logical AsLogical(this bool value) => value ? Logical.Yes : Logical.No;

        public static string AsOrdinal(this long number) => string.Concat(number, GetSuffix(number));

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

        /// <summary>
        /// Return the first non-void string value from a pair.
        /// </summary>
        /// <param name="a">First string value.</param>
        /// <param name="b">Second string value.</param>
        /// <returns>Value a, if a is non-null, non-empty, and not just whitespace; otherwise, value b.</returns>
        public static string Coalesce(this string a, string b) => !string.IsNullOrWhiteSpace(a) ? a : b;

        /*public static string Format(this object value, string propertyName, Type type, bool exact)
        {
            if (value == null)
                return string.Empty;
            switch (propertyName)
            {
                case Tags.Duration:
                    return ((TimeSpan)value).AsString(exact);
                case Tags.FileSize:
                    var fileSize = (long)value;
                    return exact ? $"{fileSize:n0}" : fileSize.AsString(true);
                case Tags.Year:
                    return (int)value == 0 ? string.Empty : value.ToString();
            }
            return
                type == typeof(int?) || type == typeof(uint?) || type == typeof(long?)
                    ? Convert.ToInt64(value) == 0 ? string.Empty : $"{value:n0}"
                    : value.ToString();
        }*/

        public static string Escape(this string s) => s.Replace("&", "&&");
        public static RectangleF Expand(this RectangleF r) => r.IsEmpty ? r : new RectangleF(r.X, r.Y, r.Width + 99, r.Height);
        public static string GetIndex(this string s) => string.IsNullOrWhiteSpace(s) ? " " : (s.ToUpper() + " ").Substring(0, 1);

        /// <summary>
        /// Note that Path.GetInvalidFileNameChars() returns all the same characters as Path.GetInvalidPathChars() used in the companion method IsValidFilePath(),
        /// but with the additions that the colon : asterisk * question mark ? slash / and backslash \ are also considered invalid.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsValidFileName(this string s) => s.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;

        /// <summary>
        /// Note that Path.GetInvalidPathChars() returns all the same characters as Path.GetInvalidFileNameChars() used in the companion method IsValidFileName(),
        /// with the exception that the colon : asterisk * question mark ? slash / and backslash \ are considered valid.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsValidFilePath(this string s) => s.IndexOfAny(Path.GetInvalidPathChars()) < 0;

        public static void ShowDialog(this Exception exception, IWin32Window owner = null) => exception.ShowDialog(owner, string.Empty);
        public static void ShowDialog(this Exception exception, string text) => exception.ShowDialog(null, text);

        public static void ShowDialog(this Exception exception, IWin32Window owner, string text) =>
            MessageBox.Show(owner,
                $"{exception.GetAllMessages()}. {text}",
                exception.GetAllExceptionTypes(),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

        public static string GetAllExceptionTypes(this Exception exception)
        {
            var result = exception.GetType().Name;
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                result = $"{result} ({exception.GetType().Name})";
            }
            return result;
        }

        public static string GetAllInformation(this Exception exception)
        {
            var result = $"{exception.GetType().Name}: {exception.Message}";
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                result = $"{result} ({exception.GetType().Name}: {exception.Message})";
            }
            return result;
        }

        public static string GetAllMessages(this Exception exception)
        {
            var result = exception.Message;
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                result = $"{result} ({exception.Message})";
            }
            return result;
        }

        public static string Range(this string s, CharacterRange range) => s.Substring(range.First, range.Length);

        public static string StringsToText(this IEnumerable<string> strings)
        {
            if (strings == null || !strings.Any()) return string.Empty;
            return strings.Aggregate((p, q) => $"{p}{Environment.NewLine}{q}");
        }

        public static string[] TextToStrings(this string s)
        {
            return s == null
                ? Array.Empty<string>()
                : s.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        #endregion

        #region Private Implementation

        private static string GetSuffix(long number)
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

        #endregion
    }
}
