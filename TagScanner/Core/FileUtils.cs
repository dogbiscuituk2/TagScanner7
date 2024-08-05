namespace TagScanner.Core
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using FastColoredTextBoxNS;

    public static class FileUtils
    {
        /// <summary>
        /// Find the longest initial segment of filesystem path shared by a given set of paths.
        /// Where multiple distinct paths are supplied, this will be the lowest level folder common to all the files.
        /// In the case of a single file, this will be the full path to that file.
        /// Adapted from http://rosettacode.org/wiki/Find_common_directory_path#C.23
        /// </summary>
        /// <param name="paths">The given set of file paths.</param>
        /// <returns>The lowest level common folder (or the file path, in the case of a single file).</returns>
        public static string GetCommonPath(this IEnumerable<string> paths)
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
    }
}
