namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Models;
    using Terms;

    public class TagsTreeController : TagsViewController
    {
        #region Constructor

        public TagsTreeController(TagsSelectorController parent, TreeView treeView) : base(parent, treeView) { }

        #endregion

        #region Public Methods

        public override IEnumerable<Tag> GetSelectedTags()
        {
            var result = new List<Tag>();
            Visit(p =>
            {
                if (p.Tag is TagInfo tagInfo && p.StateImageIndex == (int)TreeNodeState.Checked)
                    result.Add(tagInfo.Tag);
            });
            return result;
        }

        public void InitView()
        {
            InitNodes();
            RootNode.Expand();
            TriStateTreeController = new TriStateTreeController(TreeView);
            TriStateTreeController.NodeStateChanged += TriStateTreeController_NodeStateChanged;
        }

        public override void SetSelectedTags(IEnumerable<Tag> visibleTags) => Visit(p =>
        {
            if (p.Tag is TagInfo tagInfo)
                TriStateTreeController.SetNodeState(p, 
                    visibleTags.Contains(tagInfo.Tag)
                    ? TreeNodeState.Checked
                    : TreeNodeState.Unchecked);
        });

        #endregion

        #region Protected Methods

        protected override void InitGroups()
        {
            InitNodes();
        }

        #endregion

        #region Private Fields

        private TriStateTreeController TriStateTreeController;

        #endregion

        #region Private Properties

        private TreeNodeCollection Nodes => RootNode.Nodes;
        private TreeNode RootNode => TreeView.Nodes[0];
        private TreeView TreeView => (TreeView)Control;

        #endregion

        #region Event Handlers

        private void TriStateTreeController_NodeStateChanged(object sender, EventArgs e) => ((TagsSelectorController)Parent).UpdateSelection();

        #endregion

        #region Private Methods

        private TreeNode AddNode(TreeNodeCollection nodes, TagInfo tag)
        {
            var node = AddNode(nodes, tag.Name, tag.DisplayName);
            node.Tag = tag;
            node.ToolTipText = tag.Details;
            return node;
        }

        private TreeNode AddNode(TreeNodeCollection nodes, string key, string text = null)
        {
            var node = nodes.Add(key, text ?? key);
            node.StateImageIndex = 0;
            return node;
        }

        private TreeNode FindNode(string text) => Nodes.Cast<TreeNode>().FirstOrDefault(p => p.Text == text) ?? Nodes.Add(text);

        private TreeNode FindParent(TagInfo tag)
        {
            switch (GroupTagsBy)
            {
                case GroupTagsBy.Category:
                    return FindNode(tag.Category);
                case GroupTagsBy.DataType:
                    return FindNode(tag.TypeName);
                default:
                    return RootNode;
            }
        }

        private IEnumerable<string> GetParentNames()
        {
            switch (GroupTagsBy)
            {
                case GroupTagsBy.Category:
                    return AvailableTags.Select(p => p.Category());
                case GroupTagsBy.DataType:
                    return AvailableTags.Select(p => p.Type().Name);
                default:
                    return Array.Empty<string>();
            }
        }

        private void InitNodes()
        {
            TreeView.Nodes.Clear();
            AddNode(TreeView.Nodes, "All Tags");
            foreach (var parentName in GetParentNames().Distinct().OrderBy(p => p))
                AddNode(RootNode.Nodes, parentName);
            foreach (var tag in SortTags())
                AddNode(FindParent(tag).Nodes, tag);
            RootNode.Expand();
        }

        private void Visit(Action<TreeNode> action)
        {
            DoVisit(RootNode);

            void DoVisit(TreeNode parent)
            {
                action(parent);
                foreach (TreeNode child in parent.Nodes)
                    DoVisit(child);
            }
        }

        #endregion
    }
}
