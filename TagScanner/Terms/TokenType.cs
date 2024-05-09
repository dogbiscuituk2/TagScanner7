namespace TagScanner.Terms
{
    using System;

    [Flags]
    public enum TokenType
    {
        None = 0,
        Boolean = 1 << 0,
        Character = 1 << 1,
        Comment = 1 << 2,
        DateTime = 1 << 3,
        Function = 1 << 4,
        ListField = 1 << 5,
        Number = 1 << 6,
        Parameter = 1 << 7,
        String = 1 << 8,
        Symbol = 1 << 9,
        TimeSpan = 1 << 10,
        TrackField = 1 << 11,
        TypeName = 1 << 12,
        Variable = 1 << 13,

        Constant = Boolean | Character | DateTime | Number | String | TimeSpan
    }
}
