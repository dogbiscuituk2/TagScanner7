namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Controls;
    using Models;
    using Terms;
    using Utils;

    public class TermTreeController : Controller
    {
        #region Constructor

        public TermTreeController(Controller parent, TreeView treeView) : base(parent)
        {
            TreeView = treeView;
            Inks = 0;
            TreeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            TreeView.DrawNode += TreeView_DrawNode;
            TreeView.MouseMove += TreeView_MouseMove;
        }

        #endregion

        #region Internal Properties

        public bool HasSelection => SelectedNode != null;

        public TreeNode HotNode
        {
            get => _hotNode;
            set
            {
                if (HotNode == value) return;
                _hotNode = value;
            }
        }

        public Inks Inks
        {
            get => _ink.Inks;
            set => _ink = new Ink(value);
        }

        public TreeNodeCollection Roots => TreeView.Nodes;
        public TreeNode SelectedNode => TreeView.SelectedNode;
        public TreeView TreeView { get; }

        #endregion

        #region Internal Methods

        public int Add(Term term) => HasSelection ? AddChild(SelectedNode, term) : AddRoot(term);
        public void AddCast(Type type) => Add(new Cast(type));
        public int AddChild(TreeNode parent, Term term) => AddNode(parent != null ? parent.Nodes : Roots, term);
        public void AddConstant<T>() => Add(new Constant<T>(default(T)));
        public void AddField(Tag tag) => Add(new Field(tag));
        public void AddFunction(Fn fn) => Add(new Function(fn));
        public void AddOperation(Op op) => Add(new Operation(op));
        public int AddRoot(Term term) => AddNode(Roots, term);
        public void Clear() => Roots.Clear();

        public void AddTestTerms()
        {
            Term
                band = new Operation(Tag.Artists, '=', "The Beatles"),
                song = new Operation(Tag.Title, "!=", "Get Back"),
                album = new Operation(Tag.Album, '=', "Let It Be"),
                duration = new Operation(Tag.Duration, ">=", "00:03:30"),
                lyrics = !new Function(Fn.Empty, Tag.Lyrics),
                tree = new Conditional(band, song, album | duration & lyrics),
                tree2 = new Conditional(band, song, album | duration & lyrics & tree);
            Add(new Conditional(band, song, album | duration & tree2));
            Term
                a = new Operation('A', Op.EqualTo, 'B'),
                b = a | a, c = b | b, d = c | c, e = d | d, f = e | e, g = f | f, h = g | g;
            Add(h);
        }

        public void CollapseAll()
        {
            TreeView.BeginUpdate();
            TreeView.CollapseAll();
            TreeView.EndUpdate();
        }

        public void ExpandAll()
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

        private void MouseMove(MouseEventArgs e) => HotNode = TreeView.GetNodeAt(e.Location);

        private static TermTreeNode NewNode(Term term) => new TermTreeNode(term);

        private void VisitRoot(Graphics g, Font font, TreeNode node, RectangleF bounds, Action action)
        {
            if (bounds.IsEmpty) return;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            var termNode = (TermTreeNode)node;
            var term = termNode.Term;
            var text = term.ToString();
            var regions = new List<RectangleF>();
            int level = 0, range = 0;
            bool
                draw = (action & Action.Draw) != 0,
                drawFocused = (action & Action.DrawFocused) != 0,
                hitTest = (action & Action.HitTest) != 0;
            if (drawFocused)
                g.FillRectangle(Brushes.Yellow, bounds);
            var font1 = font;
            Font font2;
            using (font2 = new Font(font, FontStyle.Underline))
                VisitNode();
            return;

            void VisitNode()
            {
                if (term is Compound compound)
                    foreach (var operand in compound.Operands)
                    {
                        font = font1;
                        VisitRegion(text.Range(termNode.CharacterRangesAll[range]), GetNextRegion());
                        term = operand;
                        level++;
                        VisitNode();
                        level--;
                    }
                else
                    font = font2;
                VisitRegion(text.Range(termNode.CharacterRangesAll[range]), GetNextRegion());
            }

            void VisitRegion(string s, RectangleF r)
            {
                if (r.IsEmpty) return;
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
