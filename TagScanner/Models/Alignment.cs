namespace TagScanner.Models
{
    using System;

    [Flags]
    public enum Alignment
    {
        None = 0,
        Near = 1,
        Centre = 2,
        Far = 4,
        Default = 8,
    }
}
