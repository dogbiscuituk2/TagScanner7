namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FastColoredTextBoxNS;

    public class Tokenizer
    {
        private int Count { get; set; }
        private string Head { get; set; }
        private int Index { get; set; }
        private string Text { get; set; }
        private Token Token { get; set; }

        #region Public Methods

        /// <summary>
        /// Convert a string into a sequence of Token objects.
        /// This method never throws an exception. In the case of any error, it will output a Token object with
        /// TokenType of 0 ("None") and a suitable Error message attached (e.g., "Unexpected character", or
        /// "Unterminated comment"), letting the iteration continue to completion.
        /// </summary>
        /// <param name="text">The string to tokenize.</param>
        /// <returns>An IEnumerable sequence of Token objects.</returns>
        public IEnumerable<Token> GetTokens(string text)
        {
            Text = text;
            Count = Text?.Length ?? 0;
            Index = 0;
            while (true)
            {
                while (Index < Count && Text[Index] <= Space)
                    Index++;
                if (Index >= Count)
                    break;
                ReadToken();
                if (Token.Length == 0)
                    Token = UnexpectedCharacter();
                if (string.IsNullOrWhiteSpace(Token.Value))
                    break;
                Index += Token.Length;
#if DEBUG_TOKENIZER
                System.Diagnostics.Debug.WriteLine(token);
#endif
                yield return Token;
            }
            yield break;
        }

        private void ReadToken()
        {
            Token = null;
            Head = Text.Substring(Index);
            if (MatchComment()
                || MatchNumber()
                || MatchName(TokenKind.Boolean, Term.Booleans)
                || MatchName(TokenKind.Field, Tags.FieldNames)
                || MatchName(TokenKind.Function, Functors.FunctionNames)
                || MatchName(TokenKind.Symbol, Operators.Symbols)
                || MatchName(TokenKind.TypeName, Types.Names)
                || MatchName(TokenKind.Keyword, ControlStructure.Keywords)
                || MatchRegex(TokenKind.Character, SingleQuote, @"^'(.|\.|\n)'", "Unterminated character constant")
                || MatchRegex(TokenKind.String, DoubleQuote, "\"[^\"|\\\"]*\"", "Unterminated string constant")
                ) return;
            /*if (Head[0] == LeftBracket)
            {
                var ok = MatchRegex(TokenKind.DateTime, LeftBracket, DateTimeParser.DateTimePattern);
                if (ok && Token.Valid)
                    return;
                ok = MatchRegex(TokenKind.TimeSpan, LeftBracket, DateTimeParser.TimeSpanPattern, "Invalid Date/Time format");
                if (ok)
                    return;
            }*/

            switch (Index < Count ? Text[Index] : Nul)
            {
                case LeftBracket:
                    MatchDateTime();
                    if (!Token.Valid)
                        MatchTimeSpan();
                    break;
                case LeftBrace:
                    MatchParameter();
                    break;
                case char c when char.IsLetter(c) || c == '_':
                    if (StartsWithLabel(Head))
                    {
                        MatchLabel();
                        break;
                    }
                    else if (StartsWithExceptionType(Head))
                    {
                        MatchExceptionType();
                        break;
                    }
                    else
                        MatchVariable();
                    break;
            }
            if (Token == null)
                Token = UnexpectedCharacter();
            return;
        }


        private void MatchDateTime() => MatchRegex(TokenKind.DateTime, LeftBracket, DateTimeParser.DateTimePattern, "Invalid DateTime format");
        private void MatchTimeSpan() => MatchRegex(TokenKind.TimeSpan, LeftBracket, DateTimeParser.TimeSpanPattern, "Invalid TimeSpan format");


        private bool MatchRegex(TokenKind tokenKind, char key, string pattern, string error = null)
        {
            var ok = Head[0] == key;
            if (ok)
            {
                Token = new Token(tokenKind, Index, Regex.Match(Head, $"^{pattern}", RegexOptions.IgnoreCase).Value);
                if (Token.Length < 1)
                {
                    Token.Value = Head.Substring(0, 1);
                    Token.Error = error;
                }
                return ok;
            }
            return ok;
        }

        private bool MatchComment()
        {
            bool
                single = Head.StartsWith("//"),
                multi = Head.StartsWith("/*");
            if (!(single || multi))
                return false;
            var length = multi ? Head.IndexOf("*/", 2) + 2 : $"{Head}\n".IndexOf("\n");
            string error = null;
            if (multi && length < 4)
            {
                length = Head.Length;
                error = "Unterminated comment";
            }
            Token = new Token(TokenKind.Comment, Index, Head.Substring(0, length), error);
            return true;
        }

        private bool MatchName(TokenKind tokenType, IEnumerable<string> names)
        {
            var value = names
                .OrderByDescending(p => p.Length)
                .FirstOrDefault(p => Head.StartsWith(p, caseSensitive: false));
            var ok = !string.IsNullOrWhiteSpace(value);
            if (ok)
                Token = new Token(tokenType, Index, value);
            return ok;
        }

        private bool MatchNumber() => MatchRegex3(TokenKind.Number, PatternNumber);

        private bool MatchRegex3(TokenKind tokenKind, string pattern)
        {
            var match = Regex.Match(Head, pattern, RegexOptions.IgnoreCase);
            var ok = match.Success;
            if (ok)
                Token = new Token(tokenKind, Index, match.Value);
            return ok;
        }

        private void MatchExceptionType() => MatchRegex2(TokenKind.TypeName, PatternExceptionType);
        private void MatchLabel() => MatchRegex2(TokenKind.Label, PatternLabel);
        private void MatchParameter() => MatchRegex2(TokenKind.Default, @"^\{\w+(\[\])?\}", "Invalid parameter");
        private void MatchVariable() => MatchRegex2(TokenKind.Variable, PatternName);

        private void MatchRegex2(TokenKind tokenType, string pattern, string error = null)
        {
            Token = new Token(tokenType, Index, Regex.Match(Head, $"^{pattern}", RegexOptions.IgnoreCase).Value);
            if (Token.Length < 1)
            {
                Token.Value = Head.Substring(0, 1);
                Token.Error = error;
            }
        }

        private Token UnexpectedCharacter() => new Token(0, Index, $"{Text[Index]}") { Error = "Unexpected character" };

        public static bool StartsWithExceptionType(string token) => Regex.IsMatch(token, PatternExceptionType);
        public static bool StartsWithLabel(string token) => Regex.IsMatch(token, PatternLabel);
        public static TextStyle TextStyle(TokenKind tokenType) => TextStyles[tokenType];

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

        private const string PatternExceptionType = @"^[\w_]+Exception";
        private const string PatternLabel = @"^[\w_]+\:";
        private const string PatternName = @"^[\w_]+";
        private const string PatternNumber = @"^\d+\.?\d*([Ee][-+]\d+)?(UL|LU|D|F|L|M|U)?";

        #endregion
    }
}
