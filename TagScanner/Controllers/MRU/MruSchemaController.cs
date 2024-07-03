namespace TagScanner.Controllers.Mru
{
    using Models;
    using System.ComponentModel;
    using TagScanner.Properties;
    using Win32 = Microsoft.Win32;

    public class MruSchemaController : MruController
    {
        public MruSchemaController(Controller parent, string subKeyName) : base(parent, subKeyName) { }

        public Schema ReadSchema()
        {
            string text = null;
            var ok = TryReadKey(out Win32.RegistryKey key);
            if (ok)
            {
                text = key.GetValue(SchemaName)?.ToString();
                ok = !string.IsNullOrWhiteSpace(text);
            }
            key?.Close();
            if (!ok)
                text = Resources.DefaultSchema;
            var schema = new Schema(text);
            if (!ok)
                WriteSchema(schema);
            return schema;
        }

        public void WriteSchema(Schema schema) => AddItem(SchemaName, schema.ToString());

        private const string SchemaName = "Schema";
    }
}
