namespace TagScanner.Terms
{
    public abstract class ControlStructure : Compound
    {
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
