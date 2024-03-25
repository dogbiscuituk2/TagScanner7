namespace TagScanner.Logging
{
    using System;
    using System.Diagnostics;

    public static class Logger
    {
        public static void LogException(Exception ex, string context = "")
        {
            while (true)
            {
                Debug.WriteLine("{0} - {1} - {2}", ex.GetType(), ex.Message, context);
                ex = ex.InnerException;
                if (ex != null)
                {
                    context = "(InnerException)";
                    continue;
                }
                break;
            }
        }
    }
}
