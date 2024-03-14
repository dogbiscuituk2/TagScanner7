namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Models;
    using Terms;

    internal class TermTreeViewController : Controller
    {
        internal TermTreeViewController(Controller parent, TreeView treeView) : base(parent)
        {
            TreeView = treeView;
            TreeView.AfterCollapse += TreeView_AfterCollapse;
            TreeView.AfterExpand += TreeView_AfterExpand;
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
        internal void AddField(TagProps tagProps) => Add(new Field(tagProps.Name));
        internal void AddFunction(KeyValuePair<string, MethodInfo> method) => Add(new Function(method.Key));
        internal void AddOperation(KeyValuePair<Op, OpInfo> operation) => Add(new Operation(operation.Key));
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

        #endregion

        #region Private Methods

        private int AddNode(TreeNodeCollection nodes, Term term) => nodes.Add(NewNode(term));

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
                    node.ToolTipText = Core.Tags[field.TagName].Details;
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
