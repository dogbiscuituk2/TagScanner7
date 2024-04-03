namespace TagScanner.Controllers
{
    using System;

    [Flags]
    public enum StreamFormat
    {
        None = 0,
        Binary = 1,
        Json = 2,
        Xml = 4,
    }
}
