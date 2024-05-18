namespace TagScanner.Terms
{
    public abstract class ControlStructure : Compound
    {
        protected ControlStructure(params Term[] operands) : base(operands) { }

        public static string[] Keywords = new[]
        {
            "break",
            "catch",
            "continue",
            "do",
            "else",
            "end",
            "finally",
            "goto",
            "if",
            "then",
            "throw",
            "try",
            "until",
            "while",
        };
    }
}
