namespace TagScanner.Models
{
    using System;

    /// <summary>
    /// A "Sorted Tag" structure holding a Tag value, and optionally a ListSortDirection,
    /// which may be supplied to either the GroupDescriptions or the SortDescriptions
    /// property of a ListCollectionView, or otherwise used to control Column visibility
    /// in a suitable Table or View.
    /// </summary>
    [Serializable]
    public class Stag
    {
        #region Constructors

        public Stag(Tag tag) : this(tag, 0) { }
        public Stag(Tag tag, int state) : this(tag, state == 1) { }
        public Stag(Tag tag, bool descending) { Tag = tag; Descending = descending; }

        #endregion

        #region Public Properties

        public bool Descending { get; set; }
        public Tag Tag { get; set; }

        #endregion

        #region Public Methods

        public override string ToString() => $"Tag: {Tag}, Descending: {Descending}";

        #endregion
    }
}
