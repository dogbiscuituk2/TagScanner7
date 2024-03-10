namespace TagScanner.Terms
{
    public enum Precedence
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
