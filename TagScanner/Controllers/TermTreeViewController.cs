namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
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

        #region Public Properties

        public bool HasSelection => SelectedNode != null;
        public TreeNode SelectedNode => _treeView.SelectedNode;
        public TreeView TreeView => _treeView;
        public TreeNodeCollection Roots => _treeView.Nodes;

        #endregion

        #region Public Methods

        public int Add(Term term) => HasSelection ? AddChild(SelectedNode, term) : AddRoot(term);
        public int AddChild(TreeNode parent, Term term) => AddNode(parent != null ? parent.Nodes : Roots, term);
        public void AddConstant() => Add(new Constant());
        public void AddField(TagProps tagProps) => Add(new Field(tagProps.Name));
        public void AddFunction(KeyValuePair<string, MethodInfo> method) => Add(new Function(method.Key));
        public void AddOperation(KeyValuePair<Op, OpInfo> operation) => Add(new Operation(operation.Key));
        public int AddRoot(Term term) => AddNode(Roots, term);

        public IEnumerable<Term> GetTerms() => Roots.OfType<TreeNode>().Select(p => p.Tag as Term);

        public void Load(IEnumerable<Term> terms)
        {
            Roots.Clear();
            foreach (var term in terms)
                AddRoot(term);
        }

        #endregion

        #region Private Fields

        private readonly TreeView _treeView;

        #endregion

        #region Private Event Handlers

        private void TreeView_AfterCollapse(object sender, TreeViewEventArgs e) => e.Node.Text = (e.Node.Tag as Term).ToString();
        private void TreeView_AfterExpand(object sender, TreeViewEventArgs e) => e.Node.Text = GetNodeText(e.Node.Tag as Term);

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
            var result = new TreeNode(term.ToString()) { Tag = term };
            if (term is Operation operation)
                foreach (var subterm in operation.Operands)
                    AddChild(result, subterm);
            return result;
        }

        #endregion
    }
}
