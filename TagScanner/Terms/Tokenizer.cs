namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FastColoredTextBoxNS;
    using Utils;

    public static class Tokenizer
    {
        #region Public Methods

        /// <summary>
        /// Convert a string into a sequence of Token objects.
        /// This method never throws an exception. In the case of any error, it will output a Token object with
        /// TokenType of 0 ("None") and a suitable Error message attached (e.g., "Unexpected character", or
        /// "Unterminated comment"), letting the iteration continue to completion.
        /// </summary>
        /// <param name="text">The string to tokenize.</param>
        /// <returns>An IEnumerable sequence of Token objects.</returns>
        public static IEnumerable<Token> GetTokens(string text)
        {
            int count = text?.Length ?? 0, index = 0;
            while (true)
            {
                while (index < count && text[index] <= Space)
                    index++;
                if (index >= count)
                    break;
                var token = Match();
                if (token.Length == 0)
                    token = UnexpectedCharacter();
                if (string.IsNullOrWhiteSpace(token.Value))
                    break;
                index += token.Length;
#if DEBUG_TOKENIZER
                System.Diagnostics.Debug.WriteLine(token);
#endif
                yield return token;
            }
            yield break;

            Token UnexpectedCharacter() => new Token(0, index, $"{text[index]}") { Error = "Unexpected character" };

            Token Match()
            {
                var remainingText = RemainingText();

                if (remainingText.IsComment()) return MatchComment();
                if (remainingText.StartsWithNumber()) return MatchNumber();

                Token token = null;
                if (MatchKeyword(ref token, TokenKind.Boolean, Term.Booleans)) return token;
                if (MatchKeyword(ref token, TokenKind.Field, Tags.FieldNames)) return token;
                if (MatchKeyword(ref token, TokenKind.Function, Functors.FunctionNames)) return token;
                if (MatchKeyword(ref token, TokenKind.Symbol, Operators.Symbols)) return token;
                if (MatchKeyword(ref token, TokenKind.TypeName, Types.Names)) return token;

                switch (index < count ? text[index] : Nul)
                {
                    case SingleQuote:
                        return MatchCharacter();
                    case DoubleQuote:
                        return MatchString();
                    case LeftBracket:
                        var dateTime = MatchDateTime();
                        return dateTime.Valid ? dateTime : MatchTimeSpan();
                    case LeftBrace:
                        return MatchParameter();
                    case char c when char.IsLetter(c) || c == '_':
                        return MatchVariable();
                }
                return UnexpectedCharacter();
            }

            Token MatchCharacter() => MatchRegex(TokenKind.Character, @"^'(.|\.|\n)'", "Unterminated character constant");
            Token MatchDateTime() => MatchRegex(TokenKind.DateTime, DateTimeParser.DateTimePattern, "Invalid DateTime format");
            Token MatchNumber() => MatchRegex(TokenKind.Number, NumberPattern, "Always succeeds");
            Token MatchParameter() => MatchRegex(TokenKind.Default, @"^\{\w+(\[\])?\}", "Invalid parameter");
            Token MatchString() => MatchRegex(TokenKind.String, "\"[^\"|\\\"]*\"", "Unterminated string constant");
            Token MatchTimeSpan() => MatchRegex(TokenKind.TimeSpan, DateTimeParser.TimeSpanPattern, "Invalid TimeSpan format");
            Token MatchVariable() => MatchRegex(TokenKind.Variable, @"[\w]+", "Always succeeds");

            Token MatchComment()
            {
                var remainingText = RemainingText();
                var token = new Token(
                    TokenKind.Comment,
                    index,
                    remainingText.Substring(0,
                    remainingText.StartsWith("/*")
                    ? remainingText.IndexOf("*/") + 2
                    : $"{remainingText}\n".IndexOf("\n")));
                if (token.Length < 2)
                {
                    token.Value = remainingText.Split(Space, Tab, CR, LF)[0];
                    token.Error = "Unterminated comment";
                }
                return token;
            }

            bool MatchKeyword(ref Token token, TokenKind tokenType, IEnumerable<string> keywords)
            {
                var remainingText = RemainingText();
                var value = keywords
                    .OrderByDescending(p => p).
                    FirstOrDefault(p => remainingText.StartsWith(p, StringComparison.OrdinalIgnoreCase));
                var ok = !string.IsNullOrWhiteSpace(value);
                if (ok)
                    token = new Token(tokenType, index, value);
                return ok;
            }

            Token MatchRegex(TokenKind tokenType, string pattern, string error)
            {
                var token = new Token(tokenType, index,
                    Regex.Match(RemainingText(), $"^{pattern}", RegexOptions.IgnoreCase).Value);
                if (token.Length < 1)
                {
                    token.Value = RemainingText().Substring(0, 1);
                    token.Error = error;
                }
                return token;
            }

            string RemainingText() => text.Substring(index);
        }

        public static bool IsBinaryOperator(this string token) => Operators.ContainsBinarySymbol(token);
        public static bool IsBoolean(this string token) => Term.Booleans.Contains(token, IgnoreCase);
        public static bool IsChar(this string token) => token[0] == SingleQuote;
        public static bool IsConstant(this string token) => token.IsBoolean() || token.IsNumber() || token.IsString();
        public static bool IsDateTime(this string token) => Regex.IsMatch(token, DateTimeParser.DateTimePattern);
        public static bool IsDefault(this string token) => token[0] == LeftBrace;
        public static bool IsField(this string token) => Tags.FieldNames.Contains(token, IgnoreCase);
        public static bool IsFunction(this string token) => Functors.FunctionNames.Contains(token, IgnoreCase);
        public static bool IsName(this string token) => Regex.IsMatch(token, $"{NamePattern}$");
        public static bool IsNumber(this string token) => Regex.IsMatch(token, $"{NumberPattern}$");
        public static bool IsOperator(this string token) => Operators.ContainsSymbol(token);
        public static bool IsString(this string token) => token[0] == DoubleQuote;
        public static bool IsSymbol(this string token) => Operators.Symbols.Contains(token, IgnoreCase);
        public static bool IsTimeSpan(this string token) => Regex.IsMatch(token, DateTimeParser.TimeSpanPattern);
        public static bool IsType(this string token) => Types.Names.Contains(token, IgnoreCase);
        public static bool IsUnaryOperator(this string token) => Operators.ContainsUnarySymbol(token);
        public static Rank Rank(this string token, bool unary) => token.ToOperator(unary).GetRank();
        public static bool StartsWithNumber(this string token) => Regex.IsMatch(token, NumberPattern);
        public static TextStyle TextStyle(this TokenKind tokenType) => TextStyles[tokenType];

        private const string NamePattern = @"\w+";
        private const string NumberPattern = @"^\d+\.?\d*([Ee][-+]\d+)?(UL|LU|D|F|L|M|U)?";

        private static readonly TextStyle TextStyleConstant = new TextStyle(Brushes.DarkOrange, null, FontStyle.Regular);

        private static readonly Dictionary<TokenKind, TextStyle> TextStyles = new Dictionary<TokenKind, TextStyle>
        {
            { TokenKind.None, new TextStyle(Brushes.White, Brushes.OrangeRed, FontStyle.Regular) },
            { TokenKind.Boolean, TextStyleConstant },
            { TokenKind.Character, TextStyleConstant },
            { TokenKind.Comment, new TextStyle(Brushes.Green, null, FontStyle.Regular) },
            { TokenKind.DateTime, TextStyleConstant },
            { TokenKind.Field, new TextStyle(Brushes.Blue, null, FontStyle.Regular) },
            { TokenKind.Function, new TextStyle(Brushes.DarkCyan, null, FontStyle.Regular) },
            { TokenKind.Number, TextStyleConstant },
            { TokenKind.Default, new TextStyle(Brushes.Brown, null, FontStyle.Regular) },
            { TokenKind.String, TextStyleConstant },
            { TokenKind.Symbol, new TextStyle(Brushes.Black, null, FontStyle.Regular) },
            { TokenKind.TimeSpan, TextStyleConstant },
            { TokenKind.TypeName, new TextStyle(Brushes.Red, null, FontStyle.Regular) },
            { TokenKind.Variable, new TextStyle(Brushes.Magenta, null, FontStyle.Regular) },
        };

        public static TextStyle[] AllTextStyles = TextStyles.Values.Distinct().ToArray();

        #endregion

        #region Private Fields

        private const char
            Nul = (char)0,
            Tab = '\t',
            CR = '\r',
            LF = '\n',
            Space = ' ',
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

        private static EqualityComparer IgnoreCase = new EqualityComparer(caseSensitive: false);

        #endregion
    }
}
