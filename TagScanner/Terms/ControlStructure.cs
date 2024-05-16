namespace TagScanner.Terms
{
    public abstract class ControlStructure : Compound
    {
        protected ControlStructure(params Term[] operands) : base(operands) { }

        public static string[] Keywords = new[]
        {
            "break",
            "continue",
            "do",
            "else",
            "endif",
            "if",
            "loop",
            "then",
            "until",
            "while",
        };
    }
}
