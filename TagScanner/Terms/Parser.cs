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
            string token = null;
            while(token != string.Empty)
            {
                token = PeekToken();
                ReadPast(token);
                yield return token;
            }
            yield break;
        }

        #endregion

        #region Public Properties

        public string Text { get; private set; }
        public int Count { get; private set; }
        public int Index { get; private set; }

        #endregion

        #region Private Fields

        private const char Eof = (char)26;

        /// <summary>
        /// Names are ordered descending to that, for example, "Album Artists" is matched before "Artists".
        /// If these were sorted in ascending or other order, "Album Artists" might never be matched.
        /// </summary>
        private static readonly string[] Tokens = Functions.Union(Tags).Union(Types).Union(Symbols).OrderByDescending(p => p).ToArray();

        #endregion

        #region Private Properties

        private static IEnumerable<string> Functions => Methods.Keys;
        private static IEnumerable<string> Tags => Terms.Tags.Keys.Select(p => p.DisplayName());
        private static IEnumerable<string> Types => Cast.Types.Select(p => p.Say());
        private static IEnumerable<string> Symbols => new[] { "(", ")", "?", ":", "&", "|", "^", "=", "!=", "<", ">=", ">", "<=", "+", "-", "*", "/", "!", ",", "." };

        #endregion

        #region Private Methods

        private string MatchCharacter() => MatchRegex(@"^'([^\]|\.)'");
        private string MatchNumber() => MatchRegex(@"^(\d+\.?\d*|)");
        private string MatchRegex(string pattern) => Regex.Match(Text.Substring(Index), pattern).Value;
        private string MatchString() => MatchRegex(@"^""([^\]|\.)*""");

        private string MatchToken()
        {
            var text = Text.Substring(Index);
            try { return Tokens.First(p => text.StartsWith(p)); }
            catch (InvalidOperationException) { throw new FormatException($"Unrecognised token: '{text}'."); }
        }

        private char PeekChar()
        {
            // Skip whitespace.
            while (Index < Count && Text[Index] <= ' ')
                Index++;
            return Index < Count ? Text[Index] : Eof;
        }

        private string PeekToken()
        {
            var result = MatchToken();
            if (!string.IsNullOrWhiteSpace(result))
                return result;
            var nextChar = PeekChar();
            switch (nextChar)
            {
                case '\'':
                    return MatchCharacter();
                case '"':
                    return MatchString();
                case char c when char.IsDigit(c):
                    return MatchNumber();
                case Eof:
                    return string.Empty;
            }
            UnexpectedCharacter(nextChar);
            return string.Empty;
        }

        private void UnexpectedCharacter(char c) => throw new FormatException($"Unexpected character '{c}' in input '{Text}' at position {Index}.");

        private void ReadPast(string token) => Index += token.Length;

        #endregion
    }
}
