namespace TagScanner.Models
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public class TagListItem : ListViewItem
    {
        #region Constructors

        public TagListItem(Tag tag) : base() => Init(tag);

        public TagListItem(SortDescription sort) : base() =>
            Init(Tags.TagNameToTag(sort.PropertyName), sort.Direction);

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
        }

        #endregion
    }
}
