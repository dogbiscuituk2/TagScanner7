namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Tokenizer
    {
        #region Public Properties

        public static EqualityComparer IgnoreCase = new EqualityComparer(caseSensitive: false);

        #endregion

        #region Public Methods

        public static IEnumerable<Token> GetTokens(string text)
        {
            int count = text.Length, index = 0;
            while (true)
            {
                while (index < count && text[index] <= ' ')
                    index++;
                if (index >= count)
                    break;
                var match = Match();
                if (string.IsNullOrWhiteSpace(match))
                    break;
                var token = new Token(index, match);
                index += match.Length;
#if DEBUG_TOKENIZER
                System.Diagnostics.Debug.WriteLine(token);
#endif
                yield return token;
            }
            if (index < count)
                SyntaxError();
            yield break;

            string Match()
            {
                var remainingText = RemainingText();
                if (remainingText.StartsWithNumber())
                    return MatchNumber();

                var result = AllTokens.FirstOrDefault(p => remainingText.StartsWith(p, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrWhiteSpace(result))
                    return result;
                switch (index < count ? text[index] : Nul)
                {
                    case SingleQuote:
                        return MatchCharacter();
                    case DoubleQuote:
                        return MatchString();
                    case LeftBracket:
                        var dateTime = MatchDateTime();
                        return !string.IsNullOrWhiteSpace(dateTime) ? dateTime : MatchTimeSpan();
                    case LeftBrace:
                        return MatchParameter();
                    case Nul:
                        return string.Empty;
                }
                SyntaxError();
                return string.Empty;
            }

            string MatchCharacter() => MatchRegex(@"^'.'");
            string MatchDateTime() => MatchRegex(DateTimeParser.DateTimePattern);
            string MatchNumber() => MatchRegex(NumberPattern);
            string MatchParameter() => MatchRegex(@"^\{\w+(\[\])?\}");
            string MatchTimeSpan() => MatchRegex(DateTimeParser.TimeSpanPattern);

            string MatchRegex(string pattern, RegexOptions options = RegexOptions.IgnoreCase) =>
                Regex.Match(RemainingText(), pattern, options).Value;

            string MatchString()
            {
                var p = index;
                while (p >= 0)
                {
                    p = text.IndexOf('"', p + 1);
                    if (p > 0 && text[p - 1] != '\\')
                        return text.Substring(index, p - index + 1);
                }
                return string.Empty;
            }

            string RemainingText() => text.Substring(index);
            void SyntaxError() => throw new FormatException($"Unrecognised term at character position {index}: {RemainingText()}");
        }

        public static bool IsBinaryOperator(this string token) => BinaryOperators.Contains(token, IgnoreCase);
        public static bool IsBoolean(this string token) => Booleans.Contains(token, IgnoreCase);
        public static bool IsConstant(this string token) => token.IsBoolean() || token.IsNumber() || token.IsString();
        public static bool IsDateTime(this string token) => Regex.IsMatch(token, DateTimeParser.DateTimePattern);
        public static bool IsDyadicOperator(this string token) => BinaryOperators.Contains(token);
        public static bool IsField(this string token) => Fields.Contains(token, IgnoreCase);
        public static bool IsFunction(this string token) => FunctionNames.Contains(token, IgnoreCase);
        public static bool IsMemberFunction(this string token) => MemberFunctionNames.Contains(token, IgnoreCase);
        public static bool IsMonadicOperator(this string token) => UnaryOperators.Contains(token, IgnoreCase);
        public static bool IsNumber(this string token) => Regex.IsMatch(token, $"{NumberPattern}$");
        public static bool IsOperator(this string token) => Operators.Contains(token, IgnoreCase);
        public static bool IsParameter(this string token) => token[0] == '{';
        public static bool IsStaticFunction(this string token) => StaticFunctionNames.Contains(token, IgnoreCase);
        public static bool IsString(this string token) => token[0] == DoubleQuote;
        public static bool IsSymbol(this string token) => Symbols.Contains(token, IgnoreCase);
        public static bool IsTimeSpan(this string token) => Regex.IsMatch(token, DateTimeParser.TimeSpanPattern);
        public static bool IsType(this string token) => TypeNames.Contains(token, IgnoreCase);
        public static bool IsUnaryOperator(this string token) => UnaryOperators.Contains(token, IgnoreCase);
        public static Rank Rank(this string token, bool unary) => token.ToOperator(unary).GetRank();
        public static bool StartsWithNumber(this string token) => Regex.IsMatch(token, NumberPattern);

        private const string NumberPattern = @"^[-+]?(\d+\.?\d*(UL|LU|D|F|L|M|U)?)";

        #endregion

        #region Private Fields

        private const char
            Nul = (char)0,
            SingleQuote = '\'',
            DoubleQuote = '"',
            LeftAngle = '<',
            LeftBrace = '{',
            LeftBracket = '[',
            LeftParen = '(',
            RightAngle = '>',
            RightBrace = '}',
            RightBracket = ']',
            RightParen = ')';

        /// <summary>
        /// Names are ordered descending to that, for example, "Album Artists" is matched before "Artists".
        /// If these were sorted in ascending or other order, "Album Artists" might never be matched.
        /// </summary>
        private static readonly string[] AllTokens = Booleans.Union(Fields).Union(FunctionNames).Union(Symbols).Union(TypeNames).OrderByDescending(p => p).ToArray();

        #endregion

        #region Private Properties

        private static IEnumerable<string> Booleans => new[] { "false", "true" };
        private static IEnumerable<string> Fields => Tags.Keys.Select(p => p.DisplayName());
        private static IEnumerable<string> FunctionNames => Functors.Keys.Select(fn => $"{fn}");
        private static IEnumerable<string> LogicalNot => new[] { "!", "not" };
        private static IEnumerable<string> MemberFunctionNames => Functors.Keys.Where(p => !p.IsStatic()).Select(p => $"{p}");
        private static IEnumerable<string> Operators => UnaryOperators.Union(BinaryOperators);
        private static IEnumerable<string> StaticFunctionNames => Functors.Keys.Where(p => p.IsStatic()).Select(p => $"{p}");
        private static IEnumerable<string> Symbols => Operators.Union(new[] { "(", ")" });
        private static IEnumerable<string> TypeNames => Types.TypeNames;
        private static IEnumerable<string> UnaryMinus => new[] { "-", "－" };
        private static IEnumerable<string> UnaryOperators => UnaryPlus.Union(UnaryMinus).Union(LogicalNot);
        private static IEnumerable<string> UnaryPlus => new[] { "+", "＋" };

        private static IEnumerable<string> BinaryOperators => new[]
        {
            ",",
            "&&", "&", "and",
            "||", "|", "or",
            "^", "xor",
            "==", "=",
            "!=", "<>", "≠",
            "<",
            ">",
            "<=", "≤", "≯",
            ">=", "≥", "≮",
            "+", "＋",
            "-", "－",
            "*", "×", "✕",
            "/", "÷", "／",
            "%",
            "."
        };

        #endregion
    }
}
