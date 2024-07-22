namespace TagScanner.Models
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public class TagItem : ListViewItem
    {
        #region Constructors

        public TagItem(Tag tag) : base(tag.DisplayName())
        {
            Tag = tag.TagToTagInfo();
        }

        public TagItem(SortDescription sort) : this(sort.PropertyName.DisplayNameToTag())
        {
            SortDirection = sort.Direction;
        }

        #endregion

        #region Public Properties

        public ListSortDirection SortDirection
        {
            get => (ListSortDirection)StateImageIndex;
            set => StateImageIndex = (int)value;
        }

        public TagInfo TagInfo
        {
            get => (TagInfo)Tag;
            set => Tag = value;
        }

        #endregion
    }
}
