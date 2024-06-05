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
        Comma = 1 << 0,
        Assignment = 1 << 1,
        Conditional = 1 << 2,
        NullCoalescing = 1 << 3,
        ConditionalOr = 1 << 4,
        ConditionalAnd = 1 << 5,
        BitwiseOr = 1 << 6,
        BitwiseXor = 1 << 7,
        BitwiseAnd = 1 << 8,
        Equality = 1 << 9,
        Relational = 1 << 10,
        Shift = 1 << 11,
        Additive = 1 << 12,
        Multiplicative = 1 << 13,
        SwitchWith = 1 << 14,
        Range = 1 << 15,
        Unary = 1 << 16,
        Primary = 1 << 17,
    }
}
