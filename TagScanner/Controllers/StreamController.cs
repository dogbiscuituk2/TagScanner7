namespace TagScanner.Controllers
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;

    public static class StreamController
    {
        public static object LoadFromFile(string filePath) =>
            LoadFromStream(new FileStream(filePath, FileMode.Open, FileAccess.Read));

        public static object LoadFromStream(Stream stream)
        {
            try
            {
                return new BinaryFormatter().Deserialize(stream);
            }
            catch (Exception exception)
            {
                HandleException(exception);
                return false;
            }
        }

        public static bool SaveToFile(string filePath, object document) =>
            SaveToStream(new FileStream(filePath, FileMode.Create, FileAccess.Write), document);

        public static bool SaveToStream(Stream stream, object document)
        {
            try
            {
                new BinaryFormatter().Serialize(stream, document);
                stream.Flush();
                return true;
            }
            catch (Exception exception)
            {
                HandleException(exception);
                return false;
            }
        }

        private static void HandleException(Exception exception)
        {
            string
                message = exception.Message,
                exceptionType = exception.GetType().Name;
            var innerException = exception.InnerException;
            if (innerException != null)
            {
                message = $"{message}{Environment.NewLine}{innerException.Message}";
                exceptionType = $"{exceptionType} ({innerException.GetType().Name})";
            }
            MessageBox.Show(message, exceptionType, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
