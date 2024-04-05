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

        public void BeginParse(string caller, int line, string text) => Process(caller, line, p => Reset(text), Options.All);
        public Token DequeueToken(string caller, int line) => (Token)Process(caller, line, p => _tokens.Dequeue());
        public Term EndParse(string caller, int line, Term term) { Process(caller, line, p => term); return term; }
        public void EnqueueToken(string caller, int line, Token token) => Process(caller, line, p => { _tokens.Enqueue(token); return token; });
        public Term NewTerm(string caller, int line, Term term) { Process(caller, line, p => term, 0); return term; }
        public Op PeekOperator(string caller, int line) => (Op)Process(caller, line, p => _operators.Peek(), 0);
        public Term PeekTerm(string caller, int line) => (Term)Process(caller, line, p => _terms.Peek(), 0);
        public Token PeekToken(string caller, int line) => (Token)Process(caller, line, p => _tokens.Peek(), 0);
        public Op PopOperator(string caller, int line) => (Op)Process(caller, line, p => _operators.Pop());
        public Term PopTerm(string caller, int line) => (Term)Process(caller, line, p => _terms.Pop());
        public void PushOperator(string caller, int line, Op op) => Process(caller, line, p => { _operators.Push(op); return op; });
        public void PushTerm(string caller, int line, Term term) => Process(caller, line, p => { _terms.Push(term); return term; });

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

        private void Dump(string caller, int line, object value, Options options = Options.State, [CallerMemberName] string action = "")
        {
#if DEBUG_PARSER
            const string format = "{0,17}{1,6}  {2,12}  {3}";
            if ((options & Options.Heading) != 0)
            {
                DrawRuler();
                Debug.WriteLine(format, "Caller", "Line", "Action", "Value");
                DrawRuler();
            }
            Debug.WriteLine(format, caller, line, action, value);
            if ((options & Options.State) != 0)
            {
                Debug.WriteLine(format, "", "", "Tokens", Say(_tokens.Select(p => p.Value)));
                Debug.WriteLine(format, "", "", "Terms", Say(_terms));
                Debug.WriteLine(format, "", "", "Operators", Say(_operators.Select(p => p.ToString())));
                DrawRuler();
            }

            void DrawRuler() => Debug.WriteLine(new string('_', 80) + "\r\n");
#endif
        }

        private void Exception(string caller, int line, Exception exception, [CallerMemberName] string action = "") =>
            Dump(caller, line, exception.GetAllInformation(), Options.State, action);

        private object Process(string caller, int line, Func<object, object> process, Options options = Options.State, object value = null,
            [CallerMemberName] string action = "")
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
            Dump(caller, line, value, options, action);
            return value;
        }

        private string Reset(string text)
        {
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            foreach (var token in Tokenizer.GetTokens(text))
                _tokens.Enqueue(token);
            return text;
        }

        private static object Say(IEnumerable<object> s) => s.Any() ? s.Aggregate((p, q) => $"{p} {q}") : string.Empty;

        #endregion

        #region Private Types

        [Flags] private enum Options { None, State, Heading, All }

        #endregion
    }
}
