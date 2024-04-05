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

        public void BeginParse(string text, int line, string caller)
        {
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            foreach (var token in Tokenizer.GetTokens(text))
                _tokens.Enqueue(token);
            Dump(text, line, caller, options: Options.LineAbove);
        }

        public Token DequeueToken(int line, string caller)
        {
            Token token;
            try
            {
                token = _tokens.Dequeue();
            }
            catch (Exception exception)
            {
                Exception(exception, line, caller);
                throw;
            }
            Dump(token.Value, line, caller);
            return token;
        }

        public Term EndParse(Term term, int line, string caller)
        {
            Dump(term, line, caller, options: Options.AllState | Options.LineBelow);
            return term;
        }

        public void EnqueueToken(Token token, int line, string caller)
        {
            _tokens.Enqueue(token);
            Dump(token.Value, line, caller);
        }

        public Term NewTerm(Term term, int line, string caller)
        {
            Dump(term, line, caller, options: Options.None);
            return term;
        }

        public Op PeekOperator(int line, string caller)
        {
            var op = _operators.Peek();
            Dump(op, line, caller, options: Options.None);
            return op;
        }

        public Term PeekTerm(int line, string caller)
        {
            var term = _terms.Peek();
            Dump(term, line, caller, options: Options.None);
            return term;
        }

        public Token PeekToken(int line, string caller)
        {
            var token = _tokens.Peek();
            Dump(token.Value, line, caller, options: Options.None);
            return token;
        }

        public Op PopOperator(int line, string caller)
        {
            var op = _operators.Pop();
            Dump(op, line, caller);
            return op;
        }

        public Term PopTerm(int line, string caller)
        {
            var term = _terms.Pop();
            Dump(term, line, caller);
            return term;
        }

        public void PushOperator(Op op, int line, string caller)
        {
            _operators.Push(op);
            Dump(op, line, caller);
        }

        public void PushTerm(Term term, int line, string caller)
        {
            _terms.Push(term);
            Dump(term, line, caller);
        }

        public override string ToString() => string.Format("{0,38}  {1}\r\n{2,38}  {3}\r\n{4,38}  {5}",
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

        private void Dump(object value, int line, string caller, [CallerMemberName] string action = "", Options options = Options.AllState)
        {
#if DEBUG_PARSER
            const string format = "{3,18}{0,6}  {1,12}  {2,-18}";
            if ((options & Options.LineAbove) != 0)
            {
                DrawRuler();
                Debug.WriteLine(format, "Line", "Action", "State", "Caller");
                DrawRuler();
            }
            Debug.WriteLine(format, line, action, value, caller);
            if ((options & Options.AllState) != 0)
            {
                Debug.WriteLine(format, "", "Tokens", Say(_tokens.Select(p => p.Value)), "");
                Debug.WriteLine(format, "", "Terms", Say(_terms), "");
                Debug.WriteLine(format, "", "Operators", Say(_operators.Select(p => p.ToString())), "");
                DrawRuler();
            }

            void DrawRuler() => Debug.WriteLine(new string('_', 64) + "\r\n");
#endif
        }

        private void Exception(Exception exception, int line, string caller, [CallerMemberName] string local = "") =>
            Dump(exception.GetAllInformation(), line, caller, local);

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
