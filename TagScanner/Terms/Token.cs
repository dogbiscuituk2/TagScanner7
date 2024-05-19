namespace TagScanner.Terms
{
    public class Token
    {
        #region Constructor

        public Token(TokenKind kind, int index, string value, string error = null)
        {
            Kind = kind;
            Start = index;
            Value = value;
            Error = error;
        }

        #endregion

        #region Fields & Properties

        public int End => Start + Length;
        public string Error { get; set; }
        public string Key => Value.ToUpperInvariant();
        public TokenKind Kind { get; set; }
        public int Length => Value?.Length ?? 0;
        public int Start { get; set; }
        public bool Valid => Error == null;
        public string Value { get; set; }

        #endregion

        #region Methods

        public override string ToString() => Value;

        #endregion
    }
}
