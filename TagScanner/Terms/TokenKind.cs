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
        Number = 1 << 7,
        String = 1 << 8,
        Symbol = 1 << 9,
        TimeSpan = 1 << 10,
        TypeName = 1 << 11,
        Variable = 1 << 12,

        Constant = Boolean | Character | DateTime | Number | String | TimeSpan,
        Value = Constant | Default | Field | Function | Variable,
    }
}
