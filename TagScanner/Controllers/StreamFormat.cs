namespace TagScanner.Controllers
{
    using System;

    [Flags]
    public enum StreamFormat
    {
        None = 0,
        Binary = 1,
        Xml = 2,
        Json = 4,
    }
}
