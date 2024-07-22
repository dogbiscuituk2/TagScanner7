namespace TagScanner.Models
{
    using System.Windows.Forms;

    public class TagNode : TreeNode
    {
        #region Constructor

        public TagNode(Tag tag) : base(tag.DisplayName()) { Tag = tag.TagToTagInfo(); }

        #endregion

        public TagInfo TagInfo
        {
            get => (TagInfo)Tag;
            set => Tag = value;
        }
    }
}
