namespace TagScanner.Utils
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Models;
    using Streaming;

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

        public static StreamFormat GetStreamFormat(this string fileName)
        {
            var ext = Path.GetExtension(fileName);
            switch (ext.ToLowerInvariant())
            {
                case ".id3lib": return StreamFormat.Binary;
                case ".id3libx": return StreamFormat.Xml;
                case ".json": return StreamFormat.Json;
                default: throw new NotImplementedException($"Unrecognised file type '{ext}'.");
            }
        }

        public static void ShowDialog(this Exception exception, IWin32Window owner = null) => exception.ShowDialog(owner, string.Empty);
        public static void ShowDialog(this Exception exception, string text) => exception.ShowDialog(null, text);

        public static void ShowDialog(this Exception exception, IWin32Window owner, string text)
        {
            string
                message = exception.Message,
                exceptionType = exception.GetType().Name;
            var innerException = exception.InnerException;
            if (innerException != null)
            {
                message = $"{message}\r\n{innerException.Message}";
                exceptionType = $"{exceptionType} ({innerException.GetType().Name})";
            }
            if (!string.IsNullOrWhiteSpace(text))
                message = $"{message}\r\n{text}";
            MessageBox.Show(owner, message, exceptionType, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string Say(this Type type)
        {
            if (type == null) return "null";
            if (type.IsArray)
                return $"{type.GetElementType().Say()}[]";
            if (type == typeof(bool)) return "bool";
            if (type == typeof(byte)) return "byte";
            if (type == typeof(char)) return "char";
            if (type == typeof(DateTime)) return "DateTime";
            if (type == typeof(decimal)) return "decimal";
            if (type == typeof(double)) return "double";
            if (type == typeof(float)) return "float";
            if (type == typeof(int)) return "int";
            if (type == typeof(long)) return "long";
            if (type == typeof(object)) return "object";
            if (type == typeof(sbyte)) return "sbyte";
            if (type == typeof(short)) return "short";
            if (type == typeof(string)) return "string";
            if (type == typeof(TimeSpan)) return "TimeSpan";
            if (type == typeof(uint)) return "uint";
            if (type == typeof(ulong)) return "ulong";
            if (type == typeof(ushort)) return "ushort";
            return type.Name;
        }

        public static string Range(this string s, CharacterRange range) => s.Substring(range.First, range.Length);

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
