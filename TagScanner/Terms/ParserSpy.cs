namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using Utils;

    public class ParserSpy
    {
        #region Public Methods

        #region Labels

        public Label AddLabel(string caller, int line, string labelName) => (Label)Process(caller, line, p => AddLabel(labelName));
        public LabelTarget GetLabelTarget(string caller, int line, string labelName) => (LabelTarget)Process(caller, line, p => GetLabelTarget(labelName));

        #endregion
        #region Loops

        public Loop BeginLoop(string caller, int line) => (Loop)Process(caller, line, p => NewLoop());
        public Break Break(string caller, int line) => (Break)Process(caller, line, p => new Break(_loops.Peek().BreakTarget));
        public Continue Continue(string caller, int line) => (Continue)Process(caller, line, p => new Continue(_loops.Peek().ContinueTarget));
        public Loop EndLoop(string caller, int line) => (Loop)Process(caller, line, p => _loops.Pop());

        #endregion
        #region Operators

        public bool AnyOperators() => _operators.Any();
        public Op PeekOperator(string caller, int line) => (Op)Process(caller, line, p => _operators.Peek());
        public Op PopOperator(string caller, int line) => (Op)Process(caller, line, p => _operators.Pop());
        public void PushOperator(string caller, int line, Op op) => Process(caller, line, p => { _operators.Push(op); return op; });

        #endregion
        #region Parse

        public void BeginParse(string caller, int line, string program) => Process(caller, line, p => Reset(caller, line, program));
        public Compound Consolidate(string caller, int line, Term right) => (Compound)Process(caller, line, p => Consolidate(right));
        public Term EndParse(string caller, int line, Term term) => (Term)Process(caller, line, p => EndParse(term));

        #endregion
        #region Scopes

        public Scope BeginScope(string caller, int line) => (Scope)Process(caller, line, p => PushScope());
        public Scope EndScope(string caller, int line) => (Scope)Process(caller, line, p => PopScope());

        #endregion
        #region Terms

        public Term NewTerm(string caller, int line, Term term) { Process(caller, line, p => term); return term; }
        public Term PopTerm(string caller, int line) => (Term)Process(caller, line, p => _terms.Pop());
        public void PushTerm(string caller, int line, Term term) => Process(caller, line, p => { _terms.Push(term); return term; });

        #endregion
        #region Tokens

        public bool AnyTokens() => _tokens.Any();
        public void AcceptToken(string caller, int line, string expected) => Process(caller, line, p => AcceptToken(expected));
        public Token PeekToken(string caller, int line) => (Token)Process(caller, line, p => NextToken());
        public Token PopToken(string caller, int line) => (Token)Process(caller, line, p => _tokens.Dequeue());
        public bool PopToken(string caller, int line, string expected) => (bool)Process(caller, line, p => PopToken(expected));
        public object UnexpectedToken(string caller, int line, Token token) => Process(caller, line, p => UnexpectedToken(token));

        #endregion
        #region Variables

        public Variable GetVariable(string caller, int line, string key) => (Variable)Process(caller, line, p => GetVariable(key));

        #endregion

        #endregion

        #region Private Fields

        private static readonly string _ = string.Empty;
        private bool _headerShown;
        private readonly Dictionary<string, Label> _labels = new Dictionary<string, Label>();
        private readonly Stack<Loop> _loops = new Stack<Loop>();
        private readonly Stack<Op> _operators = new Stack<Op>();
        private readonly Stack<Scope> _scopes = new Stack<Scope>();
        private readonly Stack<Term> _terms = new Stack<Term>();
        private readonly Queue<Token> _tokens = new Queue<Token>();

        #endregion

        #region Private Methods

        private Token AcceptToken(string expected)
        {
            var token = _tokens.Peek();
            var ok = token.Value == expected;
            return ok ? _tokens.Dequeue() : (Token)UnexpectedToken(token, expected);
        }

        private Label AddLabel(string labelName)
        {
            if (!_labels.ContainsKey(labelName))
            {
                var label = new Label(Expression.Label(labelName));
                _labels.Add(labelName, label);
            }
            return _labels[labelName];
        }

        private LabelTarget GetLabelTarget(string labelName) => _labels[labelName].LabelTarget;

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
            var left = _terms.Pop();
            var op = _operators.Pop();
            var ass = op.GetAssociativity();
            bool
                lop = left is Compound leftOp && leftOp.Op == op,
                rop = right is Compound rightOp && rightOp.Op == op && (ass & Associativity.Right) != 0;
            IEnumerable<Term>
                leftOps = lop ? ((Compound)left).Operands.ToArray() : new[] { left },
                rightOps = rop ? ((Compound)right).Operands.ToArray() : new[] { right };
            var operands = leftOps.Concat(rightOps).ToArray();
            return new Operation(op, operands);
        }

        private void Dump(string caller, int line, object value, [CallerMemberName] string action = "")
        {
#if DEBUG_PARSER
            const string format = "{0,19}{1,6}  {2,12}  {3}";
            if (!_headerShown)
            {
                Debug.WriteLine(format, "CALLER", "LINE", "ACTION", "VALUE");
                DrawLine();
                _headerShown = true;
            }
            if (action == "NewTerm")
                value = TermInfo(value);
            Debug.WriteLine(format, caller, line, action, value);
            if (action.StartsWith("New") || action.StartsWith("Peek"))
                return;
            Debug.WriteLine(format, _, _, "Tokens", Say(_tokens.Select(p => p.Value)));
            Debug.WriteLine(format, _, _, "Operators", Say(_operators.Select(p => p.Label())));
            Debug.WriteLine(format, _, _, "Terms", _terms.Any() ? TermInfo(_terms.First()) : string.Empty);
            if (_terms.Count > 1)
                foreach (var term in _terms?.Skip(1))
                    Debug.WriteLine(format, _, _, _, TermInfo(term));
            if (action == "EndParse")
                DrawLine();
            else
                Debug.WriteLine(_);

            void DrawLine() => Debug.WriteLine(new string('_', 80) + Environment.NewLine);
            string TermInfo(object term) => $"{term.GetType().Say()}: {term}";
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

        private Variable GetVariable(string key)
        {
            Variable variable;
            foreach (var scope in _scopes)
            {
                variable = scope.FindVariable(key);
                if (variable != null)
                    return variable;
            }
            return _scopes.Peek().MakeVariable(key);
        }

        private Token NextToken() => _tokens.Any() ? _tokens.Peek() : null;

        private Loop NewLoop() { var loop = new Loop(new EmptyTerm(), new EmptyTerm(), new EmptyTerm()); _loops.Push(loop); return loop; }

        private Scope PopScope() => _scopes.Pop();

        private bool PopToken(string expected)
        {
            var ok = _tokens.Peek().Value == expected;
            if (ok)
                _tokens.Dequeue();
            return ok;
        }

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
            Dump(caller, line, value is Op op ? op.Label() : value, action);
            return value;
        }

        private Scope PushScope() { var scope = new Scope(); _scopes.Push(scope); return scope; }

        private string Reset(string caller, int line, string program)
        {
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            _loops.Clear();
            _scopes.Clear();
            _headerShown = false;
            PushScope();
            program = $"{program}{Environment.NewLine};{Environment.NewLine}{Label.End}:";
            Dump(caller, line, program);
            foreach (var token in Lexer.GetTokens(program))
                if (!token.Value.IsComment())
                    _tokens.Enqueue(token);
            PopScope();
            return program;
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
