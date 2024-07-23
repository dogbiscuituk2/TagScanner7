namespace TagScanner.Models
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public class TagListItem : ListViewItem
    {
        #region Constructors

        public TagListItem(Tag tag) : base()
        {
            SortDirection = ListSortDirection.Ascending;
            Text = tag.DisplayName();
        }

        public TagListItem(SortDescription sort) : this(sort.PropertyName.DisplayNameToTag())
        {
            SortDirection = sort.Direction;
        }

        #endregion

        #region Public Properties

        public SortDescription SortDescription
        {
            get => new SortDescription(Text, SortDirection);
            set
            {
                Text = value.PropertyName;
                SortDirection = value.Direction;
                Tag = Tags.TagNameToTag(Text);
            }
        }

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
