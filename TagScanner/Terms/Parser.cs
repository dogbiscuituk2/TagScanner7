namespace TagScanner.Terms
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    public class Parser
    {
        #region Public Methods

        public Term Parse(string text)
        {
            BeginParse(text);
            var term = ParseCompoundTerm();
            EndParse(term);
            return term;
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

        #region Private Properties

        private readonly ParserState _state = new ParserState();

        #endregion

        #region Private Methods

        private void Accept(string expected)
        {
            var token = DequeueToken();
            var actual = token.Value;
            if (expected != actual)
                SyntaxError(token.Index, actual, expected);
        }

        private Term ConsolidateTerms(Term right)
        {
            var op = PopOperator();
            var left = PopTerm();
            if (left is Operation operation && operation.Op == Op.Conditional && operation.Operands[2] is Parameter)
            {
                operation.Operands[2] = right;
                return NewTerm(operation);
            }
            if (op == Op.Comma)
            {
                if (left is TermList termList)
                {
                    termList.Operands.Add(right);
                    return NewTerm(termList);
                }
                return NewTerm(new TermList(left, right));
            }
            return NewTerm(new Operation(op, left, right));
        }

        private Term ParseCast()
        {
            var type = DequeueToken().Value.ToType();
            Accept(")");
            return NewTerm(new Cast(type, ParseSimpleTerm()));
        }

        private Term ParseCompoundTerm()
        {
            var term = ParseSimpleTerm();
            while (AnyTokens())
            {
                if (PeekToken().Value == ")")
                    break;
                var token = DequeueToken().Value;
                var tokenRank = token.Rank(unary: false);
                while (AnyOperators())
                {
                    var op = PeekOperator();
                    var priorRank = op.GetRank();
                    if (priorRank >= tokenRank)
                        term = ConsolidateTerms(term);
                    else
                        break;
                }
                PushTerm(term);
                PushOperator(token.ToOperator(unary: false));
                term = ParseSimpleTerm();
            }
            while (AnyTerms())
                term = ConsolidateTerms(term);
            return term;
        }

        private object ParseNumber(string token) =>
            token.EndsWith("UL") || token.EndsWith("LU")
            ? ulong.Parse(token.TrimEnd('U', 'L')) :
            token.EndsWith("U") ? uint.Parse(token.TrimEnd('U')) :
            token.EndsWith("M") ? decimal.Parse(token.TrimEnd('M')) :
            token.EndsWith("L") ? long.Parse(token.TrimEnd('L')) :
            token.EndsWith("F") ? float.Parse(token.TrimEnd('F')) :
            token.EndsWith("D") ? double.Parse(token.TrimEnd('D')) :
            token.Contains(".") ? double.Parse(token) :
            (object)int.Parse(token);

        private Term ParseSimpleTerm()
        {
            var token = DequeueToken();
            var match = token.Value;
            if (match == "(")
                if (PeekToken().Value.IsType())
                    return ParseCast();
                else
                {
                    PushOperator(Op.LParen);
                    var term = ParseCompoundTerm();
                    Accept(")");
                    return term;
                }
            if (match.IsBoolean())
                return NewTerm(match == "true" ? Term.True : Term.False);
            if (match.IsChar())
                return NewTerm(new Constant<char>(char.Parse(match.Substring(1, match.Length - 2))));
            if (match.IsString())
                return NewTerm(new Constant<string>(match.Substring(1, match.Length - 2)));
            if (match.IsField())
                return NewTerm(new Field(Tags.Values.Single(p => p.DisplayName == match).Tag));
            if (match.IsMonadicOperator())
                return ParseUnaryOperation(match);
            if (match.IsNumber())
                switch (ParseNumber(match.ToUpperInvariant()))
                {
                    case decimal money: return new Constant<decimal>(money);
                    case double d: return new Constant<double>(d);
                    case float f: return new Constant<float>(f);
                    case int i: return new Constant<int>(i);
                    case long l: return new Constant<long>(l);
                    case uint u: return new Constant<uint>(u);
                    case ulong ul: return new Constant<ulong>(ul);
                }
            if (match.IsParameter())
                return new Parameter(match.Substring(1, match.Length - 2).ToType());
            if (match.IsStaticFunction())
                return ParseStaticFunction(match);
            // DateTime & TimeSpan constants involve expensive Regex pattern matching,
            // and in all probability, are relatively infrequent; hence these are checked last.
            if (match.IsDateTime())
                return NewTerm(new Constant<DateTime>(ParseDateTime(match)));
            if (match.IsTimeSpan())
                return NewTerm(new Constant<TimeSpan>(ParseTimeSpan(match)));
            if (match == "?")
                return Term.Nothing;
            SyntaxError(token.Index, token.Value);
            return null;
        }

        private Term ParseStaticFunction(string token)
        {
            Accept("(");
            PushOperator(Op.LParen);
            Term term = null;
            if (PeekToken().Value != ")")
                term = NewTerm(ParseCompoundTerm());
            PopOperator();
            Accept(")");
            return NewTerm(new Function(token, term is TermList termList ? termList.Operands.ToArray() : new[] { term }));
        }

        private Term ParseUnaryOperation(string token)
        {
            var term = ParseSimpleTerm();
            switch (token)
            {
                case "+": return NewTerm(new Positive(term));
                case "-": return NewTerm(new Negative(term));
                case "!": return NewTerm(new Negation(term));
            }
            return null;
        }

        private static void SyntaxError(int index, string actual, string expected = "") =>
            throw new FormatException(string.IsNullOrWhiteSpace(expected)
            ? $"Unexpected token at index {index}: {{{actual}}}."
            : $"Unexpected token at index {index}: expected {{{expected}}}, actual {{{actual}}}.");
        
        #endregion

        #region Parse TimeSpan / DateTime

        public const string DateTimePattern = @"^\[(\d{4})-(\d\d?)\-(\d\d?)(?: " + TimePattern + @")?\]";

        private static DateTime ParseDateTime(string token)
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

        private static TimeSpan ParseTimeSpan(string token)
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
            int hours = int.Parse(groups[2].Value),
                minutes = int.Parse(groups[3].Value);
            int.TryParse(groups[4].Value, out var seconds);
            double.TryParse(groups[5].Value, out var ms);
            return new TimeSpan(days, hours, minutes, seconds, (int)(ms * 1000));
        }

        private const string TimePattern = @"(\d\d?)\:(\d\d?)(?:\:(\d\d?)(\.\d+)?)?";

        #endregion

        #region Parser State

        private void BeginParse(string text, [CallerLineNumber] int line = 0) => _state.BeginParse(text, line);
        private void EndParse(Term term, [CallerLineNumber] int line = 0) => _state.EndParse(term, line);
        private Term NewTerm(Term term, [CallerLineNumber] int line = 0, [CallerMemberName] string member = "") => _state.NewTerm(term, line, member);

        #region Operators

        private bool AnyOperators() => _state.AnyOperators();
        private Op PeekOperator([CallerLineNumber] int line = 0) => _state.PeekOperator(line);
        private Op PopOperator([CallerLineNumber] int line = 0) => _state.PopOperator(line);
        private void PushOperator(Op op, [CallerLineNumber] int line = 0) => _state.PushOperator(op, line);

        #endregion
        #region Terms

        private bool AnyTerms() => _state.AnyTerms();
        private Term PeekTerm([CallerLineNumber] int line = 0) => _state.PeekTerm(line);
        private Term PopTerm([CallerLineNumber] int line = 0) => _state.PopTerm(line);
        private void PushTerm(Term term, [CallerLineNumber] int line = 0) => _state.PushTerm(term, line);

        #endregion
        #region Tokens

        private bool AnyTokens() => _state.AnyTokens();
        private Token DequeueToken([CallerLineNumber] int line = 0) => _state.DequeueToken(line);
        private void EnqueueToken(Token token, [CallerLineNumber] int line = 0) => _state.EnqueueToken(token, line);
        private Token PeekToken([CallerLineNumber] int line = 0) => _state.PeekToken(line);

        #endregion

        #endregion
    }
}
