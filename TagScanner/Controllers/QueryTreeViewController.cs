namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows;
    using System.Windows.Forms;
    using Models;

    public class QueryTreeViewController : QueryViewController
    {
        #region Constructor

        public QueryTreeViewController(QueryController parent, TreeView treeView) : base(parent, treeView)
        {
            TreeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            TreeView.DrawNode += TreeView_DrawNode;
        }

        private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            var node = e.Node;
            if (node.Tag == null || ((Tag)node.Tag).CanWrite() || (e.State & TreeNodeStates.Selected) != 0)
                e.DrawDefault = true;
            else
                e.Graphics.DrawString(node.Text, TreeView.Font, new SolidBrush(ReadOnlyColour), e.Bounds);
        }

        #endregion

        #region Public Methods

        public void InitView()
        {
            InitGroups();
            RootNode.Expand();
        }

        #endregion

        #region Protected Methods

        protected override void InitGroups()
        {
            TreeView.Nodes.Clear();
            AddNode(TreeView.Nodes, "All Tags");
            foreach (var parentName in GetParentNames().Distinct().OrderBy(p => p))
                AddNode(RootNode.Nodes, parentName);
            foreach (var tag in SortTags())
                AddNode(FindParent(tag).Nodes, tag);
            RootNode.Expand();
        }

        #endregion

        #region Private Properties

        private TreeNodeCollection Nodes => RootNode.Nodes;
        private TreeNode RootNode => TreeView.Nodes[0];
        private TreeView TreeView => (TreeView)Control;

        #endregion

        #region Private Methods

        private TreeNode AddNode(TreeNodeCollection nodes, Tag tag)
        {
            var node = AddNode(nodes, tag.Name(), tag.DisplayName());
            node.Tag = tag;
            node.ToolTipText = tag.Details();
            return node;
        }

        private TreeNode AddNode(TreeNodeCollection nodes, string key, string text = null)
        {
            var node = nodes.Add(key, text ?? key);
            node.StateImageIndex = 0;
            return node;
        }

        private TreeNode FindNode(string text) => Nodes.Cast<TreeNode>().FirstOrDefault(p => p.Text == text) ?? Nodes.Add(text);

        private TreeNode FindParent(Tag tag)
        {
            switch (TagGrouping)
            {
                case TagGrouping.Category:
                    return FindNode(tag.Category());
                case TagGrouping.DataType:
                    return FindNode(tag.TypeName());
                default:
                    return RootNode;
            }
        }

        private IEnumerable<string> GetParentNames()
        {
            switch (TagGrouping)
            {
                case TagGrouping.Category:
                    return AvailableTags.Select(p => p.Category());
                case TagGrouping.DataType:
                    return AvailableTags.Select(p => p.Type().Name);
                default:
                    return Array.Empty<string>();
            }
        }

        #endregion
    }
}
