namespace TagScanner.Core
{
    using System;

    [Flags]
    public enum Verb
    {
        None = 0,
        Drag_Drop = 1 << 0,
        Move_Up = 1 << 1,
        Move_Down = 1 << 2,
        Selection = 1 << 3,
        Sort_Ascending = 1 << 4,
        Sort_Descending = 1 << 5,
        Grouping = 1 << 6,
        Cut = 1 << 7,
        Copy = 1 << 8,
        Paste = 1 << 9,
        Delete = 1 << 10,
        Clear = 1 << 11,
        Select_All = 1 << 12,
        Invert_Selection = 1 << 13,

        Moving = Move_Up | Move_Down,
        Sorting = Sort_Ascending | Sort_Descending,
        Active = Selection | Sorting | Grouping,
        Passive = Drag_Drop | Moving | Cut | Paste | Delete | Clear,
    }
}
