namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Controls;
    using Logging;
    using Models;
    using Terms;
    using Utils;

    internal class TermTreeController : Controller
    {
        #region Constructor

        internal TermTreeController(Controller parent, TreeView treeView) : base(parent)
        {
            TreeView = treeView;
            Inks = 0;
            TreeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            TreeView.DrawNode += TreeView_DrawNode;
            TreeView.MouseMove += TreeView_MouseMove;
        }

        #endregion

        #region Internal Properties

        internal bool HasSelection => SelectedNode != null;

        internal TreeNode HotNode
        {
            get => _hotNode;
            set
            {
                if (HotNode == value) return;
                _hotNode = value;
                Logger.Log($"HotNode = {value?.Text}");
            }
        }

        internal Inks Inks
        {
            get => _ink.Inks;
            set => _ink = new Ink(value);
        }

        internal TreeNodeCollection Roots => TreeView.Nodes;
        internal TreeNode SelectedNode => TreeView.SelectedNode;
        internal TreeView TreeView { get; }

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

        private TreeNode _hotNode;
        private Ink _ink;

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
            var action = Action.Draw;
            if ((e.State & TreeNodeStates.Focused) != 0)
                action |= Action.DrawFocused;
            VisitRoot(e.Graphics, TreeView.Font, e.Node, e.Bounds, action);
        }

        private static void LogVisit(string text, RectangleF r) => Logger.Log($"Bounds: ({r.X}, {r.Y}, {r.Width}, {r.Height}), Text: '{text}'");

        private void MouseMove(MouseEventArgs e) => HotNode = TreeView.GetNodeAt(e.Location);

        private static TermNode NewNode(Term term) => new TermNode(term);

        private void VisitRoot(Graphics g, Font font, TreeNode node, RectangleF bounds, Action action)
        {
            if (bounds.IsEmpty) return;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            var termNode = (TermNode)node;
            var term = termNode.Term;
            var text = term.ToString();
            LogVisit(text, bounds);
            var regions = new List<RectangleF>();
            int level = 0, range = 0;
            bool
                draw = (action & Action.Draw) != 0,
                drawFocused = (action & Action.DrawFocused) != 0,
                hitTest = (action & Action.HitTest) != 0;
            if (drawFocused)
                g.FillRectangle(Brushes.Yellow, bounds);
            VisitNode();
            return;

            void VisitNode()
            {
                if (term is Umptad umptad)
                    foreach (var operand in umptad.Operands)
                    {
                        VisitRegion(text.Range(termNode.CharacterRangesAll[range]), GetNextRegion());
                        term = operand;
                        level++;
                        VisitNode();
                        level--;
                    }
                VisitRegion(text.Range(termNode.CharacterRangesAll[range]), GetNextRegion());
            }

            void VisitRegion(string s, RectangleF r)
            {
                if (r.IsEmpty) return;
                LogVisit(s, r);
                if (draw)
                    g.DrawString(s, font, _ink.Brush(level), r);
            }

            RectangleF GetNextRegion()
            {
                if ((range & 0x1F) == 0) // Max 32 ranges can be passed to SetMeasurableCharacterRanges.
                {
                    _format.SetMeasurableCharacterRanges(termNode.CharacterRangesAll.Skip(range).Take(32).ToArray());
                    regions = g.MeasureCharacterRanges(text, font, bounds, _format).Select(p => p.GetBounds(g).Expand()).ToList();
                }
                var region = regions[range++ & 0x1F];
                return region;
            }
        }

        #endregion

        #region Private Enumerations

        [Flags]
        private enum Action
        {
            None = 0,
            Draw = 1,
            DrawFocused = 2,
            HitTest = 4,
        }

        #endregion
    }
}
