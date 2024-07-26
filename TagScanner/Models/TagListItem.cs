namespace TagScanner.Models
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public class TagListItem : ListViewItem
    {
        #region Constructors

        public TagListItem(Tag tag)
            : this(tag, descending: false) { }

        public TagListItem(Tag tag, bool descending)
            : this(tag, descending ? ListSortDirection.Descending : ListSortDirection.Ascending) { }

        public TagListItem(Tag tag, ListSortDirection direction)
            : base() => Init(tag, direction);

        public TagListItem(SortDescription sort)
            : base() => Init(Tags.TagNameToTag(sort.PropertyName), sort.Direction);

        #endregion

        #region Public Properties

        public ListSortDirection Direction
        {
            get => (ListSortDirection)StateImageIndex;
            set => StateImageIndex = (int)value;
        }

        #endregion

        #region Private Methods

        private void Init(Tag tag, ListSortDirection direction = ListSortDirection.Ascending)
        {
            Direction = direction;
            Name = $"{tag}";
            Tag = tag;
            Text = tag.DisplayName();
            ToolTipText = tag.Details();
        }

        #endregion
    }
}
