namespace TagScanner.Models
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public class TagxItem : ListViewItem
    {
        #region Constructors

        public TagxItem(Tagx tag) : this(tag.Tag, tag.Descending) { }
        public TagxItem(Tag tag) : this(tag, descending: false) { }
        public TagxItem(Tag tag, bool descending) : this(tag, descending ? ListSortDirection.Descending : ListSortDirection.Ascending) { }
        public TagxItem(Tag tag, ListSortDirection direction) : base() => Init(tag, direction);
        public TagxItem(SortDescription sort) : base() => Init(Tags.TagNameToTag(sort.PropertyName), sort.Direction);

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
