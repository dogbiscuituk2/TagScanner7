namespace TagScanner.Core
{
    using System.Text.RegularExpressions;

    public static class CharCaseUtils
    {
        public static CharCase GetCase(this string input)
        {
            if (input.IsCase(CharCase.Camel)) return CharCase.Camel;
            if (input.IsCase(CharCase.Pascal)) return CharCase.Pascal;
            if (input.IsCase(CharCase.Lower)) return CharCase.Lower;
            if (input.IsCase(CharCase.Upper)) return CharCase.Upper;
            return 0;
        }

        public static string GetRegexPattern(this CharCase charCase)
        {
            switch (charCase)
            {
                case CharCase.Lower: return @"^[\P{Lu}]*$"; // Contains no uppercase letters.
                case CharCase.Upper: return @"^[\P{Ll}]*$"; // Contains no lowercase letters.
                case CharCase.Camel: return @"^[\P{Lu}]*[\p{Ll}].*[\p{Lu}].*"; // First letter is lowercase, but contains also uppercase letter(s).
                case CharCase.Pascal: return @"^[\P{Ll}]*[\p{Lu}].*[\p{Ll}].*"; // First letter is uppercase, but contains also lowercase letter(s).
                default: return ".*"; // Anything else.
            }
        }

        public static bool IsCase(this string input, CharCase charCase) => Regex.IsMatch(input, charCase.GetRegexPattern());

        /// <summary>
        /// Apply the character casing of a sample string to an output string.
        /// </summary>
        /// <param name="sample">The sample string.</param>
        /// <param name="output">The output string.</param>
        /// <returns>The output string, possibly modified to match the character casing of the provided sample string.</returns>
        public static string PreserveCase(this string sample, string output)
        {
            CharCase
                from = sample.GetCase(),
                to = output.GetCase();
            if (to == from // Casings already match.
                || to == CharCase.Lower && from != CharCase.Upper // No case data in output string.
                || to == CharCase.Upper && from != CharCase.Lower //
                ) return output;
            if (from == CharCase.Lower) return output.ToLowerInvariant();
            if (from == CharCase.Upper) return output.ToUpperInvariant();
            // Otherwise, just invert the case of the first output letter to convert between caMel & PasCal.
            var s = Regex.Match(output, @"^([\P{L}]*)([\p{L}])(.*)").Groups;
            return $"{s[1].Value}{s[2].Value[0].ToggleCase()}{s[3].Value}";
        }

        public static char ToggleCase(this char c) => char.IsLower(c) ? char.ToUpperInvariant(c) : char.ToLowerInvariant(c);
    }
}
