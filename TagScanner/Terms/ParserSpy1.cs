namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Utils;

    public class ParserSpy1
    {
        #region Public Methods

        public bool AnyOperators() => Operators.Any();
        public bool AnyTokens() => Tokens.Any();

        public void AcceptToken(string caller, int line, string expected) => Process(caller, line, p => AcceptToken(expected));
        public void BeginParse(string caller, int line, string text) => Process(caller, line, p => Reset(caller, line, text));
        public Compound Consolidate(string caller, int line, Term right) => (Compound)Process(caller, line, p => Consolidate(right));
        public Token DequeueToken(string caller, int line) => (Token)Process(caller, line, p => Tokens.Dequeue());
        public Term EndParse(string caller, int line, Term term) => (Term)Process(caller, line, p => EndParse(term));
        public Term NewTerm(string caller, int line, Term term) { Process(caller, line, p => term); return term; }
        public Op PeekOperator(string caller, int line) => (Op)Process(caller, line, p => Operators.Peek());
        public Token PeekToken(string caller, int line) => (Token)Process(caller, line, p => Tokens.Peek());
        public Op PopOperator(string caller, int line) => (Op)Process(caller, line, p => Operators.Pop());
        public Term PopTerm(string caller, int line) => (Term)Process(caller, line, p => Terms.Pop());
        public void PushOperator(string caller, int line, Op op) => Process(caller, line, p => { Operators.Push(op); return op; });
        public void PushTerm(string caller, int line, Term term) => Process(caller, line, p => { Terms.Push(term); return term; });
        public object UnexpectedToken(string caller, int line, Token token) => Process(caller, line, p => UnexpectedToken(token));

        #endregion

        #region Private Fields

        private static readonly string _ = string.Empty;
        private bool HeaderShown;
        private readonly Stack<Op> Operators = new Stack<Op>();
        private readonly Stack<Term> Terms = new Stack<Term>();
        private readonly Queue<Token> Tokens = new Queue<Token>();

        #endregion

        #region Private Methods

        private object AcceptToken(string expected)
        {
            var token = Tokens.Dequeue();
            return token.Value == expected ? token : UnexpectedToken(token, expected);
        }

        /// <summary>
        /// Merge a new Term with the current Term, respecting the Associativity of the current Op.
        /// When the Op has Associativity.Full, these two terms (or term lists) can have their operands merged freely.
        /// When the Op has just Associativity.Left, the operand list of the new added term cannot be merged.
        /// When the Op has just Associativity.Right, the operand list of the new added term cannot be merged.
        /// When the Op has Associativity.None, the operands cannot be merged at all..
        /// </summary>
        /// <param name="right">The Term to be merged with the current Term.</param>
        /// <returns>The new Term resulting from the merge.</returns>
        private Compound Consolidate(Term right)
        {
            var left = Terms.Pop();
            var op = Operators.Pop();
            var ass = op.GetAssociativity();
            bool
                lop = left is Compound leftOp && leftOp.Op == op,
                rop = right is Compound rightOp && rightOp.Op == op && (ass & Associativity.Right) != 0;
            IEnumerable<Term>
                leftOps = lop ? ((Compound)left).Operands.ToArray() : new[] { left },
                rightOps = rop ? ((Compound)right).Operands.ToArray() : new[] { right };
            var operands = leftOps.Concat(rightOps).ToArray();
            return op == Op.Comma
                ? new TermList(operands)
                : (Compound)new Operation(op, operands);
        }

        private void Dump(string caller, int line, object value, [CallerMemberName] string action = "")
        {
#if DEBUG_PARSER
            const string format = "{0,19}{1,6}  {2,12}  {3}";
            if (!HeaderShown)
            {
                DrawLine();
                Debug.WriteLine(format, "CALLER", "LINE", "ACTION", "VALUE");
                DrawLine();
                HeaderShown = true;
            }
            if (action == "NewTerm")
                value = TermInfo(value);
            Debug.WriteLine(format, caller, line, action, value);
            if (action.StartsWith("New") || action.StartsWith("Peek"))
                return;
            Debug.WriteLine(format, _, _, "Tokens", Say(Tokens.Select(p => p.Value)));
            Debug.WriteLine(format, _, _, "Operators", Say(Operators.Select(p => p.Label())));
            Debug.WriteLine(format, _, _, "Terms", Terms.Any() ? TermInfo(Terms.First()) : string.Empty);
            if (Terms.Count > 1)
                foreach (var term in Terms?.Skip(1))
                    Debug.WriteLine(format, _, _, _, TermInfo(term));
            Debug.WriteLine(_);

            void DrawLine() => Debug.WriteLine(new string('_', 80) + Environment.NewLine);
            string TermInfo(object term) => $"{term.GetType().Say()}: {term}";
#endif
        }

        private Term EndParse(Term term)
        {
            if (AnyTokens())
                UnexpectedToken(Tokens.Peek());
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
            Dump(caller, line, value is Op ? ((Op)value).Label() : value, action);
            return value;
        }

        private string Reset(string caller, int line, string text)
        {
            Tokens.Clear();
            Terms.Clear();
            Operators.Clear();
            HeaderShown = false;
            Dump(caller, line, text);
            foreach (var token in Tokenizer.GetTokens(text))
                if (!token.Value.IsComment())
                    Tokens.Enqueue(token);
            return text;
        }

        private static object Say(IEnumerable<object> s) => s.Any() ? s.Aggregate((p, q) => $"{p} {q}") : _;

        private static object UnexpectedToken(Token token, string expected = "")
        {
            var error = $"Unexpected input at index {token.Start}:";
            throw new FormatException(string.IsNullOrWhiteSpace(expected)
                ? $"{error} {token}."
                : $"{error} expected {expected}, actual {token}.");
        }

        #endregion
    }
}
