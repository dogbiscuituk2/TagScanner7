namespace TagScanner.Terms
{
    public enum Rank
    {
        None,
        Assignment,
        Conditional,
        NullCoalescing,
        ConditionalOR,
        ConditionalAND,
        BitwiseOR,
        BitwiseXOR,
        BitwiseAND,
        Equality,
        Relational,
        Shift,
        Additive,
        Multiplicative,
        SwitchWith,
        Range,
        Unary,
        Primary,
    }
}
