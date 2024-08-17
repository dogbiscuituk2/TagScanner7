namespace TagScanner.Core
{
    using System;

    [Flags]
    public enum QueryVerb
    {
        None = 0,

        Merge = 1 << 0,
        MoveUp = 1 << 1,
        MoveDown = 1 << 2,
        Cut = 1 << 3,
        Copy = 1 << 4,
        Paste = 1 << 5,
        Delete = 1 << 6,
        Clear = 1 << 7,
        SelectAll = 1 << 8,
        InvertSelection = 1 << 9,

        SelectTags = 1 << 10,
        SortAscending = 1 << 11,
        SortDescending = 1 << 12,
        Group = 1 << 13,

        Move = MoveUp | MoveDown,
        Clipboard = Cut | Copy | Paste,
        Sort = SortAscending | SortDescending,
        Action = Merge | Move | Clipboard | Delete | Clear | SelectAll | InvertSelection,
        Clause = SelectTags | Sort | Group,
    }
}
