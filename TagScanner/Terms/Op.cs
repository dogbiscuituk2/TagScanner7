namespace TagScanner.Terms
{
    using System;

    [Serializable]
    public enum Op
    {
        Conditional,
        And,
        Or,
        Xor,
        EqualTo,
        NotEqualTo,
        LessThan,
        NotLessThan,
        GreaterThan,
        NotGreaterThan,
        Concatenate,
        Add,
        Subtract,
        Multiply,
        Divide,
        Positive,
        Negative,
        Not,
    }
}
