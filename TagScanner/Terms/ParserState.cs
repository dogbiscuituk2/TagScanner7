namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class ParserState
    {
        #region Public Methods

        public bool AnyMoreOperators() => _operators.Any();
        public bool AnyMoreTerms() => _terms.Any();
        public bool AnyMoreTokens() => _tokens.Any();

        public Token DequeueToken([CallerLineNumber] int line = 0)
        {
            var token = _tokens.Dequeue();
            Dump($"{line}  Use Token: '{token.Value}'");
            return token;
        }

        public void EnqueueToken(Token token, [CallerLineNumber] int line = 0)
        {
            _tokens.Enqueue(token);
            Dump($"{line}  Put Token: '{token.Value}'");
        }

        public Op PeekOperator([CallerLineNumber] int line = 0)
        {
            var op = _operators.Peek();
            Dump($"{line}    Peek Op: ' {op} '", full: false);
            return op;
        }

        public Term PeekTerm([CallerLineNumber] int line = 0)
        {
            var term = _terms.Peek();
            Dump($"{line}  Peek Term: '{term}'", full: false);
            return term;
        }

        public Token PeekToken([CallerLineNumber] int line = 0)
        {
            var token = _tokens.Peek();
            Dump($"{line} Peek Token: '{token.Value}'", full: false);
            return token;
        }

        public Op PopOperator([CallerLineNumber] int line = 0)
        {
            var op = _operators.Pop();
            Dump($"{line}     Pop Op: ' {op} '");
            return op;
        }

        public Term PopTerm([CallerLineNumber] int line = 0)
        {
            var term = _terms.Pop();
            Dump($"{line}   Pop Term: '{term}'");
            return term;
        }

        public void PushOperator(Op op, [CallerLineNumber] int line = 0)
        {
            _operators.Push(op);
            Dump($"{line}    Push Op: ' {op} '");
        }

        public void PushTerm(Term term, [CallerLineNumber] int line = 0)
        {
            _terms.Push(term);
            Dump($"{line}  Push Term: ' {term} '");
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
                Dump($"{line}      Reset: '{text}'");
        }

        public override string ToString() => $"        Tokens: {Tokens}\r\n         Terms: {Terms}\r\n     Operators: {Operators}\r\n";

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

        private void Dump(string step, bool full = true)
        {
#if DEBUG_PARSER
            System.Diagnostics.Debug.WriteLine($"{step}\r\n{(full ? ToString() : string.Empty)}");
#endif
        }

        private static object Say(IEnumerable<object> s) => (s.Any() ? s.Aggregate((p, q) => $"{p} {q}") : string.Empty);

        #endregion
    }
}
