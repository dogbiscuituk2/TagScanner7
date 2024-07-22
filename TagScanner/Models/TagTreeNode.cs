namespace TagScanner.Models
{
    using System.Windows.Forms;

    public class TagTreeNode : TreeNode
    {
        #region Constructor

        public TagTreeNode(Tag tag) : base(tag.DisplayName()) { Tag = tag.TagToTagInfo(); }

        #endregion

        public TagInfo TagInfo
        {
            get => (TagInfo)Tag;
            set => Tag = value;
        }
    }
}
