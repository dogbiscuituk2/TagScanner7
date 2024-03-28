namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Parser
    {
        #region Public Methods

        public Term Parse(string text)
        {
            Reset();
            foreach (var token in Tokens.GetTokens(text))
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

        private Term ParseCompoundTerm()
        {
            var term = ParseSimpleTerm();
            var token = _tokenQueue.Dequeue();
            while (token.IsOperator())
            {
                term = new Operation(token, term, ParseSimpleTerm());
                token = _tokenQueue.Dequeue();
            }
            return term;
        }

        private DateTime ParseDateTime(string token)
        {
            // DateTimePattern captures 8 Groups.
            // [0] is the full DateTime (unused),
            // [1] is year,
            // [2] is month,
            // [3] is day,
            // [4] is hours,
            // [5] is minutes,
            // [6] is seconds,
            // [7] is fraction of a second, including a leading decimal point.
            var groups = Regex.Match(token, Tokens.DateTimePattern).Groups;
            int year = int.Parse(groups[1].Value),
                month = int.Parse(groups[2].Value),
                day = int.Parse(groups[3].Value);
            int.TryParse(groups[4].Value, out var hours);
            int.TryParse(groups[5].Value, out var minutes);
            int.TryParse(groups[6].Value, out var seconds);
            double.TryParse(groups[7].Value, out var ms);
            return new DateTime(year, month, day, hours, minutes, seconds, (int)(ms * 1000));
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

        private Term ParseSimpleTerm()
        {
            var token = _tokenQueue.Dequeue();
            if (token == "(")
                if (_tokenQueue.Peek().IsType())
                    return ParseCast();
                else
                {
                    var term = ParseCompoundTerm();
                    Accept(")");
                    return term;
                }
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
            // DateTime & TimeSpan constants involve expensive Regex pattern matching,
            // and in all probability, are relatively infrequent; hence these are checked last.
            if (token.IsDateTime())
                return new Constant(ParseDateTime(token));
            if (token.IsTimeSpan())
                return new Constant(ParseTimeSpan(token));
            throw new FormatException("Whoooops!");
        }

        private Function ParseStaticFunction(string token)
        {
            Accept("(");
            return new Function(token, ParseTerms().ToArray());
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

        private TimeSpan ParseTimeSpan(string token)
        {
            // TimeSpan pattern captures 6 Groups.
            // [0] is the full DateTime (unused),
            // [1] is days,
            // [2] is hours,
            // [3] is minutes,
            // [4] is seconds,
            // [5] is fraction of a second, including a leading decimal point.
            var groups = Regex.Match(token, Tokens.TimeSpanPattern).Groups;
            int.TryParse(groups[1].Value, out var days);
            int.TryParse(groups[2].Value, out var hours);
            int minutes = int.Parse(groups[3].Value),
                seconds = int.Parse(groups[4].Value);
            double.TryParse(groups[5].Value, out var ms);
            return new TimeSpan(days, hours, minutes, seconds, (int)(ms * 1000));
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
