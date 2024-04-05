namespace TagScanner.Terms
{
    public class Token
    {
        public Token(int index, string value)
        {
            Index = index;
            Value = value;
        }

        public int Index { get; set; }
        public string Value { get; set; }

        public override string ToString() => Value;
    }
}
