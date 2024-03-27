namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Parser
    {
        #region Public Methods

        public Term Parse(string text)
        {
            Reset();
            foreach (var token in Tokenizer.GetTokens(text))
                _tokenQueue.Enqueue(token);
            return ParseTerm();
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

        private Term ParseMonad(string token)
        {
            var term = ParseTerm();
            switch (token)
            {
                case "+": return new Positive(term);
                case "-": return new Negative(term);
                case "!": return new Negation(term);
            }
            return null;
        }

        private object ParseNumber(string token) =>
            token.EndsWith("UL") || token.EndsWith("LU") ? ulong.Parse(token) :
            token.EndsWith("U") ? ulong.Parse(token) :
            token.EndsWith("M") ? decimal.Parse(token) :
            token.EndsWith("L") ? long.Parse(token) :
            token.EndsWith("F") ? float.Parse(token) :
            token.EndsWith("D") || token.Contains(".") ? double.Parse(token) :
            (object) int.Parse(token);

        private Function ParseStaticFunction(string token)
        {
            Accept("(");
            return new Function(token, ParseTerms().ToArray());
        }


        private Term ParseTerm()
        {
            var token = _tokenQueue.Dequeue();
            if (token.IsBoolean())
                return token == "true" ? Constant.True : Constant.False;
            if (token.IsChar())
                return new Constant(char.Parse(token.Substring(1, token.Length - 2)));
            if (token.IsField())
                return new Field(Tags.ToTag(token));
            if (token.IsMonadicOperator())
                return ParseMonad(token);
            if (token.IsNumber())
                return new Constant(ParseNumber(token.ToUpperInvariant()));
            if (token.IsStaticFunction())
                return ParseStaticFunction(token);
            if (token == "(")
            {
            }
        }

        private IEnumerable<Term> ParseTerms()
        {
            while (true)
                if (_tokenQueue.Peek() == ")")
                {
                    Accept(")");
                    yield break;
                }
                else
                {
                    yield return ParseTerm();
                    if (_tokenQueue.Peek() == ",")
                        Accept(",");
                }
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
