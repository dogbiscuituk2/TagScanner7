namespace TagScanner.Models
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public class StagItem : ListViewItem
    {
        #region Constructors

        public StagItem(Stag stag) : this(stag.Tag, stag.Descending) { }
        public StagItem(Tag tag) : this(tag, descending: false) { }
        public StagItem(Tag tag, bool descending) : this(tag, descending ? ListSortDirection.Descending : ListSortDirection.Ascending) { }
        public StagItem(Tag tag, ListSortDirection direction) : base() => Init(tag, direction);
        public StagItem(SortDescription sort) : base() => Init(Tags.TagNameToTag(sort.PropertyName), sort.Direction);

        #endregion

        #region Public Properties

        public ListSortDirection Direction
        {
            get => (ListSortDirection)ImageIndex;
            set => ImageIndex = (int)value;
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
