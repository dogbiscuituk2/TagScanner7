namespace TagScanner.Terms
{
    using System;

    public class SilentException : Exception
    {
        public SilentException() : base() { }
        public SilentException(string message) : base(message) { }
    }
}
