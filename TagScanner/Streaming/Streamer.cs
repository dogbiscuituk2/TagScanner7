namespace TagScanner.Streaming
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text.Json;
    using System.Xml.Serialization;
    using Core;

    public static class Streamer
    {
        public static StreamFormat GetStreamFormat(this string fileName)
        {
            var ext = Path.GetExtension(fileName);
            switch (ext.ToLowerInvariant())
            {
                case ".binary": return StreamFormat.Binary;
                case ".xml": return StreamFormat.Xml;
                case ".json": return StreamFormat.Json;
                default: return StreamFormat.Binary;
            }
        }

        public static object LoadFromFile(string filePath, Type documentType, StreamFormat format = 0)
        {
            if (format == 0)
                format = filePath.GetStreamFormat();
            object result;
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                result = LoadFromStream(fileStream, documentType, format);
                fileStream.Close();
            }
            return result;
        }

        public static object LoadFromStream(Stream stream, Type documentType, StreamFormat format)
        {
            try
            {
                switch (format)
                {
                    case StreamFormat.Binary:
                        return new BinaryFormatter().Deserialize(stream);
                    case StreamFormat.Json:
                        return JsonSerializer.Deserialize(stream, documentType);
                    case StreamFormat.Xml:
                        return new XmlSerializer(documentType).Deserialize(stream);
                    default:
                        throw new NotSupportedException();
                }
            }
            catch (Exception exception)
            {
                exception.ShowDialog($"{nameof(documentType)}: {documentType}");
                return null;
            }
        }

        public static bool SaveToFile(string filePath, object document, StreamFormat format = 0)
        {
            if (format == 0)
                format = filePath.GetStreamFormat();
            bool result;
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                result = SaveToStream(fileStream, document, format);
                fileStream.Close();
            }
            return result;
        }

        public static bool SaveToStream(Stream stream, object document, StreamFormat format)
        {
            try
            {
                switch (format)
                {
                    case StreamFormat.Binary:
                        new BinaryFormatter().Serialize(stream, document);
                        break;
                    case StreamFormat.Json:
                        var options = new JsonSerializerOptions
                        {
                            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault,
                            IgnoreReadOnlyProperties = true,
                            WriteIndented = true,
                        };
                        JsonSerializer.Serialize(stream, document, options);
                        break;
                    case StreamFormat.Xml:
                        GetXmlSerializer(document.GetType()).Serialize(stream, document);
                        break;
                    default:
                        throw new NotSupportedException();
                }
                stream.Flush();
                return true;
            }
            catch (Exception exception)
            {
                exception.ShowDialog($"{nameof(document)}: {document}");
                return false;
            }
        }

        public static bool SaveToTemporaryFile(this object document, StreamFormat format = 0)
        {
            if (format == StreamFormat.None)
                format = StreamFormat.Binary;
            var now = DateTime.Now.ToString("[yyyy-MM-dd HH.mm.ss.fffffff]");
            var filePath = $@"{now}.{format}";
            return SaveToFile(filePath, document, format);
        }

        private static XmlSerializer GetXmlSerializer(Type documentType)
        {
            var xmlSerializer = new XmlSerializer(documentType);
            return xmlSerializer;
        }
    }
}
