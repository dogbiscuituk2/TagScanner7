namespace TagScanner.Terms
{
    using System;

    [Flags]
    public enum Rank
    {
        None = 0,
        Assignment = 0x0001,
        Conditional = 0x0002,
        NullCoalescing = 0x0004,
        ConditionalOR = 0x0008,
        ConditionalAND = 0x0010,
        BitwiseOR = 0x0020,
        BitwiseXOR = 0x0040,
        BitwiseAND = 0x0080,
        Equality = 0x0100,
        Relational = 0x0200,
        Shift = 0x0400,
        Additive = 0x0800,
        Multiplicative = 0x1000,
        SwitchWith = 0x2000,
        Range = 0x4000,
        Unary = 0x8000,
        Primary = 0x10000,
    }
}
