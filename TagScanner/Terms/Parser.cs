namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Utils;

    public class Parser
    {
        #region Constructor

        public Parser(string text)
        {
            Text = text;
            Count = Text?.Length ?? 0;
            Index = 0;
        }

        #endregion

        #region Public Properties

        public IEnumerable<string> AllTokens()
        {
            while(true)
            {
                var token = PeekToken();
                if (string.IsNullOrWhiteSpace(token))
                    yield break;
                System.Diagnostics.Debug.WriteLine(token);
                ReadPast(token);
                yield return token;
            }
        }

        #endregion

        #region Public Properties

        public string Text { get; private set; }
        public int Count { get; private set; }
        public int Index { get; private set; }

        #endregion

        #region Private Fields

        private const char
            Eof = (char)26,
            SingleQuote = '\'',
            DoubleQuote = '"';

        /// <summary>
        /// Names are ordered descending to that, for example, "Album Artists" is matched before "Artists".
        /// If these were sorted in ascending or other order, "Album Artists" might never be matched.
        /// </summary>
        private static readonly string[] Tokens = Functions.Union(Fields).Union(Types).Union(Symbols).OrderByDescending(p => p).ToArray();

        #endregion

        #region Private Properties

        private static IEnumerable<string> Dyads => new[] { "&", "|", "^", "=", "!=", "<", ">=", ">", "<=", "+", "-", "*", "/" };
        private static IEnumerable<string> Functions => Methods.Keys;
        private static IEnumerable<string> MemberFunctions => Methods.Keys.Where(p => !p.IsStatic());
        private static IEnumerable<string> Monads => new[] { "+", "-", "!" };
        private static IEnumerable<string> StaticFunctions => Methods.Keys.Where(p => p.IsStatic());
        private static IEnumerable<string> Symbols => Monads.Union(Dyads).Union(Triads).Union(new[] { "(", ")", ",", "." });
        private static IEnumerable<string> Fields => Tags.Keys.Select(p => p.DisplayName());
        private static IEnumerable<string> Triads => new[] { "?", ":" };
        private static IEnumerable<string> Types => Cast.Types.Select(p => p.Say());
            
        #endregion

        #region Private Methods

        private bool IsChar(string token) => token[0] == SingleQuote;
        private bool IsFunction(string token) => Functions.Contains(token);
        private bool IsMemberFunction(string token) => MemberFunctions.Contains(token);
        private bool IsMonad(string token) => Monads.Contains(token);
        private bool IsNumber(string token) => char.IsDigit(token[0]);
        private bool IsStaticFunction(string token) => StaticFunctions.Contains(token);
        private bool IsString(string token) => token[0] == DoubleQuote;
        private bool IsTag(string token) => Fields.Contains(token);
        private bool IsType(string token) => Types.Contains(token);

        private string MatchCharacter() => MatchRegex(@"^'([^\]|\.)'");
        private string MatchNumber() => MatchRegex(@"^(\d+\.?\d*|)");
        private string MatchRegex(string pattern) => Regex.Match(Text.Substring(Index), pattern).Value;

        private string MatchString()
        {
            var p = Index;
            while (p >= 0)
            {
                p = Text.IndexOf('"', p + 1);
                if (p > 0 && Text[p - 1] != '\\')
                    return Text.Substring(Index, p - Index + 1);
            }
            return string.Empty;
        }

        private string MatchToken()
        {
            var text = Text.Substring(Index);
            return Tokens.FirstOrDefault(p => text.StartsWith(p));
        }

        private char PeekChar() => Index < Count ? Text[Index] : Eof;

        private string PeekToken()
        {
            SkipWhitespace();
            var result = MatchToken();
            if (!string.IsNullOrWhiteSpace(result))
                return result;
            var c = PeekChar();
            switch (c)
            {
                case SingleQuote:
                    return MatchCharacter();
                case DoubleQuote:
                    return MatchString();
                case char digit when char.IsDigit(digit):
                    return MatchNumber();
                case Eof:
                    return string.Empty;
            }
            throw new FormatException($"Unexpected character '{c}' in input '{Text}' at position {Index}.");
        }

        private void ReadPast(string token) => Index += token.Length;

        private void SkipWhitespace()
        {
            while (Index < Count && Text[Index] <= ' ')
                Index++;
        }

        #endregion
    }
}
