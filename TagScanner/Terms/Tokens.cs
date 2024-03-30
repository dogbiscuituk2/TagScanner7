namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Utils;

    public static class Tokens
    {
        #region Public Methods

        public static IEnumerable<string> GetTokens(string text)
        {
            int count = text.Length, index = 0;
            while (true)
            {
                var token = ReadToken();
                if (string.IsNullOrWhiteSpace(token))
                    break;
                System.Diagnostics.Debug.WriteLine(token);
                yield return token;
            }
            yield break;

            string MatchCharacter() => MatchRegex(@"^'.'");
            string MatchDateTime() => MatchRegex(Parser.DateTimePattern);
            string MatchNumber() => MatchRegex(@"^(\d+\.?\d*(UL|LU|D|F|L|M|U)?)", RegexOptions.IgnoreCase);
            string MatchRegex(string pattern, RegexOptions options = RegexOptions.None) => Regex.Match(text.Substring(index), pattern, options).Value;

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

            string MatchTimeSpan() => MatchRegex(Parser.TimeSpanPattern);

            string ReadToken()
            {
                var token = PeekToken();
                index += token.Length;
                return token;

                string PeekToken()
                {
                    while (index < count && text[index] <= ' ')
                        index++;
                    var result = AllTokens.FirstOrDefault(p => text.Substring(index).StartsWith(p));
                    if (!string.IsNullOrWhiteSpace(result))
                        return result;
                    switch (index < count ? text[index] : Nul)
                    {
                        case SingleQuote:
                            return MatchCharacter();
                        case DoubleQuote:
                            return MatchString();
                        case char digit when char.IsDigit(digit):
                            return MatchNumber();
                        case LeftBracket:
                            var dateTime = MatchDateTime();
                            return !string.IsNullOrWhiteSpace(dateTime) ? dateTime : MatchTimeSpan();
                        case Nul:
                            return string.Empty;
                    }
                    throw new FormatException($"Unexpected character in input '{text}' at position {index}.");
                }
            }
        }

        public static bool IsBoolean(this string token) => Booleans.Contains(token);
        public static bool IsChar(this string token) => token[0] == SingleQuote;
        public static bool IsConstant(this string token) => token.IsBoolean() || token.IsChar() || token.IsNumber() || token.IsString();
        public static bool IsDateTime(this string token) => Regex.IsMatch(token, Parser.DateTimePattern);
        public static bool IsDyadicOperator(this string token) => DyadicOperators.Contains(token);
        public static bool IsField(this string token) => Fields.Contains(token);
        public static bool IsFunction(this string token) => Functions.Contains(token);
        public static bool IsMemberFunction(this string token) => MemberFunctions.Contains(token);
        public static bool IsMonadicOperator(this string token) => MonadicOperators.Contains(token);
        public static bool IsNumber(this string token) => char.IsDigit(token[0]);
        public static bool IsOperator(this string token) => Operators.Contains(token);
        public static bool IsStaticFunction(this string token) => StaticFunctions.Contains(token);
        public static bool IsString(this string token) => token[0] == DoubleQuote;
        public static bool IsSymbol(this string token) => Symbols.Contains(token);
        public static bool IsTimeSpan(this string token) => Regex.IsMatch(token, Parser.TimeSpanPattern);
        public static bool IsTriadicOperator(this string token) => TriadicOperators.Contains(token);
        public static bool IsType(this string token) => Types.Contains(token);

        public static Rank Rank(this string token) => token.Operator().GetRank();

        public static Op Operator(this string token)
        {
            switch (token)
            {
                case ",": return Op.Comma;
                case "?": goto case ":";
                case ":": return Op.Conditional;
                case "&": return Op.And;
                case "|": return Op.Or;
                case "^": return Op.Xor;
                case "=": return Op.EqualTo;
                case "!=": return Op.NotEqualTo;
                case "<": return Op.LessThan;
                case ">=": return Op.NotLessThan;
                case ">": return Op.GreaterThan;
                case "<=": return Op.NotGreaterThan;
                case "+": return Op.Add;
                case "-": return Op.Subtract;
                case "*": return Op.Multiply;
                case "/": return Op.Divide;
                case ".": return Op.Dot;
            }
            throw new FormatException();
         }

        #endregion

        #region Private Fields

        private const char
            Nul = (char)0,
            SingleQuote = '\'',
            DoubleQuote = '"',
            LeftBracket = '[';

        /// <summary>
        /// Names are ordered descending to that, for example, "Album Artists" is matched before "Artists".
        /// If these were sorted in ascending or other order, "Album Artists" might never be matched.
        /// </summary>
        private static readonly string[] AllTokens = Booleans.Union(Fields).Union(Functions).Union(Symbols).Union(Types).OrderByDescending(p => p).ToArray();

        #endregion

        #region Private Properties

        private static IEnumerable<string> Booleans => new[] { "false", "true" };
        private static IEnumerable<string> DyadicOperators => new[] { "&", "|", "^", "=", "!=", "<", ">=", ">", "<=", "+", "-", "*", "/", "." };
        private static IEnumerable<string> Fields => Tags.Keys.Select(p => p.DisplayName());
        private static IEnumerable<string> Functions => Methods.Keys;
        private static IEnumerable<string> MemberFunctions => Methods.Keys.Where(p => !p.IsStatic());
        private static IEnumerable<string> MonadicOperators => new[] { "+", "-", "!" };
        private static IEnumerable<string> Operators => MonadicOperators.Union(DyadicOperators).Union(TriadicOperators);
        private static IEnumerable<string> StaticFunctions => Methods.Keys.Where(p => p.IsStatic());
        private static IEnumerable<string> Symbols => Operators.Union(new[] { "(", ")", ",", "." });
        private static IEnumerable<string> TriadicOperators => new[] { "?", ":" };
        private static IEnumerable<string> Types => Cast.Types.Select(p => p.Say());

        #endregion
    }
}
