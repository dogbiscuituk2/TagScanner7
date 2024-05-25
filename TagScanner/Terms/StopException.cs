namespace TagScanner.Terms
{
    using System;

    public class StopException : Exception
    {
        public StopException() : base() { }
        public StopException(string message) : base(message) { }
    }
}
