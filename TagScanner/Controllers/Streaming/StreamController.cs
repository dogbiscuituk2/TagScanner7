namespace TagScanner.Controllers.Streaming
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Utils;

    public static class StreamController
    {
        public static object LoadFromFile(string filePath, Type documentType) =>
            LoadFromStream(new FileStream(filePath, FileMode.Open, FileAccess.Read), documentType, filePath.GetStreamFormat());

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
                exception.ShowDialog();
                return false;
            }
        }

        public static bool SaveToFile(string filePath, object document) =>
            SaveToStream(new FileStream(filePath, FileMode.Create, FileAccess.Write), document, filePath.GetStreamFormat());

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
                        var xmlSerializer = new XmlSerializer(document.GetType());
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
                            exception.ShowDialog();
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

        private static JsonSerializer GetJsonSerializer()
        {
            var jsonSerializer = new JsonSerializer
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto,
            };
            //jsonSerializer.Converters.Add(new JsonNumberConverter());
            return jsonSerializer;
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
