﻿namespace TagScanner.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using FastColoredTextBoxNS;
    using Models;
    using Terms;

    public static class Utility
    {
        #region Public Interface

        public static Logical AsLogical(this bool value) => value ? Logical.Yes : Logical.No;
        public static string AsOrdinal(this long number) => string.Concat(number, GetSuffix(number));

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

        public static string Escape(this string s, char c = '&') => s.Replace($"{c}", $"{c}{c}");
        public static RectangleF Expand(this RectangleF r) => r.IsEmpty ? r : new RectangleF(r.X, r.Y, r.Width + 99, r.Height);

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

        /// <summary>
        /// Find the longest initial segment of filesystem path shared by a given set of paths.
        /// Where multiple distinct paths are supplied, this will be the lowest level folder common to all the files.
        /// In the case of a single file, this will be the full path to that file.
        /// Adapted from http://rosettacode.org/wiki/Find_common_directory_path#C.23
        /// </summary>
        /// <param name="paths">The given set of file paths.</param>
        /// <returns>The lowest level common folder (or the file path, in the case of a single file).</returns>
        public static string GetCommonPath(IEnumerable<string> paths)
        {
            var result = string.Empty;
            if (paths != null && paths.Any())
            {
                var path = result;
                var maxLen = paths.Max(p => p.Length);
                var segments = paths.First(p => p.Length == maxLen).Split('\\').ToList();
                for (var index = 0; index < segments.Count; index++)
                {
                    var segment = $"{path}{segments[index]}";
                    if (!paths.All(p => p.StartsWith(segment)))
                        break;
                    path = segment;
                    if (index < segments.Count - 1)
                        path = $"{path}\\";
                }
                result = path;
            }
            return result;
        }

        /// <summary>
        /// Find the "best" type to represent the result of a dyadic operation using the given operands.
        /// </summary>
        /// <param name="type1">The first term of the dyadic operation.</param>
        /// <param name="type2">The second term of the dyadic operation.</param>
        /// <returns>Type that can be used to hold the operation's result.</returns>
        public static Type GetCommonType(this Type type1, Type type2)
        {
            // If these two types are the same, then just use that common type.
            if (type1 == type2) return type1;
            // If either type is null, then use the other.
            if (type1 == null) return type2;
            if (type2 == null) return type1;
            // If either type is "object", then use "object".
            if (IsType(typeof(object), type1, type2))
                return typeof(object);
            // If one is a value type and the other not, then use "object".
            if (type1.IsValueType ^ type2.IsValueType)
                    return typeof(object);
            // Otherwise, use the "wider" of the two different non-null types.
            return MatchType(typeof(double), type1, type2) // Type "double" absorbs any "float", "int" or "long".
                ?? MatchType(typeof(float), type1, type2) // Type "float" absorbs any "long" or "int".
                ?? MatchType(typeof(long), type1, type2) // Type "long" absorbs any "int".
                ?? MatchType(typeof(string), type1, type2); // Type "string" absorbs any "char".

            bool IsType(Type t, Type t1, Type t2) => t == t1 || t == t2;
            Type MatchType(Type t, Type t1, Type t2) => t == t1 || t == t2 ? t : null;
        }

        public static Type GetCompatibleType(params Type[] types)
        {
            switch (types.Length)
            {
                case 0:
                    return null;
                case 1:
                    return types[0];
                default:
                    var type = types[0].GetCommonType(types[1]);
                    for (int index = 2; index < types.Length; index++)
                        type = type.GetCommonType(types[index]);
                    return type;
            }
        }

        public static string GetIndex(this string s) => string.IsNullOrWhiteSpace(s) ? " " : (s.ToUpper() + " ").Substring(0, 1);

        public static Language GetLanguage(this string fileName)
        {
            var ext = Path.GetExtension(fileName);
            switch (ext.ToLowerInvariant())
            {
                case ".cs": return Language.CSharp;
                case ".vb": return Language.VB;
                case ".html": return Language.HTML;
                case ".xml": return Language.XML;
                case ".sql": return Language.SQL;
                case ".php": return Language.PHP;
                case ".js": return Language.JS;
                case ".lua": return Language.Lua;
                default: return Language.Custom;
            }
        }

        public static bool IsComment(this string text) => text.StartsWith("/*") || text.StartsWith("//");

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

        public static void LogException(
            this Exception ex,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Debug.WriteLine($"File Path: {filePath}");
            Debug.WriteLine($"Member Name: {memberName}");
            Debug.WriteLine($"Line Number: {lineNumber}");
            while (true)
            {
                Debug.WriteLine("{0} - {1}", ex.GetType(), ex.Message);
                ex = ex.InnerException;
                if (ex == null)
                    break;
            }
        }

        public static string Range(this string s, CharacterRange range) => s.Substring(range.First, range.Length);

        public static void ShowDialog(this Exception exception, IWin32Window owner = null) => exception.ShowDialog(owner, string.Empty);
        public static void ShowDialog(this Exception exception, string text) => exception.ShowDialog(null, text);

        public static void ShowDialog(this Exception exception, IWin32Window owner, string text) =>
            MessageBox.Show(owner,
                $"{exception.GetAllMessages()}. {text}",
                exception.GetAllExceptionTypes(),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

        public static string StringsToText(this IEnumerable<string> strings) => strings == null || !strings.Any()
            ? string.Empty
            : strings.Aggregate((p, q) => $"{p}{Environment.NewLine}{q}");

        public static Tag TagFromString(this string tag) => (Tag)Enum.Parse(typeof(Tag), tag);

        public static string[] TextToStrings(this string text) => text == null
            ? Array.Empty<string>()
            : text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

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
