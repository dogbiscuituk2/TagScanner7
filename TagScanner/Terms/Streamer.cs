namespace TagScanner.Terms
{
    using System.Windows.Forms;
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Linq;

    public class Streamer
    {
        public Streamer(StreamFormat format, params Type[] types) { Format = format; Types = types; }

        public StreamFormat Format { get; }
        public Type[] Types { get; }

        public object Load(Stream stream)
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
            switch (Format)
            {
                case StreamFormat.Binary:
                    UseStream(() => result = new BinaryFormatter().Deserialize(stream));
                    break;
                case StreamFormat.Json:
                    throw new NotImplementedException();
                case StreamFormat.Xml:
                    UseStream(() => result = GetXmlSerializer().Deserialize(new XmlTextReader(stream)));
                    break;
            }
            return result;
        }

        public bool Save(Stream stream, object document)
        {
            switch (Format)
            {
                case StreamFormat.Binary:
                    return UseStream(() => new BinaryFormatter().Serialize(stream, document));
                case StreamFormat.Json:
                    throw new NotImplementedException();
                case StreamFormat.Xml:
                    return UseStream(() => GetXmlSerializer().Serialize(stream, document));
                default:
                    return false;
            }
        }

        private XmlSerializer GetXmlSerializer()
        {
            switch(Types.Length)
            {
                case 0:
                    return new XmlSerializer(typeof(Stream));
                case 1:
                    return new XmlSerializer(Types[0]);
                default:
                    return new XmlSerializer(Types[0], Types.Skip(1).ToArray());
            }
        }
            
        private bool UseStream(Action action)
        {
            var result = true;
            try
            {
                action();
            }
            catch (Exception x)
            {
                MessageBox.Show(
                    x.Message,
                    x.GetType().Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                result = false;
            }
            return result;
        }
    }
}
