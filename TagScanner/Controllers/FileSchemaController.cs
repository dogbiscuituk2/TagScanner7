namespace TagScanner.Controllers
{
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    public class FileSchemaController : Controller
    {
        #region Constructor

        public FileSchemaController(Controller parent) : base(parent)
        {
            Updater = new UpdateController(UpdateUI);
        }

        #endregion

        #region Public Properties

        public TreeNode SelectedNode
        {
            get => TreeView.SelectedNode;
            private set => TreeView.SelectedNode = value;
        }

        #endregion

        #region Public Methods

        public void Add()
        {
            var parent = SelectedNode;
            parent = parent.Level < 2 ? parent : parent.Parent;
            var level = parent.Level + 1;
            string
                description = string.Empty,
                filespec = string.Empty;
            if (EditValue($"Add a new {LineTypes[level]}", level, ref description, ref filespec))
                AddNode(parent.Nodes, description, filespec, check: level == 2);
        }

        public void AfterExecute() => AppController.Schema = GetSchema();

        public void BeforeExecute()
        {
            SetSchema(AppController.Schema);
            var root = RootNode;
            if (root != null)
                foreach (TreeNode node in RootNode.Nodes)
                    node.Collapse();
        }

        public void Edit()
        {
            var node = SelectedNode;
            var level = node.Level;
            var description = node.Text;
            var filespec = node.Tag?.ToString() ?? string.Empty;
            if (level == 2)
                description = description.Substring(0, description.Length - filespec.Length - 3);
            if (EditValue($"Edit the selected {LineTypes[level]}", level, ref description, ref filespec))
                InitNode(node, description, filespec);
        }

        public Schema GetSchema()
        {
            var schema = new Schema();
            AddNodes(Nodes);
            return schema;

            void AddNode(TreeNode node)
            {
                schema.AddLine(NodeToLine(node));
                AddNodes(node.Nodes);
            }

            void AddNodes(TreeNodeCollection nodes)
            {
                foreach (TreeNode node in nodes)
                    AddNode(node);
            }

            SchemaLine NodeToLine(TreeNode node)
            {
                var level = node.Level;
                var filespec = node.Tag.ToString();
                var description = node.Text;
                if (level == 2)
                    description = description.Remove(description.Length - filespec.Length - 3);
                var check = GetNodeState(node) == TreeNodeState.Checked;
                return new SchemaLine(level, description, filespec, check);
            }
        }

        public void Remove()
        {
            var node = SelectedNode;
            var level = node.Level;
            var lineType = LineTypes[level];
            if (MessageBox.Show(
                $"Remove '{node.Text}' from the available {lineType} list?",
                $"Delete the selected {lineType}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                ) == DialogResult.Yes)
                Nodes.Remove(node);
        }

        public void SetSchema(Schema schema)
        {
            Updater.Pause();
            Nodes.Clear();
            foreach (var line in schema.Lines)
            {
                var nodes = Nodes;
                for (var level = line.Level; level > 0; level--)
                    nodes = nodes.OfType<TreeNode>().Last().Nodes;
                AddNode(nodes, line.Description, line.Filespec, line.Check);
            }
            Updater.Resume();
        }

        public void SetView(TreeView treeView, TextBox edFilespecs)
        {
            TreeView = treeView;
            TriStateTreeController = new TriStateTreeController(TreeView);
            TriStateTreeController.NodeStateChanged += (sender, e) => UpdateUI();
            EdFilespecs = edFilespecs;
        }

        public void ShowFileFilter() => MessageBox.Show(
            Owner,
            GetSchema().FilterDescriptions,
            "Schema Formats",
            MessageBoxButtons.OK,
            MessageBoxIcon.None);

        #endregion

        #region Private Fields

        private TextBox EdFilespecs;
        private static readonly string[] LineTypes = new[] { "Root", "Media Category", "Filespec" };
        private TreeView TreeView;
        private TriStateTreeController TriStateTreeController;
        private UpdateController Updater;

        #endregion

        #region Private Properties

        private TreeNodeCollection Nodes => TreeView.Nodes;
        private TreeNode RootNode => Nodes.Count > 0 ? Nodes[0] : null;

        #endregion

        #region Private Methods

        private void AddNode(TreeNodeCollection nodes, string description, string filespec, bool check)
        {
            var node = nodes.Add(description);
            InitNode(node, description, filespec, check ? TreeNodeState.Checked : TreeNodeState.Unchecked);
        }

        private bool EditValue(string prompt, int level, ref string description, ref string filespec) =>
            new FilespecController(this).Execute(prompt, level, ref description, ref filespec);

        private static TreeNodeState GetNodeState(TreeNode node) => (TreeNodeState)node.StateImageIndex;

        private void InitNode(TreeNode node, string description, string filespec)
        {
            SelectedNode = node;
            node.Text = string.IsNullOrWhiteSpace(filespec) ? description : $"{description} ({filespec})";
            node.Tag = filespec;
            node.EnsureVisible();
            TreeView.Focus();
        }

        private void InitNode(TreeNode node, string description, string filespec, TreeNodeState state)
        {
            InitNode(node, description, filespec);
            SetNodeState(node, state);
        }

        private void SetNodeState(TreeNode node, TreeNodeState state)
        {
            Updater.Pause();
            TriStateTreeController.SetNodeState(node, state);
            Updater.Resume();
        }

        private void UpdateUI() => EdFilespecs.Text = GetSchema().FilterDescriptions;

        #endregion
    }
}
