namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;
    using Models;
    using Terms;

    public class TermTreeViewController : Controller
    {
        public TermTreeViewController(Controller parent, TreeView treeView) : base(parent)
        {
            _treeView = treeView;
            _treeView.AfterCollapse += TreeView_AfterCollapse;
            _treeView.AfterExpand += TreeView_AfterExpand;
        }

        public bool HasSelection => SelectedNode != null;
        public TreeNode SelectedNode => _treeView.SelectedNode;

        public int AddChild(TreeNode parent, Term term) => AddNode(parent.Nodes, term);
        public int AddRoot(Term term) => AddNode(_treeView.Nodes, term);
        public void Add(Term term) { if (HasSelection) AddChild(SelectedNode, term); else AddRoot(term); }

        public void Load(IEnumerable<Term> terms)
        {
            foreach (var term in terms)
                AddRoot(term);
        }

        private readonly TreeView _treeView;

        private void TreeView_AfterCollapse(object sender, TreeViewEventArgs e) => e.Node.Text = (e.Node.Tag as Term).ToString();
        private void TreeView_AfterExpand(object sender, TreeViewEventArgs e) => e.Node.Text = GetNodeText(e.Node.Tag as Term);

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
            var result = new TreeNode(term.ToString()) { Tag = term };
            if (term is Operation operation)
                foreach (var subterm in operation.Operands)
                    AddChild(result, subterm);
            return result;
        }

        internal void AddConstant() => Add(new Constant());
        internal void AddField(TagProps tagProps) => Add(new Field(tagProps.Name));
        internal void AddFunction(KeyValuePair<string, MethodInfo> method) => Add(new Function(method.Key));
        internal void AddOperation(KeyValuePair<Op, OpInfo> operation) => Add(new Operation(operation.Key));
    }
}
