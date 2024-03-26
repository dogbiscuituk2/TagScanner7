namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utils;

    public class Parser
    {
        public Parser(string text)
        {
            Text = text;
            Count = Text?.Length ?? 0;
            Index = 0;
        }

        public string Text { get; private set; }
        public int Count { get; private set; }
        public int Index { get; private set; }

        private const char Eof = (char)26;

        #region Private Methods

        private static IEnumerable<string> Functions => Methods.Keys;
        private static IEnumerable<string> Tags => Terms.Tags.Keys.Select(p => p.DisplayName());
        private static IEnumerable<string> Types => Cast.Types.Select(p => p.Say());
        private static IEnumerable<string> Symbols => new[] { "(", ")", "?", ":", "&", "|", "^", "=", "!=", "<", ">=",">", "<=", "+", "-", "*", "/", "!", ",", "." };

        /// <summary>
        /// Names are ordered descending to that, for example, "Album Artists" is matched before "Artists".
        /// If these were sorted in ascending or other order, "Album Artists" might never be matched.
        /// </summary>
        private static readonly string[] Tokens = Functions.Union(Tags).Union(Types).Union(Symbols).OrderByDescending(p => p).ToArray();

        private string MatchToken()
        {
            var text = Text.Substring(Index);
            try { return Tokens.First(p => text.StartsWith(p)); }
            catch (InvalidOperationException) { throw new FormatException($"Unrecognised name: '{text}'."); }
        }

        private char PeekChar()
        {
            while (Index < Count && Text[Index] == ' ')
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

            }
            throw new FormatException($"Unexpected character '{nextChar}' in input '{Text}' at position {Index}.");
        }

        private void ReadPast(string token) => Index += token.Length;

        #endregion
    }
}
