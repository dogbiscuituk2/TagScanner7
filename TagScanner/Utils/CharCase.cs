namespace TagScanner.Utils
{
    using System;

    [Flags]
    public enum CharCase
    {
        lower = 1,
        UPPER = 2,
        caMel = 4,
        PasCal = 8,
    }
}
