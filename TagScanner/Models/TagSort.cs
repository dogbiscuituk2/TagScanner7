namespace TagScanner.Models
{
    using System.ComponentModel;

    public struct TagSort
    {
        #region Constructors

        public TagSort(object tag) : this(tag, 0) { }
        public TagSort(object tag, int stateIndex) : this(tag, stateIndex == 1) { }
        public TagSort(object tag, bool descending) { Tag = (Tag)tag; Descending = descending; }
        public TagSort(object tag, ListSortDirection direction) : this(tag, direction == ListSortDirection.Descending) { }

        #endregion

        #region Public Properties

        public Tag Tag { get; set; }
        public bool Descending { get; set; }

        #endregion
    }
}
