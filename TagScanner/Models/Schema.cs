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

        public Schema(string lines) : this() => _lines.AddRange(lines
            .TextToStrings()
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .Select(p => new SchemaLine(p)));

        #endregion

        public string Filter
        {
            get
            {
                StringBuilder
                    rootBuilder = new StringBuilder(),
                    categoryBuilder = new StringBuilder(),
                    leafBuilder = new StringBuilder();

                var categories = GetCategories();
                if (categories.Any())
                {
                    foreach (var category in categories)
                    {
                        var leaves = GetLeaves(category);
                        if (leaves.Any())
                        {
                            foreach (var leaf in leaves)
                                leafBuilder.Append(leaf.Filter);
                            var filterspecs = GetFilterspecs(leaves);
                            rootBuilder.Append(filterspecs);
                            categoryBuilder.Append($"{category} ({filterspecs})|{filterspecs}|");
                        }
                    }
                }
                if (rootBuilder.Length > 0)
                {
                    var allspecs = rootBuilder.ToString();
                    rootBuilder.Clear();
                    rootBuilder.Append($"All Media ({allspecs})|{allspecs}|");
                    rootBuilder.Append(categoryBuilder);
                    rootBuilder.Append(leafBuilder);
                }
                rootBuilder.Append("All Files (*.*)|*.*");
                return rootBuilder.ToString();
            }
        }

        public SchemaLine[] Lines => _lines.ToArray();

        public void AddLine(SchemaLine line) => _lines.Add(line);

        private List<SchemaLine> _lines { get; } = new List<SchemaLine>();

        private IEnumerable<SchemaLine> Roots => GetLinesAtLevel(0);
        private IEnumerable<SchemaLine> Categories => GetLinesAtLevel(1);
        private IEnumerable<SchemaLine> Leaves => GetLinesAtLevel(2);

        private IEnumerable<string> GetCategories() => GetLinesAtLevel(1).Select(p => p.Description);

        private string GetFilterspecs(IEnumerable<SchemaLine> lines)
        {
            if (!lines.Any())
                return string.Empty;
            return lines.Select(p => p.Filterspecs).Aggregate((p, q) => $"{p};{q}");
        }

        private IEnumerable<SchemaLine> GetLeaves(string category)
        {
            var match = false;
            foreach (var line in _lines)
                switch (line.Level)
                {
                    case 1:
                        match = line.Description == category;
                        break;
                    case 2:
                        if (match)
                            yield return line;
                        break;
                }
            yield break;
        }

        private IEnumerable<SchemaLine> GetLinesAtLevel(int level) => _lines.Where(p => p.Level == level);

        private IEnumerable<SchemaLine> GetSelectedLeaves(string category) => GetLeaves(category).Where(p => p.Check);
    }
}
