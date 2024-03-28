namespace TagScanner.Terms
{
    using System;

    /// <summary>
    /// The term "Rank" is used in preference to "Precedence" coz short.
    /// </summary>
    [Flags]
    public enum Rank
    {
        None = 0,
        Comma = 0x0001,
        Assignment = 0x0002,
        Conditional = 0x0004,
        ConditionalOr = 0x0008,
        ConditionalAnd = 0x0010,
        BitwiseOr = 0x0020,
        BitwiseXor = 0x0040,
        BitwiseAnd = 0x0080,
        Equality = 0x0100,
        Relational = 0x0200,
        Shift = 0x0400,
        Additive = 0x0800,
        Multiplicative = 0x1000,
        Unary = 0x2000,
        Postfix = 0x4000,
    }
}
