namespace TagScanner.Core
{
    using System;

    [Flags]
    public enum Verb
    {
        None,
        Merge,
        MoveUp,
        MoveDown,
        SelectTags,
        SortAscending,
        SortDescending,
        GroupBy,
        Cut,
        Copy,
        Paste,
        Delete,
        Clear,
        SelectAll,
        InvertSelection,
    }
}
