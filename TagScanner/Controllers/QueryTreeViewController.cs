namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
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

        #region Event Handlers

        private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e) =>
            DrawNode(e.Graphics, e.Bounds, e.Node.Text, e.Node.Tag, (e.State & TreeNodeStates.Selected) != 0);

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

        private void DrawNode(Graphics graphics, Rectangle bounds, string text, object tag, bool selected)
        {
            if (bounds.IsEmpty)
                return;
            var leaf = tag is Tag;
            GetColours(selected, !leaf || ((Tag)tag).CanWrite(), out Color fore, out Color back);
            bounds.Offset(1, 0);
            var surround = bounds;
            surround.Inflate(2, 0);
            graphics.FillRectangle(new SolidBrush(back), surround);
            graphics.DrawString(text, TreeView.Font, new SolidBrush(fore), bounds);
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
