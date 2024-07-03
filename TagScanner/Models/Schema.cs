namespace TagScanner.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utils;

    public class Schema
    {
        #region Constructors

        public Schema() => _lines.Clear();

        public Schema(string lines) : this() =>
            _lines.AddRange(lines.TextToStrings().Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => new SchemaLine(p)));

        #endregion

        public string Filter
        {
            get
            {
                var filter = new StringBuilder();



                return filter.ToString();
            }
        }

        public SchemaLine[] Lines => _lines.ToArray();

        public void AddLine(SchemaLine line) => _lines.Add(line);

        private List<SchemaLine> _lines { get; } = new List<SchemaLine>();

        private IEnumerable<SchemaLine> Roots => GetLinesAtLevel(0);
        private IEnumerable<SchemaLine> Categories => GetLinesAtLevel(1);
        private IEnumerable<SchemaLine> Leaves => GetLinesAtLevel(2);

        private IEnumerable<SchemaLine> GetLinesAtLevel(int level) => _lines.Where(p => p.Level == level);

    }
}
