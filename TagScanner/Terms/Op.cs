namespace TagScanner.Terms
{
    using System;

    [Flags]
    public enum Op: long
    {
        None = 0,
        Comma = 1 << 0,
        Assign = 1 << 1, // :=
        AddAssign = 1 << 2, // +=
        SubtractAssign = 1 << 3, // -=
        MultiplyAssign = 1 << 4, // *=
        DivideAssign = 1 << 5, // /=
        ModuloAssign = 1 << 6, // %=
        AndAssign = 1 << 7, // &=
        OrAssign = 1 << 8, // |=
        XorAssign = 1 << 9, // ^=
        And = 1 << 10,
        Or = 1 << 11,
        Xor = 1 << 12,
        EqualTo = 1 << 13,
        NotEqualTo = 1 << 14,
        LessThan = 1 << 15,
        NotLessThan = 1 << 16,
        GreaterThan = 1 << 17,
        NotGreaterThan = 1 << 18,
        Concatenate = 1 << 19,
        Add = 1 << 20,
        Subtract = 1 << 21,
        Multiply = 1 << 22,
        Divide = 1 << 23,
        Modulo = 1 << 24,
        Positive = 1 << 25,
        Negative = 1 << 26,
        Not = 1 << 27,
        Dot = 1 << 28,

        All = -1,
        Assignment = Assign | AddAssign | SubtractAssign | MultiplyAssign | DivideAssign | ModuloAssign | AndAssign | OrAssign | XorAssign,
        Unary = Positive | Negative | Not,
        Binary = All & ~Unary,
        Equality = EqualTo | NotEqualTo,
        Relational = LessThan | NotLessThan | GreaterThan | NotGreaterThan,
        Chains = Equality | Relational,
        Logical = And | AndAssign | Or | OrAssign | Xor | XorAssign | Chains | Not,
        Visible = ~Dot, // Also excludes "None".
    }
}
