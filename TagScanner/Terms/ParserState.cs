namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class ParserState
    {
        #region Public Methods

        public bool AnyOperators() => _operators.Any();
        public bool AnyTerms() => _terms.Any();
        public bool AnyTokens() => _tokens.Any();

        public Token DequeueToken([CallerLineNumber] int line = 0)
        {
            var token = _tokens.Dequeue();
            Dump(line, "Dequeue Token", token.Value);
            return token;
        }

        public void EnqueueToken(Token token, [CallerLineNumber] int line = 0)
        {
            _tokens.Enqueue(token);
            Dump(line, "Enqueue Token", token.Value);
        }

        public Term NewTerm(Term term, int line, string member)
        {
            DumpLine(line, "New Term", $"{term} (from {member})");
            return term;
        }

        public Op PeekOperator([CallerLineNumber] int line = 0)
        {
            var op = _operators.Peek();
            DumpLine (line, "Peek Operator", op);
            return op;
        }

        public Term PeekTerm([CallerLineNumber] int line = 0)
        {
            var term = _terms.Peek();
            DumpLine(line, "Peek Term", term);
            return term;
        }

        public Token PeekToken([CallerLineNumber] int line = 0)
        {
            var token = _tokens.Peek();
            DumpLine(line, "Peek Token", token.Value);
            return token;
        }

        public Op PopOperator([CallerLineNumber] int line = 0)
        {
            var op = _operators.Pop();
            Dump(line, "Pop Operator", op);
            return op;
        }

        public Term PopTerm([CallerLineNumber] int line = 0)
        {
            var term = _terms.Pop();
            Dump(line, "Pop Term", term);
            return term;
        }

        public void PushOperator(Op op, [CallerLineNumber] int line = 0)
        {
            _operators.Push(op);
            Dump(line, "Push Operator", op);
        }

        public void PushTerm(Term term, [CallerLineNumber] int line = 0)
        {
            _terms.Push(term);
            Dump(line, "Push Term", term);
        }

        public void Reset(string text, [CallerLineNumber] int line = 0)
        {
            _tokens.Clear();
            foreach (var token in Tokenizer.GetTokens(text))
                _tokens.Enqueue(token);
            _terms.Clear();
            _operators.Clear();
            _operators.Push(Op.LParen);
            if (!string.IsNullOrWhiteSpace(text))
                Dump(line, "Reset", text);
        }

        public override string ToString() => $"            Tokens: {Tokens}\r\n             Terms: {Terms}\r\n         Operators: {Operators}\r\n";

        #endregion

        #region Private Properties

        private object Operators => Say(_operators.Select(p => p.ToString()));
        private object Terms => Say(_terms.Select(p => p));
        private object Tokens => Say(_tokens.Select(p => p.Value));

        #endregion

        #region Private Fields

        private readonly Stack<Op> _operators = new Stack<Op>();
        private readonly Stack<Term> _terms = new Stack<Term>();
        private readonly Queue<Token> _tokens = new Queue<Token>();

        #endregion

        #region Private Methods

        private void Dump(int line, string step, object value) => Debug.WriteLine("{0,4}{1,14}: {2}\r\n{3}", line, step, value, this);
        private void DumpLine(int line, string step, object value) => Debug.WriteLine("{0,4}{1,14}: {2}", line, step, value);
        private static object Say(IEnumerable<object> s) => s.Any() ? s.Aggregate((p, q) => $"{p} {q}") : string.Empty;

        #endregion
    }
}
