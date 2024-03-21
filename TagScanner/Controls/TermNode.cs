namespace TagScanner.Controls
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Terms;

    public class TermNode : TreeNode
    {
        #region Constructors

        public TermNode() { }
        public TermNode(string text) : this() { Text = text; }
        public TermNode(Term term) : this(term.ToString()) { Term = term; }

        #endregion

        #region Public Properties

        public List<CharacterRange> CharacterRanges => Term?.CharacterRanges;
        public List<CharacterRange> CharacterRangesAll => Term?.CharacterRangesAll;

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

        #endregion

        #region Public Methods

        public void InvalidateCharacterRanges()
        {
            if (Term == null) return;
            Term.InvalidateCharacterRanges();
            if (Parent is TermNode parent)
                parent.InvalidateCharacterRanges();
        }

        #endregion

        #region Private Fields

        private Term _term;

        #endregion

        #region Private Methods

        private void AddTerms(List<Term> terms) { foreach (var term in terms) { Nodes.Add(new TermNode(term)); } }

        #endregion
    }
}
