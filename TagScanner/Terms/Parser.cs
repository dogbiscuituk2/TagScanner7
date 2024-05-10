namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Utils;

    public class Parser
    {
        #region Public Methods

        /// <summary>
        /// Parse an arbitrary string into a Term.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <param name="caseSensitive">Matching of data field & function names, type casts, operators and other syntactical elements, is always insensitive to case. 
        /// The caseSensitive value applies only to the user data, such as track titles, album names, performers, and so on.</param>
        /// <returns>The Term obtained from parsing.</returns>
        public Term Parse(string text, bool caseSensitive)
        {
            _endToken.StartIndex = text.Length;
            _caseSensitive = caseSensitive;
            BeginParse(text);
            var term = ParseTermList();
            EndParse(term);
            return term;
        }

        /// <summary>
        ///  Parse an arbitrary string into a Term, catching any exceptions and forwarding their information.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <param name="term">The Term obtained from parsing, assuming no exceptions occurred.</param>
        /// <param name="exception">The exception that did, in fact, occur.</param>
        /// <param name="caseSensitive">Matching of data field & function names, type casts, operators and other syntactical elements,
        /// is always insensitive to case. The caseSensitive value applies only to the user data, such as track titles, album names,
        /// performers, and so on.</param>
        /// <returns>True if the parsing succeeded, and the result is returned in the out term.
        /// False if an exception occurred, and the exception is returned in the out exception.</returns>
        public bool TryParse(string text, out Term term, out Exception exception, bool caseSensitive)
        {
            try
            {
                term = Parse(text, caseSensitive);
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                term = null;
                exception = ex;
                return false;
            }
        }

        #endregion

        #region Private Fields

        private bool _caseSensitive;
        private readonly Stack<Op> _operators = new Stack<Op>();
        private readonly Stack<Term> _terms = new Stack<Term>();
        private readonly Queue<Token> _tokens = new Queue<Token>();
        private readonly Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();
        private Token _endToken = new Token(TokenType.None, 0, string.Empty);

        #endregion

        #region Private Methods

        private void Accept(string expectedTokenValue)
        {
            Debug.Assert(NextTokenValue == expectedTokenValue);
            _tokens.Dequeue();
        }

        private void BeginParse(string text)
        {
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            foreach (var token in Tokenizer.GetTokens(text))
                if (!token.Value.IsComment())
                    _tokens.Enqueue(token);
        }

        private Term ParseCompound()
        {
            var term = ParseSimpleTerm();
            while (NextToken.IsBinaryOperator())
            {

            }
            return term;
        }

        private Term ParseSimpleTerm()
        {
            return null;
        }

        private Term ParseTermList()
        {
            var termList = new TermList();
            while (true)
            {
                termList.Add(ParseCompound());
                if (NextTokenValue != ",")
                    break;
                _tokens.Dequeue();
            }
            return termList;
        }

        private Token NextToken => _tokens.Any() ? _tokens.Peek() : _endToken;
        private string NextTokenValue => NextToken?.Value ?? string.Empty;

        #endregion
    }
}
