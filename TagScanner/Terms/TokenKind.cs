namespace TagScanner.Terms
{
    using System;

    [Flags]
    public enum TokenKind
    {
        None = 0,
        Boolean = 1 << 0,
        Character = 1 << 1,
        Comment = 1 << 2,
        DateTime = 1 << 3,
        Default = 1 << 4,
        Field = 1 << 5,
        Function = 1 << 6,
        Keyword = 1 << 7,
        Name = 1 << 8,
        Number = 1 << 9,
        String = 1 << 10,
        Symbol = 1 << 11,
        TimeSpan = 1 << 12,
        TypeName = 1 << 13,

        Constant = Boolean | Character | DateTime | Number | String | TimeSpan,
        Value = Constant | Default | Field | Function | Name,
    }
}
