namespace TagScanner.Terms.Parsing
{
    using System;

    public class ParserException : Exception
    {
        public ParserException(string message, Exception innerException, Token token)
            : this(message, innerException, token, token.Start) { }

        public ParserException(string message, Exception innerException, Token token, int index)
            : base(message, innerException)
        {
            Token = token;
            Index = index;
        }

        public Token Token { get; private set; }
        public int Index { get; private set; }
    }
}
