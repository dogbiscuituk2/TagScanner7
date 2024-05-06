namespace TagScanner.Terms
{
    public class Token
    {
        public Token(TokenType tokenType, int index, string value)
        {
            TokenType = tokenType;
            Index = index;
            Value = value;
        }

        public TokenType TokenType { get; set; }
        public int Index { get; set; }
        public string Value { get; set; }

        public int Length => Value?.Length ?? 0;

        public override string ToString() => Value;
    }
}
