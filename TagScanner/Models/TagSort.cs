namespace TagScanner.Models
{
    using System.ComponentModel;

    /// <summary>
    /// Structure holding a Tag value, and optionally a ListSortDirection, which may be supplied to
    /// either the GroupDescriptions or the SortDescriptions property of a ListCollectionView, or
    /// otherwise used as a Column visibility control in a suitable Table or View.
    /// </summary>
    public struct TagSort
    {
        #region Constructors

        public TagSort(object tag) : this(tag, 0) { }
        public TagSort(object tag, int stateIndex) : this(tag, stateIndex == 1) { }
        public TagSort(object tag, bool descending) { Tag = (Tag)tag; Descending = descending; }
        public TagSort(object tag, ListSortDirection direction) : this(tag, direction == ListSortDirection.Descending) { }

        #endregion

        #region Public Properties

        public bool Descending { get; set; }
        public Tag Tag { get; set; }

        #endregion
    }
}
