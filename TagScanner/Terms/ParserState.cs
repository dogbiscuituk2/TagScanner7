namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParserState
    {
        public ParserState() => Reset();

        public void Reset()
        {
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            _operators.Push(Op.LParen); ;
        }

        public override string ToString() => $"Tokens: {Tokens}\r\nTerms: {Terms}\r\nOperators: {Operators}\r\n";

        private readonly Queue<Token> _tokens = new Queue<Token>();

        public bool AnyMoreTokens() => _tokens.Any();
        public Token DequeueToken() { var result = _tokens.Dequeue(); Dump(); return result; }
        public void EnqueueToken(Token token) { _tokens.Enqueue(token); Dump(); }
        public Token PeekToken() => _tokens.Peek();

        private readonly Stack<Term> _terms = new Stack<Term>();

        public bool AnyMoreTerms() => _terms.Any();
        public Term PeekTerm() => _terms.Peek();
        public Term PopTerm() { var result = _terms.Pop(); Dump(); return result; }
        public void PushTerm(Term term) { _terms.Push(term); Dump(); }

        private readonly Stack<Op> _operators = new Stack<Op>();

        public bool AnyMoreOperators() => _operators.Any();
        public Op PeekOperator() => _operators.Peek();
        public Op PopOperator() { var result = _operators.Pop(); Dump(); return result; }
        public void PushOperator(Op op) { _operators.Push(op); Dump(); }

        private string Operators => Say(_operators.Select(p => p.ToString()));
        private string Terms => Say(_terms.Select(p => p.ToString()));
        private string Tokens => Say(_tokens.Select(p => p.Value));

        private void Dump() => System.Diagnostics.Debug.WriteLine(this);
        private string Say(IEnumerable<string> strings) => strings.Any() ? strings.Aggregate((p, q) => $"{p} {q}") : "";
    }
}
