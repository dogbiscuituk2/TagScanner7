namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;

    public class Parser
    {
        #region Public Methods

        public Term Parse(string text)
        {
            Reset();
            foreach (var token in Tokenizer.GetTokens(text))
                _tokenQueue.Enqueue(token);
            AcceptTerm();
            return null;
        }

        #endregion

        #region Private Fields

        private readonly Stack<Term> _argumentStack = new Stack<Term>();
        private readonly Stack<string> _operatorStack = new Stack<string>();
        private readonly Queue<string> _tokenQueue = new Queue<string>();

        #endregion

        #region Private Methods

        private void Accept(string expected)
        {
            var actual = _tokenQueue.Dequeue();
            if (expected != actual)
                throw new FormatException($"Invalid token: expected {{{expected}}}, actual {{{actual}}}.");
        }

        private void AcceptTerm()
        {
            var token = _tokenQueue.Dequeue();
            if (token.IsMonadicOperator())
                _operatorStack.Push(token);
            else if (token.IsConstant() || token.IsField())
                _argumentStack.Push(token);
            else if (token.IsStaticFunction())
            {
                _operatorStack.Push(token);
                Accept("(");
                AcceptTermList();
                Accept(")");
            }
            else if (token == "(")
            {
                AcceptTerm();
                Accept(")");
            }
        }

        private void AcceptTermList()
        {
            while (_tokenQueue.Peek() != ")")
            {
                AcceptTerm();
                if (_tokenQueue.Peek() == ",")
                {
                    Accept(",");
                    AcceptTerm();
                }
            }
            Accept(")");
        }

        private void Reset()
        {
            _argumentStack.Clear();
            _operatorStack.Clear();
            _tokenQueue.Clear();
        }

        #endregion
    }
}
