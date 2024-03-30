﻿namespace TagScanner.Terms
{
    using System;

    [Serializable]
    public enum Op
    {
        Comma,
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
        Dot,
    }
}
