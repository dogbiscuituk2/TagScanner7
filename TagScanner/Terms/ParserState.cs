namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Linq;

    public class ParserState
    {
        public ParserState()
        {
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            _operators.Push(Op.LParen); ;
        }

        private readonly Queue<Token> _tokens = new Queue<Token>();

        public bool AnyMoreTokens => _tokens.Any();
        public Token DequeueToken() => _tokens.Dequeue();
        public void EnqueueToken(Token token) => _tokens.Enqueue(token);
        public Token PeekToken() => _tokens.Peek();

        private readonly Stack<Term> _terms = new Stack<Term>();

        public bool AnyMoreTerms => _terms.Any();
        public Term PeekTerm() => _terms.Peek();
        public Term PopTerm() => _terms.Pop();
        public void PushTerm(Term term) => _terms.Push(term);

        private readonly Stack<Op> _operators = new Stack<Op>();

        public bool AnyMoreOperators => _operators.Any();
        public Op PeekOperator() => _operators.Peek();
        public Op PopOperator() => _operators.Pop();
        public void PushOperator(Op op) => _operators.Push(op);
    }
}
