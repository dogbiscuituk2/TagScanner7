namespace TagScanner.Models
{
    using System;

    [Flags]
    public enum FileFlags
    {
        CreatedMin = 1 << 0,
        CreatedMax = 1 << 1,
        CreatedUtc = 1 << 2,
        ModifiedMin = 1 << 3,
        ModifiedMax = 1 << 4,
        ModifiedUtc = 1 << 5,
        AccessedMin = 1 << 6,
        AccessedMax = 1 << 7,
        AccessedUtc = 1 << 8,

        FileSizeMin = 1 << 9,
        FileSizeMax = 1 << 10,

        ReadOnlyTrue = 1 << 11,
        ReadOnlyFalse = 1 << 12,
        HiddenTrue = 1 << 13,
        HiddenFalse = 1 << 14,
        SystemTrue = 1 << 15,
        SystemFalse = 1 << 16,
        ArchiveTrue = 1 << 17,
        ArchiveFalse = 1 << 18,

        DateCreated = CreatedMin | CreatedMax,
        DateModified = ModifiedMin | ModifiedMax,
        DateAccessed = AccessedMin | AccessedMax,
        Date = DateCreated | DateModified | DateAccessed,

        FileSize = FileSizeMax | FileSizeMin,

        ReadOnly = ReadOnlyTrue | ReadOnlyFalse,
        Hidden = HiddenTrue | HiddenFalse,
        System = SystemTrue | SystemFalse,
        Archive = ArchiveTrue | ArchiveFalse,
        Attributes = ReadOnly | Hidden | System | Archive,
    }
}
