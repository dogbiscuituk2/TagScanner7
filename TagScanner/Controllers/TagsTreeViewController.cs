namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    public class TagsTreeViewController : TagsViewController
    {
        #region Public Interface

        public TagsTreeViewController(Controller parent) : base(parent) { }

        public override Control Control => TreeView;

        public void InitTreeView()
        {
            TreeView.Nodes.Clear();
            TreeView.Nodes.Add("All Tags");
            foreach (var tag in SortTags())
            {
                var node = FindParent(tag).Nodes.Add(tag.Name, tag.DisplayName);
                node.ToolTipText = tag.Details;
                node.Tag = tag;
            }
            RootNode.Expand();
            Dialog.TreeMenu.DropDownOpening += (sender, e) => InitTreeMenu();
        }

        #endregion

        #region Private Implementation

        private TreeNodeCollection Nodes => RootNode.Nodes;
        private TreeNode RootNode => TreeView.Nodes[0];
        private TreeView TreeView => Dialog.TreeView;

        private TreeNode FindNode(string text) => Nodes.Cast<TreeNode>().FirstOrDefault(p => p.Text == text) ?? Nodes.Add(text);

        private TreeNode FindParent(TagProps tag)
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

        protected override IEnumerable<string> GetVisibleTags()
        {
            return null;
        }

        protected override void InitGroups()
        {
        }

        private void InitTreeMenu()
        {
            var tree = TreeView.Visible;
            Dialog.TreeByCategory.Checked = tree && GroupTagsBy == GroupTagsBy.Category;
            Dialog.TreeByDataType.Checked = tree && GroupTagsBy == GroupTagsBy.DataType;
            Dialog.TreeNamesOnly.Checked = tree && GroupTagsBy == GroupTagsBy.None; ;
        }

        protected override void SetVisibleTags(IEnumerable<string> visibleTagNames)
        {
        }

        #endregion
    }
}
