using Newtonsoft.Json;

namespace TagScanner.Controllers
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;
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
                        return new JsonSerializer().Deserialize(new JsonTextReader(new StreamReader(stream)), documentType);
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
                        var jsonSerializer = new JsonSerializer
                        {
                            Formatting = Formatting.Indented,
                        };
                        jsonSerializer.Serialize(jsonTextWriter, document);
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
