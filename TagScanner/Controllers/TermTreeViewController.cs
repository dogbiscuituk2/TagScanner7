namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Controls;
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
            Inks = 0;
            TreeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            TreeView.DrawNode += TreeView_DrawNode;
            TreeView.MouseMove += TreeView_MouseMove;
        }

        #endregion

        #region Internal Properties

        internal Inks Inks
        {
            get => _ink.Inks;
            set => _ink = new Ink(value);
        }

        internal bool HasSelection => SelectedNode != null;

        internal TreeNode HotNode
        {
            get => _hotNode;
            set
            {
                if (HotNode != value)
                {
                    _hotNode = value;
                    Logger.Log($"HotNode = {value?.Text}");
                }
            }
        } 

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
                tree = new Conditional(band, song, album | duration & lyrics),
                tree2 = new Conditional(band, song, album | duration & lyrics & tree);
            Add(new Conditional(band, song, album | duration & tree2));
            Term
                a = new Operation('A', Op.EqualTo, 'B'),
                b = a | a, c = b | b, d = c | c, e = d | d, f = e | e, g = f | f, h = g | g;
            Add(h);
        }

        internal void CollapseAll()
        {
            TreeView.BeginUpdate();
            TreeView.CollapseAll();
            TreeView.EndUpdate();
        }

        internal void ExpandAll()
        {
            TreeView.BeginUpdate();
            TreeView.ExpandAll();
            TreeView.EndUpdate();
        }

        #endregion

        #region Private Fields

        private readonly StringFormat _format = new StringFormat(StringFormat.GenericTypographic)
            { FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

        private Ink _ink;
        private TreeNode _hotNode;

        #endregion

        #region Private Event Handlers

        private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e) => DrawNode(e);
        private void TreeView_MouseMove(object sender, MouseEventArgs e) => MouseMove(e);

        #endregion

        #region Private Methods

        private int AddNode(TreeNodeCollection nodes, Term term) => nodes.Add(NewNode(term));

        private void DrawNode(DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = false;
            DrawNodeText(e.Graphics, TreeView.Font, e.Node, e.Bounds, (e.State & TreeNodeStates.Focused) != 0);
        }

        private void DrawNodeText(Graphics g, Font font, TreeNode node, RectangleF bounds, bool focused)
        {
            if (bounds.IsEmpty) return;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            var termNode = (TermNode)node;
            var term = termNode.Term;
            var text = term.ToString();
            LogDrawString(text, bounds);
            int level = 0, range = 0;
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
                        DrawString(text.Range(termNode.CharacterRangesAll[range]), GetNextRegion());
                        level++;
                        DrawNodeSubText(operand);
                        level--;
                    }
                DrawString(text.Range(termNode.CharacterRangesAll[range]), GetNextRegion());
            }

            void DrawString(string s, RectangleF r)
            {
                if (r.IsEmpty) return;
                LogDrawString(s, r);
                g.DrawString(s, font, _ink.Brush(level), r);
            }

            RectangleF GetNextRegion()
            {
                if ((range & 0x1F) == 0) // Max 32 ranges can be passed to SetMeasurableCharacterRanges.
                {
                    _format.SetMeasurableCharacterRanges(termNode.CharacterRangesAll.Skip(range).Take(32).ToArray());
                    regions = g.MeasureCharacterRanges(text, font, bounds, _format).Select(p => p.GetBounds(g).Expand()).ToList();
                }
                return regions[range++ & 0x1F];
            }
        }

        private static void LogDrawString(string text, RectangleF r) => Logger.Log($"Bounds: ({r.X}, {r.Y}, {r.Width}, {r.Height}), Text: '{text}'");

        private void MouseMove(MouseEventArgs e)
        {
            HotNode = TreeView.GetNodeAt(e.Location);
        }

        private TermNode NewNode(Term term)
        {
            var node = new TermNode(term);
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
