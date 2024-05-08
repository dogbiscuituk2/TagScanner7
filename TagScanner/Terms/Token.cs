﻿namespace TagScanner.Terms
{
    public class Token
    {
        public Token(TokenType tokenType, int index, string value)
        {
            TokenType = tokenType;
            StartIndex = index;
            Value = value;
        }

        public int EndIndex => StartIndex + Length;
        public string Error { get; set; }
        public int StartIndex { get; set; }
        public int Length => Value?.Length ?? 0;
        public TokenType TokenType { get; set; }
        public bool Valid => Error == null;
        public string Value { get; set; }

        public override string ToString() => Value;
    }
}
