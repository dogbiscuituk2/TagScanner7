namespace TagScanner.Logging
{
    using System;
    using System.Diagnostics;

    public static class Logger
    {
        public static void Log(string s) => Debug.WriteLine(s);
        public static void LogException(Exception ex, string filePath = "") => Debug.WriteLine("{0} - {1} - {2}", ex.GetType(), ex.Message, filePath);
    }
}
