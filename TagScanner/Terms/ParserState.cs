namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Utils;

    public class ParserState
    {
        #region Public Methods

        public bool AnyOperators() => _operators.Any();
        public bool AnyTerms() => _terms.Any();
        public bool AnyTokens() => _tokens.Any();

        public void BeginParse(string text, int line)
        {
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            foreach (var token in Tokenizer.GetTokens(text))
                _tokens.Enqueue(token);
            Dump(line, text, options: Options.LineAbove);
        }

        public Token DequeueToken(int line)
        {
            Token token;
            try
            {
                token = _tokens.Dequeue();
            }
            catch (Exception exception)
            {
                Exception(line, exception);
                throw;
            }
            Dump(line, token.Value);
            return token;
        }

        public Term EndParse(Term term, int line)
        {
            Dump(line, term, options: Options.AllState | Options.LineBelow);
            return term;
        }

        public void EnqueueToken(Token token, int line)
        {
            _tokens.Enqueue(token);
            Dump(line, token.Value);
        }

        public Term NewTerm(Term term, int line, string member)
        {
            Dump(line, $"{term} (in {member})", options: Options.None);
            return term;
        }

        public Op PeekOperator(int line)
        {
            var op = _operators.Peek();
            Dump(line, op, options: Options.None);
            return op;
        }

        public Term PeekTerm(int line)
        {
            var term = _terms.Peek();
            Dump(line, term, options: Options.None);
            return term;
        }

        public Token PeekToken(int line)
        {
            var token = _tokens.Peek();
            Dump(line, token.Value, options: Options.None);
            return token;
        }

        public Op PopOperator(int line)
        {
            var op = _operators.Pop();
            Dump(line, op);
            return op;
        }

        public Term PopTerm(int line)
        {
            var term = _terms.Pop();
            Dump(line, term);
            return term;
        }

        public void PushOperator(Op op, int line)
        {
            _operators.Push(op);
            Dump(line, op);
        }

        public void PushTerm(Term term, int line)
        {
            _terms.Push(term);
            Dump(line, term);
        }

        public override string ToString() => string.Format("{0,18}: {1}\r\n{2,18}: {3}\r\n{4,18}: {5}\r\n",
            "Tokens", Say(_tokens.Select(p => p.Value)),
            "Terms", Say(_terms),
            "Operators", Say(_operators.Select(p => p.ToString())));

        #endregion

        #region Private Fields

        private readonly Stack<Op> _operators = new Stack<Op>();
        private readonly Stack<Term> _terms = new Stack<Term>();
        private readonly Queue<Token> _tokens = new Queue<Token>();

        #endregion

        #region Private Methods

        private void Dump(int line, object value, [CallerMemberName] string member = "", Options options = Options.AllState)
        {
#if DEBUG_PARSER
            var ruler = new string('-', 64);
            if ((options & Options.LineAbove) != 0)
                Debug.WriteLine($"{ruler}\r\nLine    Activity    ParserState\r\n{ruler}");
            Debug.WriteLine("{0,5}{1,13}: {2}", line, member, value);
            if ((options & Options.AllState) != 0)
                Debug.WriteLine(this);
            if ((options & Options.LineBelow) != 0)
                Debug.WriteLine(ruler);
#endif
        }


        private void Exception(int line, Exception exception, [CallerMemberName] string member = "") =>
            Dump(line, exception.GetAllInformation(), member);

        private static object Say(IEnumerable<object> s) => s.Any() ? s.Aggregate((p, q) => $"{p} {q}") : string.Empty;

        #endregion

        #region Private Types

        [Flags]
        private enum Options
        {
            None = 0,
            LineAbove = 1,
            LineBelow = 2,
            AllState = 4,
        }

        #endregion
    }
}
