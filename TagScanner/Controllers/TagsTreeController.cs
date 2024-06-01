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
        #region Construictor

        public TagsTreeController(Controller parent) : base(parent) { }

        #endregion

        #region Public Methods

        public void InitView()
        {
            InitNodes();
            RootNode.Expand();
            Dialog.TreeMenu.DropDownOpening += (sender, e) => UpdateMenu();
        }

        public override IEnumerable<Tag> GetSelectedTags()
        {
            var result = new List<Tag>();
            Visit(p => { if (p.Tag is TagInfo tagInfo && p.Checked) result.Add(tagInfo.Tag); });
            return result;
        }

        public override void SetSelectedTags(IEnumerable<Tag> visibleTags) =>
            Visit(p => { if (p.Tag is TagInfo tagInfo) p.Checked = visibleTags.Contains(tagInfo.Tag); });

        #endregion

        #region Protected Properties

        protected override Control Control => TreeView;

        #endregion

        #region Protected Methods

        protected override void InitGroups()
        {
            InitNodes();
        }

        #endregion

        #region Private Properties

        private TreeNodeCollection Nodes => RootNode.Nodes;
        private TreeNode RootNode => TreeView.Nodes[0];
        private TreeView TreeView => Dialog.TreeView;

        #endregion

        #region Private Methods

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
                    return AvailableTags.Select(p => p.Type().Say());
                default:
                    return Array.Empty<string>();
            }
        }

        private void InitNodes()
        {
            TreeView.Nodes.Clear();
            TreeView.Nodes.Add("All Tags");
            foreach (var parentName in GetParentNames().Distinct().OrderBy(p => p))
                RootNode.Nodes.Add(parentName);
            foreach (var tag in SortTags())
            {
                var node = FindParent(tag).Nodes.Add(tag.Name, tag.DisplayName);
                node.ToolTipText = tag.Details;
                node.Tag = tag;
            }
        }

        private void UpdateMenu()
        {
            Dialog.TreeByCategory.Checked = Active && GroupTagsBy == GroupTagsBy.Category;
            Dialog.TreeByDataType.Checked = Active && GroupTagsBy == GroupTagsBy.DataType;
            Dialog.TreeNamesOnly.Checked = Active && GroupTagsBy == GroupTagsBy.None; ;
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
