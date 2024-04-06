﻿namespace TagScanner.Terms
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
        public void BeginParse(string caller, int line, string text) => Process(caller, line, p => Reset(text));
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
        public object SyntaxError(string caller, int line, Token token) => Process(caller, line, p => SyntaxError(token));

        #endregion

        #region Private Fields

        private readonly Stack<Op> _operators = new Stack<Op>();
        private readonly Stack<Term> _terms = new Stack<Term>();
        private readonly Queue<Token> _tokens = new Queue<Token>();
        private bool _headerShown;

        #endregion

        #region Private Methods

        private object AcceptToken(string expected)
        {
            var token = _tokens.Dequeue();
            return token.Value == expected ? token : SyntaxError(token, expected);
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
            Debug.WriteLine(format, string.Empty, string.Empty, "Tokens", Say(_tokens.Select(p => p.Value)));
            Debug.WriteLine(format, string.Empty, string.Empty, "Terms", Say(_terms));
            Debug.WriteLine(format, string.Empty, string.Empty, "Operators", Say(_operators.Select(p => p.ToString())));

            void DrawLine() => Debug.WriteLine(new string('_', 80) + "\r\n");
#endif
        }

        private Term EndParse(Term term)
        {
            if (AnyTokens())
                SyntaxError(_tokens.Peek());
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
            Dump(caller, line, value, action);
            return value;
        }

        private string Reset(string text)
        {
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            _headerShown = false;
            foreach (var token in Tokenizer.GetTokens(text))
                _tokens.Enqueue(token);
            return text;
        }

        private static object Say(IEnumerable<object> s) => s.Any() ? s.Aggregate((p, q) => $"{p} {q}") : string.Empty;

        private static object SyntaxError(Token token, string expected = "")
        {
            throw new FormatException(string.IsNullOrWhiteSpace(expected)
                ? $"Unexpected token at index {token.Index}: {token}."
                : $"Unexpected token at index {token.Index}: expected {expected}, actual {token}.");
        }

        #endregion
    }
}
