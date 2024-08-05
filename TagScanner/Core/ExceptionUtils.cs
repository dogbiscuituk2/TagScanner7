namespace TagScanner.Core
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public static class ExceptionUtils
    {
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

        public static void ShowDialog(this Exception exception, IWin32Window owner = null) => exception.ShowDialog(owner, string.Empty);
        public static void ShowDialog(this Exception exception, string text) => exception.ShowDialog(null, text);

        public static void ShowDialog(this Exception exception, IWin32Window owner, string text) =>
            MessageBox.Show(owner,
                $"{exception.GetAllMessages()}. {text}",
                exception.GetAllExceptionTypes(),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
    }
}
