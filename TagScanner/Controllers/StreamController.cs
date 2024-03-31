namespace TagScanner.Controllers
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Utils;

    public static class StreamController
    {
        public static object LoadFromFile(string filePath) => LoadFromStream(new FileStream(filePath, FileMode.Open, FileAccess.Read));

        public static object LoadFromStream(Stream stream)
        {
            try
            {
                return new BinaryFormatter().Deserialize(stream);
            }
            catch (Exception exception)
            {
                exception.ShowDialog();
                return false;
            }
        }

        public static bool SaveToFile(string filePath, object document) => SaveToStream(new FileStream(filePath, FileMode.Create, FileAccess.Write), document);

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
                exception.ShowDialog();
                return false;
            }
        }
    }
}
