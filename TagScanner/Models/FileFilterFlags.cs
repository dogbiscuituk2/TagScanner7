namespace TagScanner.Models
{
    using System;

    [Flags]
    public enum FileFilterFlags
    {
        DateCreatedMin = 1 << 0,
        DateCreatedMax = 1 << 1,
        DateCreatedUtc = 1 << 2,
        DateModifiedMin = 1 << 3,
        DateModifiedMax = 1 << 4,
        DateModifiedUtc = 1 << 5,
        DateAccessedMin = 1 << 6,
        DateAccessedMax = 1 << 7,
        DateAccessedUtc = 1 << 8,

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

        DateCreated = DateCreatedMin | DateCreatedMax,
        DateModified = DateModifiedMin | DateModifiedMax,
        DateAccessed = DateAccessedMin | DateAccessedMax,
        Date = DateCreated | DateModified | DateAccessed,

        FileSize = FileSizeMax | FileSizeMin,

        ReadOnly = ReadOnlyTrue | ReadOnlyFalse,
        Hidden = HiddenTrue | HiddenFalse,
        System = SystemTrue | SystemFalse,
        Archive = ArchiveTrue | ArchiveFalse,
        Attributes = ReadOnly | Hidden | System | Archive,
    }
}
