﻿namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TagScanner.Properties;
    using Utils;

    public class Schema
    {
        #region Constructors

        public Schema() => _lines.Clear();

        public Schema(string lines) : this() => _lines.AddRange(lines
            .TextToStrings()
            .Select(p => p.Trim())
            .Where(p => !string.IsNullOrWhiteSpace(p) && !p.StartsWith("<"))
            .Select(p => new SchemaLine(p)));

        #endregion

        #region Public Properties

        public string Filter
        {
            get
            {
                StringBuilder
                    rootBuilder = new StringBuilder(),
                    categoryBuilder = new StringBuilder(),
                    leafBuilder = new StringBuilder();

                var root = GetRoots().FirstOrDefault() ?? "All Media";
                var categories = GetCategories();
                if (categories.Any())
                {
                    foreach (var category in categories)
                    {
                        var leaves = GetLeaves(category).Where(p => p.Check);
                        if (leaves.Any())
                        {
                            foreach (var leaf in leaves)
                                leafBuilder.Append(leaf.Filter);
                            var filterspecs = GetFilterspecs(leaves);
                            rootBuilder.Append($"{filterspecs};");
                            categoryBuilder.Append($"{category} ({filterspecs})|{filterspecs}|");
                        }
                    }
                }
                if (rootBuilder.Length > 0)
                {
                    var allspecs = rootBuilder.ToString().TrimEnd(';');
                    rootBuilder.Clear();
                    rootBuilder.Append($"{root} ({allspecs})|{allspecs}|");
                    rootBuilder.Append(categoryBuilder);
                    rootBuilder.Append(leafBuilder);
                }
                rootBuilder.Append("All Files (*.*)|*.*");
                return rootBuilder.ToString();
            }
        }

        public SchemaLine[] Lines => _lines.ToArray();

        #endregion

        #region Public Methods

        public void AddLine(SchemaLine line) => _lines.Add(line);

        public override string ToString()
        {
            var body = _lines.Any()
                ? _lines.Select(p => p.ToString()).Aggregate((p, q) => $"{p}{Environment.NewLine}{q}")
                : string.Empty;
            return $"{Resources.DefaultSchemaHelp}{Environment.NewLine}{body}";
        }

        #endregion

        #region Private Fields

        private List<SchemaLine> _lines = new List<SchemaLine>();

        #endregion

        #region Private Methods

        private IEnumerable<string> GetCategories() => GetDescriptionsAtLevel(1);
        private IEnumerable<string> GetDescriptionsAtLevel(int level) => GetLinesAtLevel(level).Select(p => p.Description);
        private string GetFilterspecs(IEnumerable<SchemaLine> lines)
        {
            if (!lines.Any())
                return string.Empty;
            return lines
                .Select(p => p.Filespec)
                .Aggregate((p, q) => $"{p}|{q}")
                .Split('|')
                .OrderBy(p => p)
                .Aggregate((p, q) => $"{p};{q}");
        }
        private IEnumerable<SchemaLine> GetLinesAtLevel(int level) => _lines.Where(p => p.Level == level);
        private IEnumerable<string> GetRoots() => GetDescriptionsAtLevel(0);

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

        #endregion
    }
}
