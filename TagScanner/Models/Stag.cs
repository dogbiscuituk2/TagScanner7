namespace TagScanner.Models
{
    using System;
    using System.ComponentModel;

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
        public Stag(Tag tag, ListSortDirection direction) : this(tag, (int)direction) { }
        public Stag(Tag tag, bool descending) { Tag = tag; Descending = descending; }

        #endregion

        #region Public Properties

        public string Caption => $"{Tag.DisplayName()}{(Descending ? '↓' : '↑')}";
        public bool Descending { get; set; }
        public Tag Tag { get; set; }

        #endregion

        #region Public Methods

        public SortDescription ToSortDescription() => new SortDescription($"{Tag}", (ListSortDirection)(Descending ? 1 : 0));

        public override string ToString() => $"Tag: {Tag}, Descending: {Descending}";

        #endregion
    }
}
