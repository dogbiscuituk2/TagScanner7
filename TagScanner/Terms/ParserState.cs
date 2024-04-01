namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

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
            Dump(line, "Begin Parse", text, Options.LineAbove);
        }

        public Token DequeueToken(int line)
        {
            var token = _tokens.Dequeue();
            Dump(line, "Dequeue Token", token.Value);
            return token;
        }

        public Term EndParse(Term term, int line)
        {
            Dump(line, "End Parse", term, Options.LineBelow);
            return term;
        }

        public void EnqueueToken(Token token, int line)
        {
            _tokens.Enqueue(token);
            Dump(line, "Enqueue Token", token.Value);
        }

        public Term NewTerm(Term term, int line, string member)
        {
            Dump(line, "New Term", $"{term} (in {member})", Options.None);
            return term;
        }

        public Op PeekOperator(int line)
        {
            var op = _operators.Peek();
            Dump(line, "Peek Operator", op, Options.None);
            return op;
        }

        public Term PeekTerm(int line)
        {
            var term = _terms.Peek();
            Dump(line, "Peek Term", term, Options.None);
            return term;
        }

        public Token PeekToken(int line)
        {
            var token = _tokens.Peek();
            Dump(line, "Peek Token", token.Value, Options.None);
            return token;
        }

        public Op PopOperator(int line)
        {
            var op = _operators.Pop();
            Dump(line, "Pop Operator", op);
            return op;
        }

        public Term PopTerm(int line)
        {
            var term = _terms.Pop();
            Dump(line, "Pop Term", term);
            return term;
        }

        public void PushOperator(Op op, int line)
        {
            _operators.Push(op);
            Dump(line, "Push Operator", op);
        }

        public void PushTerm(Term term, int line)
        {
            _terms.Push(term);
            Dump(line, "Push Term", term);
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

        private void Dump(int line, string step, object value, Options options = Options.AllState)
        {
#if DEBUG_PARSER
            var ruler = new string('-', 64);
            if ((options & Options.LineAbove) != 0)
                Debug.WriteLine($"{ruler}\r\nLine    Activity    ParserState\r\n{ruler}");
            Debug.WriteLine("{0,4}{1,14}: {2}", line, step, value);
            if ((options & Options.AllState) != 0)
                Debug.WriteLine(this);
            if ((options & Options.LineBelow) != 0)
                Debug.WriteLine(ruler);
#endif
        }

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
