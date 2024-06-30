namespace TagScanner.Controllers.Mru
{
    using Win32 = Microsoft.Win32;

    public class MruSchemaController : MruController
    {
        public MruSchemaController(Controller parent, string subKeyName) : base(parent, subKeyName) { }

        public string ReadSchema()
        {
            string schema = null;
            if (TryReadKey(out Win32.RegistryKey key))
            {
                schema = key?.GetValue(SchemaName)?.ToString();
                key?.Close();
            }
            return schema;
        }

        public void WriteSchema(string schema) => AddItem(SchemaName, schema);

        private const string SchemaName = "Schema";
    }
}
