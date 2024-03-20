namespace TagScanner.Controllers
{
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Logging;
    using Models;
    using Terms;
    using Utils;

    internal class TermTreeViewController : Controller
    {
        internal TermTreeViewController(Controller parent, TreeView treeView) : base(parent)
        {
            TreeView = treeView;
            TreeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            TreeView.DrawNode += TreeView_DrawNode;
        }

        #region Internal Properties

        internal bool HasSelection => SelectedNode != null;
        internal TreeNode SelectedNode => TreeView.SelectedNode;
        internal TreeView TreeView { get; }
        internal TreeNodeCollection Roots => TreeView.Nodes;

        #endregion

        #region Internal Methods

        internal int Add(Term term) => HasSelection ? AddChild(SelectedNode, term) : AddRoot(term);
        internal int AddChild(TreeNode parent, Term term) => AddNode(parent != null ? parent.Nodes : Roots, term);
        internal void AddConstant() => Add(new Constant());
        internal void AddField(Tag tag) => Add(new Field(tag));
        internal void AddFunction(string key) => Add(new Function(key));
        internal void AddOperation(Op op) => Add(new Operation(op));
        internal int AddRoot(Term term) => AddNode(Roots, term);

        internal void AddTestTerms()
        {
            Term
                band = new Operation(Tag.Artists, '=', "The Beatles"),
                song = new Operation(Tag.Title, "!=", "Get Back"),
                album = new Operation(Tag.Album, '=', "Let It Be"),
                duration = new Operation(Tag.Duration, ">=", "00:03:30"),
                lyrics = !new Function("IsEmpty", Tag.Lyrics),
                tree = new Conditional(band, song, album | duration & lyrics);
            Add(new Conditional(band, song, album | duration & tree));
        }

        internal void CollapseAll() => TreeView.CollapseAll();
        internal void ExpandAll() => TreeView.ExpandAll();

        #endregion

        #region Private Event Handlers

        private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e) => DrawNode(e);

        #endregion

        private readonly Brush[] _brushes =
        {
            Brushes.Black,
            Brushes.Blue,
        };

        private readonly Brush[] _brushes16 =
        {
            Brushes.Black,
            Brushes.DarkRed,
            Brushes.Brown,
            Brushes.MediumVioletRed,
            Brushes.Red,
            Brushes.DarkOrange,
            Brushes.DarkGoldenrod,
            Brushes.DarkOliveGreen,
            Brushes.DarkGreen,
            Brushes.Green,
            Brushes.DarkCyan,
            Brushes.Blue,
            Brushes.DarkBlue,
            Brushes.DarkOrchid,
            Brushes.DarkViolet,
            Brushes.DarkMagenta,
        };

        private readonly StringFormat _format = new StringFormat(StringFormat.GenericTypographic)
            { FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

        #region Private Methods

        private int AddNode(TreeNodeCollection nodes, Term term) => nodes.Add(NewNode(term));

        private void DrawNode(DrawTreeNodeEventArgs e)
        {
            DrawNodeText(e.Graphics, TreeView.Font, e.Node.Tag as Term, e.Bounds, 0, e.State);
            e.DrawDefault = false;
        }

        private void DrawNodeText(Graphics g, Font font, Term term, RectangleF r, int level, TreeNodeStates state)
        {
            if (r.IsEmpty) return;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            var text = term.ToString();
            var brush = _brushes[level % _brushes.Length];
            if (level == 0)
            {
                LogDrawString(text, r);
                if ((state & TreeNodeStates.Focused) != 0)
                    g.FillRectangle(Brushes.Yellow, r);
            }
            if (term is Umptad umptad)
            {
                var ranges = term.CharacterRanges;
                _format.SetMeasurableCharacterRanges(ranges);
                var regions = g.MeasureCharacterRanges(text, font, r, _format).Select(p => p.GetBounds(g).Expand()).ToList();
                var range = 0;
                foreach (var operand in umptad.Operands)
                {
                    DrawString(g, text.SubRange(ranges[range]), font, brush, regions[range++]);
                    DrawNodeText(g, font, operand, regions[range++], level + 1, state);
                }
                DrawString(g, text.SubRange(ranges.Last()), font, brush, regions.Last());
            }
            else
                DrawString(g, text, font, brush, r);
        }

        private void DrawString(Graphics g, string text, Font font, Brush brush, RectangleF r)
        {
            if (r.IsEmpty) return;
            g.DrawString(text, font, brush, r);
            LogDrawString(text, r);
        }

        private void LogDrawString(string text, RectangleF r) => Logger.Log($"'{text}' - ({r.X}, {r.Y}, {r.Width}, {r.Height})");

        private TreeNode NewNode(Term term)
        {
            var node = new TreeNode(term.ToString()) { Tag = term };
            switch (term)
            {
                case Field field:
                    node.ToolTipText = field.Tag.Details();
                    break;
                case Operation operation:
                    foreach (var subTerm in operation.Operands)
                        AddChild(node, subTerm);
                    break;
                case Function function:
                    foreach (var subTerm in function.Operands)
                        AddChild(node, subTerm);
                    break;
            }
            return node;
        }

        #endregion
    }
}
