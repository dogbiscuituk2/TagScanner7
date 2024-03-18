namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Linq;
    using System.Windows.Forms;
    using Models;
    using Terms;

    internal class TermTreeViewController : Controller
    {
        internal TermTreeViewController(Controller parent, TreeView treeView) : base(parent)
        {
            TreeView = treeView;
            TreeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            TreeView.AfterCollapse += TreeView_AfterCollapse;
            TreeView.AfterExpand += TreeView_AfterExpand;
            TreeView.DrawNode += TreeView_DrawNode;
        }

        #region Internal Properties

        internal bool HasSelection => SelectedNode != null;
        internal TreeNode SelectedNode => TreeView.SelectedNode;
        internal TreeView TreeView { get; }
        internal TreeNodeCollection Roots => TreeView.Nodes;

        #endregion

        #region Public Methods

        internal int Add(Term term) => HasSelection ? AddChild(SelectedNode, term) : AddRoot(term);
        internal int AddChild(TreeNode parent, Term term) => AddNode(parent != null ? parent.Nodes : Roots, term);
        internal void AddConstant() => Add(new Constant());
        internal void AddField(Tag tag) => Add(new Field(tag));
        internal void AddFunction(string key) => Add(new Function(key));
        internal void AddOperation(Op op) => Add(new Operation(op));
        internal int AddRoot(Term term) => AddNode(Roots, term);

        internal IEnumerable<Term> GetTerms() => Roots.OfType<TreeNode>().Select(p => p.Tag as Term);

        internal void Load(IEnumerable<Term> terms)
        {
            Roots.Clear();
            foreach (var term in terms)
                AddRoot(term);
        }

        #endregion

        #region Private Event Handlers

        private void TreeView_AfterCollapse(object sender, TreeViewEventArgs e) => e.Node.Text = ((Term)e.Node.Tag).ToString();
        private void TreeView_AfterExpand(object sender, TreeViewEventArgs e) => e.Node.Text = GetNodeText((Term)e.Node.Tag);
        private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e) => DrawNode(e);

        #endregion

        private readonly Color[] _colours = { Color.Black, Color.Red, Color.Green, Color.Blue };
        
        #region Private Methods

        private int AddNode(TreeNodeCollection nodes, Term term) => nodes.Add(NewNode(term));

        private void DrawNode(DrawTreeNodeEventArgs e) => 
            DrawNodeText(e.Graphics, TreeView.Font, e.Node.Tag as Term, e.Bounds, 0, e.State);
        
        private void DrawNodeText(Graphics g, Font font, Term term, Rectangle r, int level, TreeNodeStates state)
        {
            var text = term.ToString();
            using (var brush = new SolidBrush(_colours[level & 3]))
            {
                if (term is Umptad umptad)
                {
                    int p = 0, q;
                    for (var index = 0; index < umptad.Operands.Count; index++)
                    {
                        q = term.Start(index);
                        r = DrawPart(g, font, brush, p, q, r, text);
                        var operand = umptad.Operands[index];
                        DrawNodeText(g, font, operand, r, level + 1, state);
                        r.X += (int)g.MeasureString(operand.ToString(), font).Width;
                        p = q + operand.Length;
                    }
                    q = text.Length;
                    DrawPart(g, font, brush, p, q, r, text);
                }
                else
                    g.DrawString(text, font, brush, r);
            }
        }

        private static Rectangle DrawPart(Graphics g, Font font, SolidBrush brush, int p, int q, Rectangle r, string text)
        {
            if (q <= p) return r;
            text = text.Substring(p, q - p);
            g.DrawString(text, font, brush, r);
            r.X += (int)g.MeasureString(text, font).Width;
            return r;
        }

        private static string GetNodeText(Term term)
        {
            if (term is Operation operation)
                switch (operation.Op)
                {
                    case Op.And: return "All of the following are true:";
                    case Op.Or: return "One or more of the following are true:";
                    case Op.Xor: return "Exactly one of the following is true:";
                    case Op.EqualTo: return "These are equal:";
                    case Op.NotEqualTo: return "These are not equal:";
                }
            return term.ToString();
        }

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
