namespace TagScanner.Controllers
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Core;

    public class TriStateTreeController
    {
        #region Constructor

        public TriStateTreeController(TreeView treeView)
        {
            TreeView = treeView;
            TreeView.KeyPress += TreeView_KeyPress;
            TreeView.NodeMouseClick += TreeView_NodeMouseClick;
        }

        #endregion

        #region Public Properties

        public TreeView TreeView { get; }

        #endregion

        #region Public Events

        public event EventHandler NodeStateChanged;

        #endregion

        #region Public Methods

        public TreeNodeState GetNodeState(TreeNode node) => (TreeNodeState)node.StateImageIndex;

        public void SetNodeState(TreeNode node, TreeNodeState state)
        {
            InitDescendants(node, state);
            InitAncestors(node);
            OnNodeStateChanged();
        }

        #endregion

        #region Protected Methods

        protected virtual void OnNodeStateChanged() => NodeStateChanged?.Invoke(this, EventArgs.Empty);

        #endregion

        #region Event Handlers

        private void TreeView_KeyPress(object sender, KeyPressEventArgs e) => ToggleState(TreeView.SelectedNode);

        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var p = e.Location;
            if (TreeView.HitTest(p).Location == TreeViewHitTestLocations.StateImage)
                ToggleState(TreeView.GetNodeAt(p));
        }

        #endregion

        #region Private Methods

        private void InitAncestors(TreeNode node)
        {
            for (var parent = node.Parent; parent != null; parent = parent.Parent)
            {
                var nodes = parent.Nodes.OfType<TreeNode>();
                parent.StateImageIndex =
                    nodes.All(p => p.StateImageIndex == 0) ? 0 :
                    nodes.All(q => q.StateImageIndex == 1) ? 1 : 2;
            }
        }

        private void InitDescendants(TreeNode node, TreeNodeState state)
        {
            node.StateImageIndex = (int)state;
            foreach (TreeNode child in node.Nodes)
                SetNodeState(child, state);
        }

        private void ToggleState(TreeNode node)
        {
            if (node == null)
                return;
            var newState = GetNodeState(node) == TreeNodeState.Checked ? TreeNodeState.Unchecked : TreeNodeState.Checked;
            SetNodeState(node, newState);
            if (GetNodeState(node) == TreeNodeState.Checked) { }
        }

        #endregion
    }
}