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
    //  public bool AnyTerms() => _terms.Any();
        public bool AnyTokens() => _tokens.Any();

        public void AcceptToken(string caller, int line, string expected) => Process(caller, line, p => AcceptToken(expected));
        public void BeginParse(string caller, int line, string text) => Process(caller, line, p => Reset(caller, line, text));
        public Operation Consolidate(string caller, int line, Term right) => (Operation)Process(caller, line, p => Consolidate(right));
        public Token DequeueToken(string caller, int line) => (Token)Process(caller, line, p => _tokens.Dequeue());
        public Term EndParse(string caller, int line, Term term) => (Term)Process(caller, line, p => EndParse(term));
    //  public void EnqueueToken(string caller, int line, Token token) => Process(caller, line, p => { _tokens.Enqueue(token); return token; });
        public Term NewTerm(string caller, int line, Term term) { Process(caller, line, p => term); return term; }
        public Op PeekOperator(string caller, int line) => (Op)Process(caller, line, p => _operators.Peek());
    //  public Term PeekTerm(string caller, int line) => (Term)Process(caller, line, p => _terms.Peek());
        public Token PeekToken(string caller, int line) => (Token)Process(caller, line, p => _tokens.Peek());
        public Op PopOperator(string caller, int line) => (Op)Process(caller, line, p => _operators.Pop());
        public Term PopTerm(string caller, int line) => (Term)Process(caller, line, p => _terms.Pop());
        public void PushOperator(string caller, int line, Op op) => Process(caller, line, p => { _operators.Push(op); return op; });
        public void PushTerm(string caller, int line, Term term) => Process(caller, line, p => { _terms.Push(term); return term; });
        public object UnexpectedToken(string caller, int line, Token token) => Process(caller, line, p => UnexpectedToken(token));

        #endregion

        #region Private Fields

        private readonly Stack<Op> _operators = new Stack<Op>();
        private readonly Stack<Term> _terms = new Stack<Term>();
        private readonly Queue<Token> _tokens = new Queue<Token>();
        private bool _headerShown;
        private static readonly string _ = string.Empty;

        #endregion

        #region Private Methods

        private object AcceptToken(string expected)
        {
            var token = _tokens.Dequeue();
            return token.Value == expected ? token : UnexpectedToken(token, expected);
        }

        private Operation Consolidate(Term right)
        {
            var left = _terms.Pop();
            var op = _operators.Pop();
            bool
                ass = op.Associates(),
                lop = ass && left is Operation leftOp && leftOp.Op == op,
                rop = ass && right is Operation rightOp && rightOp.Op == op;
            IEnumerable<Term>
                leftOps = lop ? ((Operation)left).Operands.ToArray() : new[] { left },
                rightOps = rop ? ((Operation)right).Operands.ToArray() : new[] { right };
            return new Operation(op, leftOps.Union(rightOps).ToArray());
        }

        private void Dump(string caller, int line, object value, [CallerMemberName] string action = "")
        {
#if DEBUG_PARSER
            const string format = "{0,19}{1,6}  {2,12}  {3}";
            if (!_headerShown)
            {
                DrawLine();
                Debug.WriteLine(format, "CALLER", "LINE", "ACTION", "VALUE");
                DrawLine();
                _headerShown = true;
            }
            Debug.WriteLine(format, caller, line, action, value);
            if (action.StartsWith("New") || action.StartsWith("Peek"))
                return;
            Debug.WriteLine(format, _, _, "Tokens", Say(_tokens.Select(p => p.Value)));
            Debug.WriteLine(format, _, _, "Terms", Say(_terms));
            Debug.WriteLine(format, _, _, "Operators", Say(_operators.Select(p => p.GetLabel())));
            Debug.WriteLine(_);

            void DrawLine() => Debug.WriteLine(new string('_', 80) + Environment.NewLine);
#endif
        }

        private Term EndParse(Term term)
        {
            if (AnyTokens())
                UnexpectedToken(_tokens.Peek());
            return term;
        }

        private void Exception(string caller, int line, Exception exception, [CallerMemberName] string action = "") =>
            Dump(caller, line, exception.GetAllInformation(), action);

        private object Process(string caller, int line, Func<object, object> process, object value = null, [CallerMemberName] string action = "")
        {
            try
            {
                value = process(value);
            }
            catch (Exception exception)
            {
                Exception(caller, line, exception, action);
                throw;
            }
            Dump(caller, line, value is Op ? ((Op)value).GetLabel() : value, action);
            return value;
        }

        private string Reset(string caller, int line, string text)
        {
            Dump(caller, line, text);
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            _headerShown = false;
            foreach (var token in Tokenizer.GetTokens(text))
                _tokens.Enqueue(token);
            return text;
        }

        private static object Say(IEnumerable<object> s) => s.Any() ? s.Aggregate((p, q) => $"{p} {q}") : _;

        private static object UnexpectedToken(Token token, string expected = "")
        {
            var error = $"Unexpected input at index {token.Index}:";
            throw new FormatException(string.IsNullOrWhiteSpace(expected)
                ? $"{error} {token}."
                : $"{error} expected {expected}, actual {token}.");
        }

        #endregion
    }
}
