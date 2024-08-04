namespace TagScanner.Models
{
    using System;

    /// <summary>
    /// Structure holding a Tag value, and optionally a ListSortDirection, which may be supplied to
    /// either the GroupDescriptions or the SortDescriptions property of a ListCollectionView, or
    /// otherwise used as a Column visibility control in a suitable Table or View.
    /// </summary>
    [Serializable]
    public class Tagx
    {
        #region Constructors

        public Tagx(Tag tag) : this(tag, 0) { }
        public Tagx(Tag tag, int stateIndex) : this(tag, stateIndex == 1) { }
        public Tagx(Tag tag, bool descending) { Tag = tag; Descending = descending; }

        #endregion

        #region Public Properties

        public bool Descending { get; set; }
        public Tag Tag { get; set; }

        #endregion
    }
}
