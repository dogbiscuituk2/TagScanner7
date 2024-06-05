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
        Then = 1L << 11,
        Else = 1L << 12,
        Or = 1L << 13,
        And = 1L << 14,
        BitwiseOr = 1L << 15,
        Xor = 1L << 16,
        BitwiseAnd = 1L << 17,
        EqualTo = 1L << 18,
        NotEqualTo = 1L << 19,
        LessThan = 1L << 20,
        NotLessThan = 1L << 21,
        GreaterThan = 1L << 22,
        NotGreaterThan = 1L << 23,
        LeftShift = 1L << 24,
        RightShift = 1L << 25,
        Concatenate = 1L << 26,
        Add = 1L << 27,
        Subtract = 1L << 28,
        Multiply = 1L << 29,
        Divide = 1L << 30,
        Modulo = 1L << 31,
        Positive = 1L << 32,
        Negative = 1L << 33,
        Not = 1L << 34,
        BitwiseNot = 1L << 35,
        Dot = 1L << 36,

        All = -1,
        Assignment = Assign | OrAssign | XorAssign | AndAssign | LeftShiftAssign | RightShiftAssign |
            AddAssign | SubtractAssign | MultiplyAssign | DivideAssign | ModuloAssign,
        Unary = Positive | Negative | Not | BitwiseNot,
        Trinary = Then | Else,
        Binary = All & ~(Unary | Trinary),
        Equality = EqualTo | NotEqualTo,
        Relational = LessThan | NotLessThan | GreaterThan | NotGreaterThan,
        Chains = Equality | Relational,
        Logical = And | AndAssign | Or | OrAssign | Xor | XorAssign | Chains | Not,
        Visible = ~Dot, // Also excludes "None".
    }
}
