namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Logging;
    using Models;
    using Terms;
    using Utils;

    internal class TermTreeViewController : Controller
    {
        #region Constructor

        internal TermTreeViewController(Controller parent, TreeView treeView) : base(parent)
        {
            TreeView = treeView;
            TreeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            TreeView.DrawNode += TreeView_DrawNode;
        }

        #endregion

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

        #region Private Fields

        private readonly Brush[] _brushes2 =
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

        #endregion

        #region Private Event Handlers

        private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e) => DrawNode(e);

        #endregion

        #region Private Methods

        private int AddNode(TreeNodeCollection nodes, Term term) => nodes.Add(NewNode(term));

        private void DrawNode(DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = false;
            DrawNodeText(e.Graphics, TreeView.Font, e.Node.Tag as Term, e.Bounds, (e.State & TreeNodeStates.Focused) != 0);
        }

        private void DrawNodeText(Graphics g, Font font, Term term, RectangleF bounds, bool focused)
        {
            if (bounds.IsEmpty) return;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            var text = term.ToString();
            //LogDrawString(text, bounds);
            int level = 0, range = 0;
            var ranges = term.GetRanges(all: true).ToList();
            List<RectangleF> regions = null;
            if (focused)
                g.FillRectangle(Brushes.Yellow, bounds);
            DrawNodeSubText(term);
            return;

            void DrawNodeSubText(Term subTerm)
            {
                if (subTerm is Umptad umptad)
                    foreach (var operand in umptad.Operands)
                    {
                        DrawString(text.SubRange(ranges[range]), GetNextRegion());
                        level++;
                        DrawNodeSubText(operand);
                        level--;
                    }
                DrawString(text.SubRange(ranges[range]), GetNextRegion());
            }

            void DrawString(string s, RectangleF r)
            {
                if (r.IsEmpty) return;
                //LogDrawString(s, r);
                g.DrawString(s, font, _brushes16[level % _brushes16.Length], r);
            }

            RectangleF GetNextRegion()
            {
                if ((range & 0x1F) == 0) // Max 32 ranges can be passed to SetMeasurableCharacterRanges.
                {
                    _format.SetMeasurableCharacterRanges(ranges.Skip(range).Take(32).ToArray());
                    regions = g.MeasureCharacterRanges(text, font, bounds, _format).Select(p => p.GetBounds(g).Expand()).ToList();
                }
                return regions[range++ & 0x1F];
            }
        }

        private static void LogDrawString(string text, RectangleF r) => Logger.Log($"({r.X}, {r.Y}, {r.Width}, {r.Height}) - '{text}'");

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
