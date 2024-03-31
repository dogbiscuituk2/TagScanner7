﻿namespace TagScanner.Terms
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
        private readonly Queue<Token> _tokens = new Queue<Token>();

        #endregion

        #region Private Methods

        private void Accept(string expected)
        {
            var token = _tokens.Dequeue();
            var actual = token.Value;
            if (expected != actual)
                SyntaxError(token.Index, actual, expected);
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
            else if (op == Op.Comma)
            {
                if (left is TermList termList)
                {
                    termList.Operands.Add(right);
                    right = termList;
                }
                else
                {
                    right = new TermList(left, right);
                }
            }
            else
            {
                right = new Operation(op, left, right);
            }
        }

        private Term ParseCast()
        {
            var type =  Cast.GetType(_tokens.Dequeue().Value);
            Accept(")");
            return new Cast(type, ParseSimpleTerm());
        }

        private Term ParseCompoundTerm()
        {
            var term = ParseSimpleTerm();
            while (_tokens.Any())
            {
                var token = _tokens.Dequeue().Value;
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
            var match = token.Value;
            if (match == "(")
                if (_tokens.Peek().Value.IsType())
                    return ParseCast();
                else
                {
                    _operators.Push(Op.LParen);
                    var term = ParseCompoundTerm();
                    Accept(")");
                    return term;
                }
            if (match.IsBoolean())
                return match == "true" ? Constant.True : Constant.False;
            if (match.IsChar())
                return new Constant(char.Parse(match.Substring(1, match.Length - 2)));
            if (match.IsString())
                return new Constant(match.Substring(1, match.Length - 2));
            if (match.IsField())
                return new Field(Tags.Values.Single(p => p.DisplayName == match).Tag);
            if (match.IsMonadicOperator())
                return ParseMonad(match);
            if (match.IsNumber())
                return new Constant(ParseNumber(match.ToUpperInvariant()));
            if (match.IsStaticFunction())
                return ParseStaticFunction(match);
            // DateTime & TimeSpan constants involve expensive Regex pattern matching,
            // and in all probability, are relatively infrequent; hence these are checked last.
            if (match.IsDateTime())
                return new Constant(ParseDateTime(match));
            if (match.IsTimeSpan())
                return new Constant(ParseTimeSpan(match));
            SyntaxError(token.Index, token.Value);
            return null;
        }

        private Function ParseStaticFunction(string token)
        {
            Accept("(");
            _operators.Push(Op.LParen);
            Term term = null;
            if (_tokens.Peek().Value != ")")
                term = ParseCompoundTerm();
            _operators.Pop();
            Accept(")");
            return new Function(token, term is TermList termList ? termList.Operands.ToArray() : new[] { term });
        }

        private IEnumerable<Term> ParseTerms()
        {
            while (true)
                if (_tokens.Peek().Value == ")")
                {
                    Accept(")");
                    yield break;
                }
                else
                {
                    yield return ParseCompoundTerm();
                    if (_tokens.Peek().Value == ",")
                        Accept(",");
                }
        }

        private void Reset()
        {
            _tokens.Clear();
            _terms.Clear();
            _operators.Clear();
            _operators.Push(Op.LParen); ;
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
    }
}
