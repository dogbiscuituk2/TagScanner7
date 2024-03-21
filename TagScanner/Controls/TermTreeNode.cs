using TagScanner.Terms;

namespace TagScanner.Controls
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml.Linq;

    public class TermTreeNode : TreeNode
    {
        public TermTreeNode() { }
        public TermTreeNode(string text) : this() { Text = text; }
        public TermTreeNode(Term term) : this(term.ToString()) { Term = term; }

        public Term Term
        {
            get => _term;
            set
            {
                _term = value;
                switch (Term)
                {
                    case Field field:
                        ToolTipText = field.Tag.Details();
                        break;
                    case Umptad umptad:
                        AddTerms(umptad.Operands);
                        break;
                }
            }
        }

        private void AddTerms(List<Term> terms)
        {
            foreach (var term in terms) { Nodes.Add(new TermTreeNode(term)); }
        }

        public List<CharacterRange> Ranges { get; } = new List<CharacterRange>();
        public List<RectangleF> Regions { get; } = new List<RectangleF>();

        public void AddRanges(IEnumerable<CharacterRange> ranges) => Ranges.AddRange(ranges);
        public void AddRegions(IEnumerable<RectangleF> regions) => Regions.AddRange(regions);

        public void SetRanges(IEnumerable<CharacterRange> ranges)
        {
            Ranges.Clear();
            Ranges.AddRange(ranges);
        }

        public void SetRegions(IEnumerable<RectangleF> regions)
        {
            Regions.Clear();
            Regions.AddRange(regions);
        }

        private Term _term;
    }
}
