﻿namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Tokenizer
    {
        #region Public Properties

        public static EqualityComparer IgnoreCase = new EqualityComparer();

        #endregion

        #region Public Methods

        public static IEnumerable<Token> GetTokens(string text)
        {
            int count = text.Length, index = 0;
            while (true)
            {
                while (index < count && text[index] <= ' ')
                    index++;
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
                var result = AllTokens.FirstOrDefault(p => text.Substring(index).StartsWith(p, StringComparison.OrdinalIgnoreCase));
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
            string MatchNumber() => MatchRegex(@"^(\d+\.?\d*(UL|LU|D|F|L|M|U)?)");
            string MatchParameter() => MatchRegex(@"^\{\w+(\[\])?\}");
            string MatchTimeSpan() => MatchRegex(DateTimeParser.TimeSpanPattern);

            string MatchRegex(string pattern, RegexOptions options = RegexOptions.IgnoreCase) =>
                Regex.Match(text.Substring(index), pattern, options).Value;

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

            void SyntaxError() => throw new FormatException($"Unrecognised term at character position {index}: {text.Substring(index)}");
        }

        public static bool IsBoolean(this string token) => Booleans.Contains(token, IgnoreCase);
        public static bool IsChar(this string token) => token[0] == SingleQuote;
        public static bool IsConstant(this string token) => token.IsBoolean() || token.IsChar() || token.IsNumber() || token.IsString();
        public static bool IsDateTime(this string token) => Regex.IsMatch(token, DateTimeParser.DateTimePattern);
        public static bool IsDyadicOperator(this string token) => DyadicOperators.Contains(token);
        public static bool IsField(this string token) => Fields.Contains(token, IgnoreCase);
        public static bool IsFunction(this string token) => FunctionNames.Contains(token, IgnoreCase);
        public static bool IsMemberFunction(this string token) => MemberFunctionNames.Contains(token, IgnoreCase);
        public static bool IsMonadicOperator(this string token) => MonadicOperators.Contains(token, IgnoreCase);
        public static bool IsNumber(this string token) => char.IsDigit(token[0]);
        public static bool IsOperator(this string token) => Operators.Contains(token, IgnoreCase);
        public static bool IsParameter(this string token) => token[0] == '{';
        public static bool IsStaticFunction(this string token) => StaticFunctionNames.Contains(token, IgnoreCase);
        public static bool IsString(this string token) => token[0] == DoubleQuote;
        public static bool IsSymbol(this string token) => Symbols.Contains(token, IgnoreCase);
        public static bool IsTimeSpan(this string token) => Regex.IsMatch(token, DateTimeParser.TimeSpanPattern);
        public static bool IsType(this string token) => TypeNames.Contains(token, IgnoreCase);

        public static Rank Rank(this string token, bool unary) => token.ToOperator(unary).GetRank();

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

        private static IEnumerable<string> MonadicOperators => new[]
        {
            "+", "＋",
            "-", "－",
            "!", "not",
        };

        private static IEnumerable<string> DyadicOperators => new[]
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

        private static IEnumerable<string> Fields => Tags.Keys.Select(p => p.DisplayName());
        private static IEnumerable<string> FunctionNames => Functions.Keys.Select(fn => $"{fn}");
        private static IEnumerable<string> MemberFunctionNames => Functions.Keys.Where(p => !p.IsStatic()).Select(p => p.ToString());
        private static IEnumerable<string> Operators => MonadicOperators.Union(DyadicOperators);
        private static IEnumerable<string> StaticFunctionNames => Functions.Keys.Where(p => p.IsStatic()).Select(p => p.ToString());
        private static IEnumerable<string> Symbols => Operators.Union(new[] { "(", ")" });
        private static IEnumerable<string> TypeNames => Types.TypeNames;

        #endregion
    }
}
