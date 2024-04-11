namespace TagScanner.Streaming
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Utils;

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
                        var streamReader = new StreamReader(stream);
                        var jsonTextReader = new JsonTextReader(streamReader);
                        var jsonSerializer = GetJsonSerializer();
                        jsonSerializer.Error += JsonSerializer_Error;
                        var result = jsonSerializer.Deserialize(jsonTextReader, documentType);
                        jsonSerializer.Error -= JsonSerializer_Error;
                        return result;
                    case StreamFormat.Xml:
                        return new XmlSerializer(documentType).Deserialize(stream);
                    default:
                        throw new NotSupportedException();
                }
            }
            catch (Exception exception)
            {
                exception.ShowDialog($"{nameof(documentType)}: {documentType}");
                return false;
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
                        var streamWriter = new StreamWriter(stream);
                        var jsonTextWriter = new JsonTextWriter(streamWriter);
                        var jsonSerializer = GetJsonSerializer();
                        jsonSerializer.Error += JsonSerializer_Error;
                        jsonSerializer.Serialize(jsonTextWriter, document,document.GetType());
                        jsonSerializer.Error -= JsonSerializer_Error;
                        jsonTextWriter.Flush();
                        break;
                    case StreamFormat.Xml:
                        var xmlSerializer = GetXmlSerializer(document.GetType());
                        xmlSerializer.UnknownAttribute += XmlSerializer_UnknownAttribute;
                        xmlSerializer.UnknownElement += XmlSerializer_UnknownElement;
                        xmlSerializer.UnknownNode += XmlSerializer_UnknownNode;
                        xmlSerializer.UnreferencedObject += XmlSerializer_UnreferencedObject;
                        try
                        {
                            xmlSerializer.Serialize(stream, document);
                        }
                        catch (Exception exception)
                        {
                            exception.ShowDialog($"{nameof(document)}: {document}");
                        }
                        finally
                        {
                            xmlSerializer.UnknownAttribute -= XmlSerializer_UnknownAttribute;
                            xmlSerializer.UnknownElement -= XmlSerializer_UnknownElement;
                            xmlSerializer.UnknownNode -= XmlSerializer_UnknownNode;
                            xmlSerializer.UnreferencedObject -= XmlSerializer_UnreferencedObject;
                        }
                        break;
                    default:
                        throw new NotSupportedException();
                }
                stream.Flush();
                return true;
            }
            catch (Exception exception)
            {
                exception.ShowDialog();
                return false;
            }
        }

        public static bool SaveToTemporaryFile(this object document, StreamFormat format = 0)
        {
            if (format == 0)
                format = StreamFormat.Binary;
            var now = DateTime.Now.ToString("[yyyy-MM-dd HH.mm.ss.fffffff]");
            var filePath = $@"{now}.{format}";
            return SaveToFile(filePath, document, format);
        }

        private static JsonSerializer GetJsonSerializer()
        {
            var jsonSerializer = new JsonSerializer
            {
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto,
            };
            return jsonSerializer;
        }

        private static XmlSerializer GetXmlSerializer(Type documentType)
        {
            var xmlSerializer = new XmlSerializer(documentType);
            return xmlSerializer;
        }

        private static void JsonSerializer_Error(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e) =>
            e.ErrorContext.Error.ShowDialog();

        private static void XmlSerializer_UnreferencedObject(object sender, UnreferencedObjectEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("UnreferencedObject");
        }

        private static void XmlSerializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("UnknownNode");
        }

        private static void XmlSerializer_UnknownElement(object sender, XmlElementEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("UnknownElement");
        }

        private static void XmlSerializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("UnknownAttribute");
        }
    }
}
