namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FastColoredTextBoxNS;
    using Models;

    /// <summary>
    /// Lexical analyzer.
    /// </summary>
    public class Lexer
    {
        #region Public Properties

        public static List<string> AutocompleteItems => Term.Booleans
            .Union(Tags.FieldNames)
            .Union(Functors.FunctionNames)
            .Union(Types.Names)
            .Union(Keywords.All)
            .ToList();

        #endregion

        #region Public Methods

        /// <summary>
        /// Convert a string into a sequence of Token objects.
        /// This method never throws an exception. In the case of any error, it will output a Token object with
        /// TokenType of 0 ("None") and a suitable Error message attached (e.g., "Unexpected character", or
        /// "Unterminated comment"), letting the iteration continue to completion.
        /// </summary>
        /// <param name="text">The string to tokenize.</param>
        /// <returns>An IEnumerable sequence of Token objects.</returns>
        public static IEnumerable<Token> GetTokens(string text) => new Lexer().EnumerateTokens(text);

        #endregion

        #region Private Methods

        private IEnumerable<Token> EnumerateTokens(string text)
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
                Match();
                if (Token == null || Token.Length == 0)
                    Token = UnexpectedCharacter();
                if (string.IsNullOrWhiteSpace(Token.Value))
                    break;
                Index += Token.Length;
#if DEBUG_LEXER
                System.Diagnostics.Debug.WriteLine(token);
#endif
                yield return Token;
            }
            yield break;
        }

        private void Match()
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
                || MatchName(TokenKind.Keyword, Keywords.All)
                || MatchRegex(TokenKind.Character, SingleQuote, @"^'(.|\.|\n)'", "Unterminated character constant")
                || MatchRegex(TokenKind.String, DoubleQuote, "\"[^\"|\\\"]*\"", "Unterminated string constant")
                ) return;
            switch (Index < Count ? Text[Index] : Nul)
            {
                case LeftBracket:
                    var message = "Invalid date/time format";
                    if (!MatchDateTime(message))
                        MatchTimeSpan(message);
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

        private bool MatchRegex(TokenKind kind, char key, string pattern, string message) =>
            Head[0] == key && MatchRegex(kind, pattern, message);

        private bool MatchRegex(TokenKind kind, string pattern, string message = null)
        {
            var match = Regex.Match(Head, pattern, RegexOptions.IgnoreCase);
            var ok = match.Success;
            if (ok)
            {
                Token = new Token(kind, Index, match.Value);
                if (Token.Length < 1)
                {
                    Token.Value = Head.Substring(0, 1);
                    Token.Error = message;
                }
            }
            return ok;
        }

        private bool MatchDateTime(string message) => MatchRegex(TokenKind.DateTime, DateTimePattern, message);
        private void MatchExceptionType() => MatchRegex(TokenKind.TypeName, ExceptionTypePattern);
        private void MatchLabel() => MatchRegex(TokenKind.Label, LabelPattern);
        private bool MatchNumber() => MatchRegex(TokenKind.Number, NumberPattern);
        private void MatchParameter() => MatchRegex(TokenKind.Default, @"^\{\w+(\[\])?\}", "Invalid parameter");
        private bool MatchTimeSpan(string message) => MatchRegex(TokenKind.TimeSpan, TimeSpanPattern, message);
        private void MatchVariable() => MatchRegex(TokenKind.Variable, NamePattern);
        private static bool StartsWithExceptionType(string token) => Regex.IsMatch(token, ExceptionTypePattern);
        private static bool StartsWithLabel(string token) => Regex.IsMatch(token, LabelPattern);
        private Token UnexpectedCharacter() => new Token(0, Index, $"{Text[Index]}") { Error = "Unexpected character" };

        #endregion

        #region Private Fields

        private int Count { get; set; }
        private string Head { get; set; }
        private int Index { get; set; }
        private string Text { get; set; }
        private Token Token { get; set; }

        private const char
            Nul = (char)0,
            Space = ' ',
            SingleQuote = '\'',
            DoubleQuote = '"',
            LeftBrace = '{',
            LeftBracket = '[';

        private const string
            ExceptionTypePattern = @"^[\w_]+Exception",
            LabelPattern = @"^[\w_]+\:",
            NamePattern = @"^[\w_]+",
            NumberPattern = @"^\d+\.?\d*([Ee][-+]\d+)?(UL|LU|D|F|L|M|U)?",
            TimePattern = @"(\d\d?)\:(\d\d?)(?:\:(\d\d?)(\.\d+)?)?";

        public static string
            DateTimePattern = $@"^\[(\d{{4}})-(\d\d?)\-(\d\d?)(?: {TimePattern})?\]",
            TimeSpanPattern = $@"^\[(?:(\d+)\.)?{TimePattern}\]";

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
    }
}
