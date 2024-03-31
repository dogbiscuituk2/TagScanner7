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
                _tokens.Enqueue(token);
            return ParseCompoundTerm();
        }

        public bool TryParse(string text, out Term term, out Exception exception)
        {
            try
            {
                term = Parse(text);
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                term = null;
                exception = ex;
                return false;
            }
        }

        #endregion

        #region Private Fields

        private readonly Stack<Op> _operators = new Stack<Op>();
        private readonly Stack<Term> _terms = new Stack<Term>();
        private readonly Queue<string> _tokens = new Queue<string>();

        #endregion

        #region Private Methods

        private void Accept(string expected)
        {
            var actual = _tokens.Dequeue();
            if (expected != actual)
                throw new FormatException($"Invalid token: expected {{{expected}}}, actual {{{actual}}}.");
        }

        private void CombineTerms(ref Term right)
        {
            var op = _operators.Pop();
            var left = _terms.Pop();
            if (left is Operation operation && operation.Op == Op.Conditional && operation.Operands[2] is Parameter)
            {
                operation.Operands[2] = right;
                right = operation;
            }
            else
                right = new Operation(op, left, right);
        }

        private Term ParseCast()
        {
            var type =  Cast.GetType(_tokens.Dequeue());
            Accept(")");
            return new Cast(type, ParseSimpleTerm());
        }

        private Term ParseCompoundTerm()
        {
            var term = ParseSimpleTerm();
            while (_tokens.Any())
            {
                var token = _tokens.Dequeue();
                if (token == ")")
                    break;
                var tokenRank = token.Rank();
                while (true)
                {
                    var op = _operators.Peek();
                    var priorRank = op.GetRank();
                    if (priorRank >= tokenRank)
                        CombineTerms(ref term);
                    else
                        break;
                }
                _terms.Push(term);
                _operators.Push(token.Operator());
                term = ParseSimpleTerm();
            }
            while (_terms.Any() && _operators.Peek() != Op.LParen)
                CombineTerms(ref term);
            if (_operators.Peek() != Op.LParen)
                _operators.Pop();
            return term;
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
            var token = _tokens.Dequeue();
            if (token == "(")
                if (_tokens.Peek().IsType())
                    return ParseCast();
                else
                {
                    _operators.Push(Op.LParen);
                    var term = ParseCompoundTerm();
                    Accept(")");
                    return term;
                }
            if (token.IsBoolean())
                return token == "true" ? Constant.True : Constant.False;
            if (token.IsChar())
                return new Constant(char.Parse(token.Substring(1, token.Length - 2)));
            if (token.IsString())
                return new Constant(token.Substring(1, token.Length - 2));
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
                if (_tokens.Peek() == ")")
                {
                    Accept(")");
                    yield break;
                }
                else
                {
                    yield return ParseCompoundTerm();
                    if (_tokens.Peek() == ",")
                        Accept(",");
                }
        }

        private void Reset()
        {
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            _operators.Push(Op.Comma);
        }

        #endregion

        #region Parse TimeSpan / DateTime

        public const string DateTimePattern = @"^\[(\d{4})-(\d\d?)\-(\d\d?)(?: " + TimePattern + @")?\]";

        private DateTime ParseDateTime(string token)
        {
            // DateTimePattern captures 8 Groups.
            // [0] is the full DateTime (unused),
            // [1] is year,
            // [2] is month,
            // [3] is day (),
            // [4] is hours,
            // [5] is minutes,
            // [6] is seconds,
            // [7] is fraction of a second, including a leading decimal point.
            var groups = Regex.Match(token, DateTimePattern).Groups;
            int year = int.Parse(groups[1].Value),
                month = int.Parse(groups[2].Value),
                day = int.Parse(groups[3].Value);
            int.TryParse(groups[4].Value, out var hours);
            int.TryParse(groups[5].Value, out var minutes);
            int.TryParse(groups[6].Value, out var seconds);
            double.TryParse(groups[7].Value, out var ms);
            return new DateTime(year, month, day, hours, minutes, seconds, (int)(ms * 1000));
        }

        public const string TimeSpanPattern = @"^\[(?:(\d+)\.)?" + TimePattern + @"\]";

        private TimeSpan ParseTimeSpan(string token)
        {
            // TimeSpan pattern captures 6 Groups.
            // [0] is the full TimeSpan (unused),
            // [1] is days,
            // [2] is hours,
            // [3] is minutes,
            // [4] is seconds,
            // [5] is fraction of a second, including a leading decimal point.
            var groups = Regex.Match(token, TimeSpanPattern).Groups;
            int.TryParse(groups[1].Value, out var days);
            int.TryParse(groups[2].Value, out var hours);
            int minutes = int.Parse(groups[3].Value),
                seconds = int.Parse(groups[4].Value);
            double.TryParse(groups[5].Value, out var ms);
            return new TimeSpan(days, hours, minutes, seconds, (int)(ms * 1000));
        }

        private const string TimePattern = @"(\d\d?)\:(\d\d?)\:(\d\d?)(\.\d+)?";

        #endregion
    }
}
