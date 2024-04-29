namespace TagScanner.Terms
{
    using System;

    [Flags]
    public enum Associativity
    {
        None = 0,
        Left = 1,
        Right = 2,
        Full = Left | Right,
    }
}
