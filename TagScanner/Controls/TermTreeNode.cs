namespace TagScanner.Controls
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Terms;

    public class TermTreeNode : TreeNode
    {
        #region Constructors

        public TermTreeNode() { }
        public TermTreeNode(string text) : this() { Text = text; }
        public TermTreeNode(Term term) : this(term.ToString()) { Term = term; }

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
                    case TrackField field:
                        ToolTipText = field.Tag.Details();
                        break;
                    case Compound compound:
                        AddTerms(compound.Operands);
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
            if (Parent is TermTreeNode parent)
                parent.InvalidateCharacterRanges();
        }

        #endregion

        #region Private Fields

        private Term _term;

        #endregion

        #region Private Methods

        private void AddTerms(List<Term> terms) { foreach (var term in terms) { Nodes.Add(new TermTreeNode(term)); } }

        #endregion
    }
}
