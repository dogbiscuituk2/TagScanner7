namespace TagScanner.Terms
{
    using System;

    public class ParserException : Exception
    {
        public ParserException(string message, Exception innerException, int index) : base(message, innerException) { Index = index; }

        public int Index { get; private set; }
    }
}
