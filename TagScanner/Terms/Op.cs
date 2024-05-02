namespace TagScanner.Terms
{
    using System;

    [Flags]
    public enum Op
    {
        None = 0,
        Comma = 1,
        Let = 2,
        And = 4,
        Or = 8,
        Xor = 0x10,
        EqualTo = 0x20,
        NotEqualTo = 0x40,
        LessThan = 0x80,
        NotLessThan = 0x100,
        GreaterThan = 0x200,
        NotGreaterThan = 0x400,
        Concatenate = 0x800,
        Add = 0x1000,
        Subtract = 0x2000,
        Multiply = 0x4000,
        Divide = 0x8000,
        Modulo = 0x10000,
        Positive = 0x20000,
        Negative = 0x40000,
        Not = 0x80000,
        Dot = 0x100000,

        All = 0xfffff,
        Unary = Positive | Negative | Not,
        Binary = All & ~Unary,
        Equality = EqualTo | NotEqualTo,
        Relational = LessThan | NotLessThan | GreaterThan | NotGreaterThan,
        Chains = Equality | Relational,
        Logical = And | Or | Xor | Chains | Not,
        Associative = Comma | And | Or | Xor | Chains | Concatenate | Add | Multiply,
        LeftAssociative = Subtract | Divide | Modulo,
        RightAssociative = None,
        NonAssociative = ~(Associative | LeftAssociative | RightAssociative),
        Visible = ~Dot, // Also excludes "None".
    }
}
