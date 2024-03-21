namespace TagScanner.Controls
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Terms;
    using Utils;

    public class TermNode : TreeNode
    {
        public TermNode() { }
        public TermNode(string text) : this() { Text = text; }
        public TermNode(Term term) : this(term.ToString()) { Term = term; }

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
            foreach (var term in terms) { Nodes.Add(new TermNode(term)); }
        }

        public List<CharacterRange> CharacterRanges => Term?.CharacterRanges;
        public List<CharacterRange> CharacterRangesAll => Term?.CharacterRangesAll;

        public List<RectangleF> Regions { get; } = new List<RectangleF>();

        public void AddRegions(IEnumerable<RectangleF> regions) => Regions.AddRange(regions);

        public void SetRegions(IEnumerable<RectangleF> regions)
        {
            InvalidateRegions();
            Regions.AddRange(regions);
        }

        public void InvalidateCharacterRanges()
        {
            InvalidateRegions();
            if (Term == null) return;
            Term.InvalidateCharacterRanges();
            if (Parent is TermNode parent)
                parent.InvalidateCharacterRanges();
        }

        public void ValidateCharacterRanges() => Term?.ValidateCharacterRanges();

        private Term _term;

        public void InvalidateRegions() => Regions.Clear();

        internal void ValidateRegions(Graphics g, RectangleF bounds, StringFormat format)
        {
            ValidateCharacterRanges();
            if (Regions.Any()) return;
            for (var index = 0; index <  CharacterRangesAll.Count; index += 32)
            {
                format.SetMeasurableCharacterRanges(CharacterRangesAll.Skip(index).Take(32).ToArray());
                AddRegions(g.MeasureCharacterRanges(Text, TreeView.Font, bounds, format).Select(p => p.GetBounds(g).Expand()));
            }
        }
    }
}
