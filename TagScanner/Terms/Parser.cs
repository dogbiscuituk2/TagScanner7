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
            return ParseSimpleTerm();
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

        private Term ParseCast()
        {
            var type = Type.GetType(_tokenQueue.Dequeue());
            Accept(")");
            return new Cast(type, ParseSimpleTerm());
        }

        private Term ParseMonad(string token)
        {
            var term = ParseSimpleTerm();
            switch (token)
            {
                case "+": return new Positive(term);
                case "-": return new Negative(term);
                case "!": return new Negation(term);
            }
            return null;
        }

        private object ParseNumber(string token) =>
            token.EndsWith("UL") || token.EndsWith("LU") ? ulong.Parse(token.TrimEnd('U', 'L')) :
            token.EndsWith("U") ? uint.Parse(token.TrimEnd('U')) :
            token.EndsWith("M") ? decimal.Parse(token.TrimEnd('M')) :
            token.EndsWith("L") ? long.Parse(token.TrimEnd('L')) :
            token.EndsWith("F") ? float.Parse(token.TrimEnd('F')) :
            token.EndsWith("D") ? double.Parse(token.TrimEnd('D')) :
            token.Contains(".") ? double.Parse(token) :
            (object) int.Parse(token);

        private Function ParseStaticFunction(string token)
        {
            Accept("(");
            return new Function(token, ParseTerms().ToArray());
        }

        private Term ParseCompoundTerm()
        {
            var term = ParseCompoundTerm();
            Accept(")");
            return term;
        }

        private Term ParseSimpleTerm()
        {
            var token = _tokenQueue.Dequeue();
            if (token.IsBoolean())
                return token == "true" ? Constant.True : Constant.False;
            if (token.IsChar())
                return new Constant(char.Parse(token.Substring(1, token.Length - 2)));
            if (token.IsField())
                return new Field(Tags.Values.Single(p => p.DisplayName == token).Tag);
            if (token.IsMonadicOperator())
                return ParseMonad(token);
            if (token.IsNumber())
                return new Constant(ParseNumber(token.ToUpperInvariant()));
            if (token.IsStaticFunction())
                return ParseStaticFunction(token);
            if (token == "(")
                if (_tokenQueue.Peek().IsType())
                    return ParseCast();
                else
                {
                    var term = ParseCompoundTerm();
                    Accept(")");
                    return term;
                }
            throw new FormatException("Whoooops!");
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
                    yield return ParseSimpleTerm();
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
