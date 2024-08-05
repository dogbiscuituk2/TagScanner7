namespace TagScanner.Core
{
    using System;

    [Flags]
    public enum FileFlags
    {
        UseTimes = 1 << 0,
        CreatedMin = 1 << 1,
        CreatedMax = 1 << 2,
        CreatedUtc = 1 << 3,
        ModifiedMin = 1 << 4,
        ModifiedMax = 1 << 5,
        ModifiedUtc = 1 << 6,
        AccessedMin = 1 << 7,
        AccessedMax = 1 << 8,
        AccessedUtc = 1 << 9,

        FileSizeMin = 1 << 10,
        FileSizeMax = 1 << 11,

        ReadOnlyTrue = 1 << 12,
        ReadOnlyFalse = 1 << 13,
        HiddenTrue = 1 << 14,
        HiddenFalse = 1 << 15,
        SystemTrue = 1 << 16,
        SystemFalse = 1 << 17,
        ArchiveTrue = 1 << 18,
        ArchiveFalse = 1 << 19,
        CompressedTrue = 1 << 20,
        CompressedFalse = 1 << 21,
        EncryptedTrue = 1 << 22,
        EncryptedFalse = 1 << 23,

        Created = CreatedMin | CreatedMax | CreatedUtc,
        Modified = ModifiedMin | ModifiedMax | ModifiedUtc,
        Accessed = AccessedMin | AccessedMax | AccessedUtc,
        FileSize = FileSizeMin | FileSizeMax,

        Min = CreatedMin | ModifiedMin | AccessedMin | FileSizeMin,
        Max = CreatedMax | ModifiedMax | AccessedMax | FileSizeMax,
        Utc = CreatedUtc | ModifiedUtc | AccessedUtc,

        ReadOnly = ReadOnlyTrue | ReadOnlyFalse,
        Hidden = HiddenTrue | HiddenFalse,
        System = SystemTrue | SystemFalse,
        Archive = ArchiveTrue | ArchiveFalse,
        Compressed = CompressedTrue | CompressedFalse,
        Encrypted = EncryptedTrue | EncryptedFalse,

        True = ReadOnlyTrue | HiddenTrue | SystemTrue | ArchiveTrue | CompressedTrue | EncryptedTrue,
        False = ReadOnlyFalse | HiddenFalse | SystemFalse | ArchiveFalse | CompressedFalse | EncryptedFalse,
    }
}
