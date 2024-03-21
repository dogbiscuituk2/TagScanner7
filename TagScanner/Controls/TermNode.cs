namespace TagScanner.Controls
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Terms;

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
            Regions.Clear();
            Regions.AddRange(regions);
        }

        public void InvalidateCharacterRanges()
        {
            if (Term == null) return;
            Term.InvalidateCharacterRanges();
            if (Parent is TermNode parent)
                parent.InvalidateCharacterRanges();
        }

        public void ValidateCharacterRanges() => Term?.ValidateCharacterRanges();

        private Term _term;
    }
}
