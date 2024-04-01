namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Linq;

    public class ParserState
    {
        public ParserState() => Reset(string.Empty);

        public void Reset(string text)
        {
            _tokens.Clear();
            foreach (var token in Tokenizer.GetTokens(text))
                _tokens.Enqueue(token);
            _terms.Clear();
            _operators.Clear();
            _operators.Push(Op.LParen);
            if (!string.IsNullOrWhiteSpace(text))
                Dump($"        Reset: '{text}'");
        }

        public override string ToString() => $"       Tokens: {Tokens}\r\n        Terms: {Terms}\r\n    Operators: {Operators}\r\n";

        private readonly Queue<Token> _tokens = new Queue<Token>();

        public bool AnyMoreTokens() => _tokens.Any();
        public Token DequeueToken() { var token = _tokens.Dequeue(); Dump($"    Pop Token: '{token.Value}'"); return token; }
        public void EnqueueToken(Token token) { _tokens.Enqueue(token); Dump($"   Push Token: '{token.Value}'"); }
        public Token PeekToken() => _tokens.Peek();

        private readonly Stack<Term> _terms = new Stack<Term>();

        public bool AnyMoreTerms() => _terms.Any();
        public Term PeekTerm() => _terms.Peek();
        public Term PopTerm() { var term = _terms.Pop(); Dump($"     Pop Term: '{term}'"); return term; }
        public void PushTerm(Term term) { _terms.Push(term); Dump($"    Push Term: '{term}'"); }

        private readonly Stack<Op> _operators = new Stack<Op>();

        public bool AnyMoreOperators() => _operators.Any();
        public Op PeekOperator() => _operators.Peek();
        public Op PopOperator() { var op = _operators.Pop(); Dump($" Pop Operator: '{op}'"); return op; }
        public void PushOperator(Op op) { _operators.Push(op); Dump($"Push Operator: '{op}'"); }

        private string Operators => Say(_operators.Select(p => p.ToString()));
        private string Terms => Say(_terms.Select(p => p.ToString()));
        private string Tokens => Say(_tokens.Select(p => p.Value));

        private void Dump(string step = "")
        {
#if DEBUG_PARSER
            System.Diagnostics.Debug.WriteLine($"{step}\r\n{this}");
#endif
        }

        private string Say(IEnumerable<string> strings) => strings.Any() ? strings.Aggregate((p, q) => $"{p} {q}") : "";
    }
}
