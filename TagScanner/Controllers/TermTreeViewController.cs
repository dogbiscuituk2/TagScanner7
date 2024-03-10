namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;
    using TagScanner.Models;
    using TagScanner.Terms;

    public class TermTreeViewController : Controller
    {
        public TermTreeViewController(Controller parent, TreeView treeView) : base(parent)
        {
            TreeView = treeView;
            TreeView.AfterCollapse += TreeView_AfterCollapse;
            TreeView.AfterExpand += TreeView_AfterExpand;
        }

        public bool HasSelection => SelectedNode != null;
        public TreeNode SelectedNode => TreeView.SelectedNode;

        public int AddChild(TreeNode parent, Term term) => AddNode(parent.Nodes, term);
        public int AddRoot(Term term) => AddNode(TreeView.Nodes, term);
        public void Add(Term term) { if (HasSelection) AddChild(SelectedNode, term); else AddRoot(term); }

        public void Load(IEnumerable<Term> terms)
        {
            foreach (var term in terms)
                AddRoot(term);
        }

        private TreeView TreeView;

        private void TreeView_AfterCollapse(object sender, TreeViewEventArgs e) => e.Node.Text = (e.Node.Tag as Term).ToFriendlyText();
        private void TreeView_AfterExpand(object sender, TreeViewEventArgs e) => e.Node.Text = GetNodeText(e.Node.Tag as Term);

        private int AddNode(TreeNodeCollection nodes, Term term) => nodes.Add(NewNode(term));

        private string GetNodeText(Term term)
        {
            if (term is Operation operation)
                switch (operation.Operator)
                {
                    case Operator.And: return "All of the following are true:";
                    case Operator.Or: return "One or more of the following are true:";
                    case Operator.EqualTo: return "These are equal:";
                    case Operator.NotEqualTo: return "These are not equal:";
                }
            return term.ToFriendlyText();
        }

        private TreeNode NewNode(Term term)
        {
            var result = new TreeNode(term.ToFriendlyText()) { Tag = term };
            if (term is Operation operation)
                foreach (var subterm in operation.Operands)
                    AddChild(result, subterm);
            return result;
        }

        internal void AddConstant() => Add(new Constant());
        internal void AddField(TagProps tagProps) => Add(new Field(tagProps.Name));
        internal void AddFunction(KeyValuePair<string, MethodInfo> method) => Add(new Function(method.Key));
        internal void AddOperation(KeyValuePair<Operator, OperatorInfo> operation) => Add(new Operation(operation.Key));
    }
}
