namespace TagScanner.Controllers.Mru
{
    using Models;
    using Properties;

    public class MruSchemaController : MruController
    {
        public MruSchemaController(Controller parent, string subKeyName) : base(parent, subKeyName) { }

        public Schema ReadSchema()
        {
            Schema schema;
            var text = GetValue(SchemaName)?.ToString();
            var ok = text != null;
            if (!ok)
                text = Resources.DefaultSchema;
            schema = new Schema(text);
            if (!ok)
                WriteSchema(schema);
            return schema;
        }

        public void WriteSchema(Schema schema) => SetValue(SchemaName, schema.ToString());

        private const string SchemaName = "Schema";
    }
}
