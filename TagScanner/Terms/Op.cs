namespace TagScanner.Terms
{
    using System;

    [Flags]
    public enum Op
    {
        None = 0x00000,
        Comma = 0x00001,
        And = 0x00002,
        Or = 0x00004,
        Xor = 0x00008,
        EqualTo = 0x00010,
        NotEqualTo = 0x00020,
        LessThan = 0x00040,
        NotLessThan = 0x00080,
        GreaterThan = 0x00100,
        NotGreaterThan = 0x00200,
        Concatenate = 0x00400,
        Add = 0x00800,
        Subtract = 0x01000,
        Multiply = 0x02000,
        Divide = 0x04000,
        Modulo = 0x08000,
        Positive = 0x10000,
        Negative = 0x20000,
        Not = 0x40000,
        Dot = 0x80000,

        All = 0xfffff,
        Unary = Positive | Negative | Not,
        Binary = All & ~Unary,
        Equality = EqualTo | NotEqualTo,
        Relational = LessThan | NotLessThan | GreaterThan | NotGreaterThan,
        Chains = EqualTo | Relational,
        Logical = And | Or | Xor | Chains | Not,
        Associative = Comma | And | Or | Xor | Chains | Concatenate | Add | Multiply,
        LeftAssociative = Subtract | Divide | Modulo,
        RightAssociative = None,
        NonAssociative = ~(Associative | LeftAssociative | RightAssociative),
        ParamArray = Associative | LeftAssociative,
        Visible = ~Dot, // Also excludes "None".
    }
}
