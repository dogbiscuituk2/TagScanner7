namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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
            _end.Start = text.Length;
            _caseSensitive = caseSensitive;
            BeginParse(text);
            var term = ParseTermList();
            var token = PeekToken();
            return token == _end ? term : SyntaxError(token);
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

        #region Fields

        private bool _caseSensitive;
        private readonly Token _end = new Token(TokenKind.None, 0, string.Empty);
        private readonly Stack<Op> _operators = new Stack<Op>();
        private readonly Stack<Term> _terms = new Stack<Term>();
        private readonly Queue<Token> _tokens = new Queue<Token>();
        private readonly Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();

        #endregion

        #region Nonterminals

        private void Accept(string expectedTokenValue)
        {
            Debug.Assert(PeekTokenValue() == expectedTokenValue);
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
            if (PeekTokenValue() == "(")
            {
                PopToken();
                var term = ParseCompound();
                Accept(")");
                return term;
            }
            Term left = ParseSimpleTerm();
            while (PeekToken().IsBinaryOperator())
            {
                var op = PopToken().Value.ToBinaryOperator();
                var right = ParseSimpleTerm();
                left = new Operation(op, left, right);
            }
            return left;
        }

        private Term ParseSimpleTerm()
        {
            if (PeekToken().IsUnaryOperator())
                return new Operation(PopToken().Value.ToUnaryOperator(), ParseSimpleTerm());
            if (PeekTokenValue() == "(")
            {
                PopToken();
                if (PeekToken().Kind == TokenKind.TypeName)
                {
                    var type = PopToken().Value.ToType();
                    Accept(")");
                    return new Cast(type, ParseSimpleTerm());
                }
                var termList = ParseTermList();
                Accept(")");
                return termList;
            }
            return ParseAtom();
        }

        private Term ParseAtom()
        {
            var term = ParseFirstPart();
            while (true)
            {
                if (PeekTokenValue() == ".")
                {
                    PopToken();
                    term = ParseFunction(term);
                }
            }
        }

        private Term ParseFirstPart()
        {
            var token = PopToken();
            var value = token.Value;
            switch (token.Kind)
            {
                case TokenKind.Boolean: return ParseBoolean(value);
                case TokenKind.Character: return ParseCharacter(value);
                case TokenKind.DateTime: return ParseDateTime(value);
                case TokenKind.Default: return ParseDefault(value);
                case TokenKind.Field: return ParseField(value);
                case TokenKind.Function: return ParseFunction();
                case TokenKind.Number: return ParseNumber(value.ToUpperInvariant());
                case TokenKind.String: return ParseString(value);
                case TokenKind.TimeSpan: return ParseTimeSpan(value);
                case TokenKind.Variable: return ParseVariable(value);
            }
            return SyntaxError(token);
        }

        private Term ParseFunction() => ParseFunction(new List<Term>());
        private Term ParseFunction(Term self) => ParseFunction(new List<Term> { self });
        private Term ParseFunction(List<Term> operands)
        {
            var fn = PopToken().Value.ToFunction();
            if (PeekTokenValue() == "(")
            {
                PopToken();
                if (PeekTokenValue() != ")")
                {
                    var term = ParseCompound();
                    if (term is TermList termList)
                        operands.AddRange(termList.Operands);
                    else
                        operands.Add(term);
                }
                Accept(")");
            }
            return new Function(fn, operands.ToArray());
        }

        private Term ParseTermList()
        {
            Term result = null;
            while (true)
            {
                var term = ParseCompound();
                if (result == null)
                    result = term;
                else if (result is TermList termList)
                    termList.Operands.Add(term);
                else
                    result = new TermList(result, term);
                if (PeekTokenValue() != ",")
                    break;
            }
            return result;
        }

        #endregion

        #region Terminals

        private Term ParseBoolean(string value) => value == "true";

        private Term ParseCharacter(string value) => char.Parse(value.Substring(1, value.Length - 2));

        private Term ParseDateTime(string value) => DateTimeParser.ParseDateTime(value);

        private Term ParseDefault(string value) => new Default(value.Substring(1, value.Length - 2).ToType());

        private Term ParseField(string value) => value.DisplayNameToTag();

        private Term ParseNumber(string value) =>
            value.EndsWith("UL") || value.EndsWith("LU") ? ulong.Parse(value.TrimEnd('U', 'L')) :
            value.EndsWith("D") ? double.Parse(value.TrimEnd('D')) :
            value.EndsWith("F") ? float.Parse(value.TrimEnd('F')) :
            value.EndsWith("L") ? long.Parse(value.TrimEnd('L')) :
            value.EndsWith("M") ? decimal.Parse(value.TrimEnd('M')) :
            value.EndsWith("U") ? uint.Parse(value.TrimEnd('U')) :
            value.Contains(".") ? double.Parse(value) :
            (Term)int.Parse(value);

        private Term ParseString(string value) => value.Substring(1, value.Length - 2);

        private Term ParseTimeSpan(string value) => DateTimeParser.ParseTimeSpan(value);

        private Term ParseVariable(string value)
        {
            var key = value.ToUpperInvariant();
            if (!_variables.ContainsKey(key))
                _variables.Add(key, new Variable(value));
            return _variables[key];
        }

        #endregion

        #region Helpers

        private Token PeekToken() => _tokens.Any() ? _tokens.Peek() : _end;
        private string PeekTokenValue() => PeekToken()?.Value ?? string.Empty;
        private Token PopToken() => _tokens.Dequeue();
        private Term SyntaxError(Token token) => throw new SyntaxErrorException($"Unexpected Token: {token.Value}");

        #endregion
    }
}
