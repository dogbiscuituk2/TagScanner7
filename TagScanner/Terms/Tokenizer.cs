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
                Token token = null;
                var head = RemainingText();
                if (MatchComment()
                    || MatchNumber()
                    || MatchName(TokenKind.Boolean, Term.Booleans)
                    || MatchName(TokenKind.Field, Tags.FieldNames)
                    || MatchName(TokenKind.Function, Functors.FunctionNames)
                    || MatchName(TokenKind.Symbol, Operators.Symbols)
                    || MatchName(TokenKind.TypeName, Types.Names)
                    || MatchName(TokenKind.Keyword, ControlStructure.Keywords))
                    return token;

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
                        return 
                            head.StartsWithLabel()
                            ? MatchLabel()
                            : head.StartsWithExceptionType()
                            ? MatchExceptionType()
                            : MatchVariable();
                }
                return UnexpectedCharacter();

                bool MatchComment()
                {
                    bool
                        single = head.StartsWith("//"),
                        multi = head.StartsWith("/*");
                    if (!(single || multi))
                        return false;
                    var length = multi ? head.IndexOf("*/", 2) + 2 : $"{head}\n".IndexOf("\n");
                    string error = null;
                    if (multi && length < 4)
                    {
                        length = head.Length;
                        error = "Unterminated comment";
                    }
                    token = new Token(TokenKind.Comment, index, head.Substring(0, length), error);
                    return true;
                }

                bool MatchName(TokenKind tokenType, IEnumerable<string> names)
                {
                    var value = names
                        .OrderByDescending(p => p.Length)
                        .FirstOrDefault(p => head.StartsWith(p, caseSensitive: false));
                    var ok = !string.IsNullOrWhiteSpace(value);
                    if (ok)
                        token = new Token(tokenType, index, value);
                    return ok;
                }

                bool MatchNumber() => MatchRegex(TokenKind.Number, PatternNumber);

                bool MatchRegex(TokenKind tokenKind, string pattern)
                {
                    var match = Regex.Match(head, pattern, RegexOptions.IgnoreCase);
                    var ok = match.Success;
                    if (ok)
                        token = new Token(tokenKind, index, match.Value);
                    return ok;
                }
            }

            Token MatchCharacter() => MatchRegex2(TokenKind.Character, @"^'(.|\.|\n)'", "Unterminated character constant");
            Token MatchDateTime() => MatchRegex2(TokenKind.DateTime, DateTimeParser.DateTimePattern, "Invalid DateTime format");
            Token MatchExceptionType() => MatchRegex2(TokenKind.TypeName, PatternExceptionType);
            Token MatchLabel() => MatchRegex2(TokenKind.Label, PatternLabel);
            Token MatchParameter() => MatchRegex2(TokenKind.Default, @"^\{\w+(\[\])?\}", "Invalid parameter");
            Token MatchString() => MatchRegex2(TokenKind.String, "\"[^\"|\\\"]*\"", "Unterminated string constant");
            Token MatchTimeSpan() => MatchRegex2(TokenKind.TimeSpan, DateTimeParser.TimeSpanPattern, "Invalid TimeSpan format");
            Token MatchVariable() => MatchRegex2(TokenKind.Variable, PatternName);

            Token MatchRegex2(TokenKind tokenType, string pattern, string error = null)
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
        public static Rank Rank(this string token, bool unary) => token.ToOperator(unary).GetRank();
        public static bool StartsWithExceptionType(this string token) => Regex.IsMatch(token, PatternExceptionType);
        public static bool StartsWithLabel(this string token) => Regex.IsMatch(token, PatternLabel);
        public static bool StartsWithNumber(this string token) => Regex.IsMatch(token, PatternNumber);
        public static TextStyle TextStyle(this TokenKind tokenType) => TextStyles[tokenType];

        private const string PatternExceptionType = @"^[\w_]+Exception";
        private const string PatternLabel = @"^[\w_]+\:";
        private const string PatternName = @"^[\w_]+";
        private const string PatternNumber = @"^\d+\.?\d*([Ee][-+]\d+)?(UL|LU|D|F|L|M|U)?";

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
            { TokenKind.Keyword, new TextStyle(Brushes.DarkGray, null, FontStyle.Regular) },
            { TokenKind.Label, new TextStyle(Brushes.Magenta, null, FontStyle.Italic) },
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
