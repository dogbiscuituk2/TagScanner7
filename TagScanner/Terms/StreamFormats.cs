namespace TagScanner.Terms
{
    using System;

    [Flags]
    public enum StreamFormats
    {
        None = 0,
        Binary = 1,
        Json = 2,
        Xml = 4,
    }
}
