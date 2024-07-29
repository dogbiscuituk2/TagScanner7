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

        private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            var bounds = e.Bounds;
            if (bounds.IsEmpty)
                return;
            var node = e.Node;
            var tag = node.Tag;
            var state = e.State;
            bool
                treeFocused = TreeView.Focused,
                nodeSelected = (state & TreeNodeStates.Selected) != 0,
                leafNode = tag is Tag,
                canWrite = leafNode && ((Tag)tag).CanWrite();
            KnownColor fore, back;

            if (treeFocused)
            {
                if (nodeSelected)
                    (fore, back) = (KnownColor.HighlightText, KnownColor.Highlight);
                else if (!leafNode || canWrite)
                    (fore, back) = (KnownColor.WindowText, KnownColor.Window);
                else
                    (fore, back) = (KnownColor.GrayText, KnownColor.Window);
            }
            else
            {
                if (nodeSelected)
                    (fore, back) = (KnownColor.WindowText, KnownColor.InactiveCaption);
                else if (!leafNode || canWrite)
                    (fore, back) = (KnownColor.WindowText, KnownColor.Window);
                else
                    (fore, back) = (KnownColor.GrayText, KnownColor.Window);
            }

            /*{
                e.DrawDefault = true;
                return;
            }*/
            bounds.Offset(1, 0);
            var surround = bounds;
            surround.Inflate(2, 0);
            var g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.FromKnownColor(back)), surround);
            g.DrawString(node.Text, TreeView.Font, new SolidBrush(Color.FromKnownColor(fore)), bounds);

            //if (node.Tag == null || ((Tag)node.Tag).CanWrite() || (e.State & (TreeNodeStates.Selected | TreeNodeStates.Focused)) != 0)
            //            e.DrawDefault = true;
            /*else
            {
                var g = e.Graphics;
                r.Offset(1, 0);
                r.Inflate(+2, 0); g.FillRectangle(new SolidBrush(TreeView.BackColor), r);
                r.Inflate(-2, 0); g.DrawString(node.Text, TreeView.Font, new SolidBrush(ReadOnlyColour), r);
            }*/
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
