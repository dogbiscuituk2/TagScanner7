namespace TagScanner.Terms
{
    using System.Windows.Forms;
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml;
    using System.Xml.Serialization;

    public static class Streamer
    {
        public static object Load(Stream stream, StreamFormats formats)
        {
            /*
				The asymmetrical use of XmlTextReader below is necessitated by a bug in .NET's XML Serialization routines.
				These can serialize an object to XML, which will subsequently throw an exception when trying to deserialize.
				For example, when a string contains an unprintable character like char(1), this will get serialized to &#x1;
				but fail on subsequent attempted deserialization. Note that it is actually the serialization step which is at
				fault, because the definition of an XML character (see "http://www.w3.org/TR/2000/REC-xml-20001006#charsets")
				specifically excludes all such control characters except tab, line feed, and carriage return:

					Char ::= #x9 | #xA | #xD | [#x20-#xD7FF] | [#xE000-#xFFFD] | [#x10000-#x10FFFF]

				The use of XmlTextReader gets round this problem by defaulting its Normalization property to false, hence
				disabling character range checking for numeric entities. As a result, character entities such as &#1; are
				allowed during deserialization too. The default TextReader variant on the other hand creates an XmlTextReader
				with its Normalization property set to true, which was causing the observed failure at deserialization time.
			*/
            object result = null;
            try
            {
                switch (formats)
                {
                    case StreamFormats.Binary:
                        result = BinaryFormatter.Deserialize(stream);
                        break;
                    case StreamFormats.Json:
                        throw new NotImplementedException();
                    case StreamFormats.Xml:
                        result = XmlSerializer.Deserialize(new XmlTextReader(stream));
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return result;
        }

        public static bool Save(Stream stream, StreamFormats formats, object document)
        {
            try
            {
                switch (formats)
                {
                    case StreamFormats.Binary:
                        BinaryFormatter.Serialize(stream, document);
                        return true;
                    case StreamFormats.Json:
                        throw new NotImplementedException();
                    case StreamFormats.Xml:
                        XmlSerializer.Serialize(stream, document);
                        return true;
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return false;
            }
        }

        public static BinaryFormatter BinaryFormatter => _binaryFormatter ?? (_binaryFormatter = NewBinaryFormatter());
        private static BinaryFormatter _binaryFormatter;
        private static BinaryFormatter NewBinaryFormatter() => new BinaryFormatter();

        public static XmlSerializer XmlSerializer => _xmlSerializer ?? (_xmlSerializer = NewXmlSerializer());
        private static XmlSerializer _xmlSerializer;
        private static XmlSerializer NewXmlSerializer() => new XmlSerializer(typeof(Term),
            new Type[]
            {
                typeof(Cast),
                typeof(Constant),
                typeof(Field),
                typeof(Function),
                typeof(Negation),
                typeof(Operation),
                typeof(Parameter)
            });

        private static void HandleException(Exception ex)
        {
            string
                message = ex.Message,
                exType = ex.GetType().Name;
            var innerEx = ex.InnerException;
            if (innerEx != null)
            {
                message = $"{message}\r\n{innerEx.Message}";
                exType = $"{exType} ({innerEx.GetType().Name})";
            }
            MessageBox.Show(message, exType, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
