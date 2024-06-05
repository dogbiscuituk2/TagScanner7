namespace TagScanner.Terms
{
    using System;

    [Flags]
    public enum Op: long
    {
        None = 0L,
        Assign = 1L << 0, // :=
        OrAssign = 1L << 1, // |=
        XorAssign = 1L << 2, // ^=
        AndAssign = 1L << 3, // &=
        LeftShiftAssign = 1L << 4, // <<=
        RightShiftAssign = 1L << 5, // >>=
        AddAssign = 1L << 6, // +=
        SubtractAssign = 1L << 7, // -=
        MultiplyAssign = 1L << 8, // *=
        DivideAssign = 1L << 9, // /=
        ModuloAssign = 1L << 10, // %=
        Or = 1L << 11,
        And = 1L << 12,
        BitwiseOr = 1L << 13,
        Xor = 1L << 14,
        BitwiseAnd = 1L << 15,
        EqualTo = 1L << 16,
        NotEqualTo = 1L << 17,
        LessThan = 1L << 18,
        NotLessThan = 1L << 19,
        GreaterThan = 1L << 20,
        NotGreaterThan = 1L << 21,
        LeftShift = 1L << 22,
        RightShift = 1L << 23,
        Concatenate = 1L << 24,
        Add = 1L << 25,
        Subtract = 1L << 26,
        Multiply = 1L << 27,
        Divide = 1L << 28,
        Modulo = 1L << 29,
        Positive = 1L << 30,
        Negative = 1L << 31,
        Not = 1L << 32,
        BitwiseNot = 1L << 33,
        Dot = 1L << 34,

        All = -1,
        Assignment = Assign | OrAssign | XorAssign | AndAssign | LeftShiftAssign | RightShiftAssign |
            AddAssign | SubtractAssign | MultiplyAssign | DivideAssign | ModuloAssign,
        Unary = Positive | Negative | Not | BitwiseNot,
        Binary = All & ~Unary,
        Equality = EqualTo | NotEqualTo,
        Relational = LessThan | NotLessThan | GreaterThan | NotGreaterThan,
        Chains = Equality | Relational,
        Logical = And | AndAssign | Or | OrAssign | Xor | XorAssign | Chains | Not,
        Visible = ~Dot, // Also excludes "None".
    }
}
