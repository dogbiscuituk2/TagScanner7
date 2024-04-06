﻿namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

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

        #region Private Fields

        private readonly ParserState _state = new ParserState();

        #endregion

        #region Private Methods

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

        private static Term[] MakeArray(Term terms) => terms is TermList termList ? termList.Operands.ToArray() :
            terms is Term term ? new[] { term } :
            Array.Empty<Term>();

        private Term ParseCast()
        {
            var type = DequeueToken().Value.ToType();
            AcceptToken(")");
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
                    if (op == Op.LParen)
                        break;
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
            while (AnyOperators())
            {
                var op = PeekOperator();
                if (op == Op.LParen)
                    break;
                term = ConsolidateTerms(term);
            }
            return term;
        }

        private static Term ParseNumber(string token) =>
            token.EndsWith("UL") ||
            token.EndsWith("LU") ? new Constant<ulong>(ulong.Parse(token.TrimEnd('U', 'L'))) :
            token.EndsWith("U") ? new Constant<uint>(uint.Parse(token.TrimEnd('U'))) :
            token.EndsWith("M") ? new Constant<decimal>(decimal.Parse(token.TrimEnd('M'))) :
            token.EndsWith("L") ? new Constant<long>(long.Parse(token.TrimEnd('L'))) :
            token.EndsWith("F") ? new Constant<float>(float.Parse(token.TrimEnd('F'))) :
            token.EndsWith("D") ? new Constant<double>(double.Parse(token.TrimEnd('D'))) :
            token.Contains(".") ? new Constant<double>(double.Parse(token)) :
            (Term)new Constant<int>(int.Parse(token));

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
                    PopOperator();
                    AcceptToken(")");
                    return term;
                }
            return
                match.IsBoolean() ? NewTerm(match == "true" ? Term.True : Term.False) :
                match.IsChar() ? NewTerm(new Constant<char>(char.Parse(match.Substring(1, match.Length - 2)))) :
                match.IsString() ? NewTerm(new Constant<string>(match.Substring(1, match.Length - 2))) :
                match.IsField() ? NewTerm(new Field(Tags.Values.Single(p => p.DisplayName == match).Tag)) :
                match.IsMemberFunction() ? ParseMemberFunction(token) :
                match.IsMonadicOperator() ? ParseUnaryOperation(match) :
                match.IsNumber() ? NewTerm(ParseNumber(match.ToUpperInvariant())) :
                match.IsParameter() ? NewTerm(new Parameter(match.Substring(1, match.Length - 2).ToType())) :
                match.IsStaticFunction() ? ParseStaticFunction(match) :
                match.IsDateTime() ? NewTerm(new Constant<DateTime>(DateTimeParser.ParseDateTime(match))) :
                match.IsTimeSpan() ? NewTerm(new Constant<TimeSpan>(DateTimeParser.ParseTimeSpan(match))) :
                match == "?" ? NewTerm(Term.Nothing) :
                (Term)SyntaxError(token);
        }

        private Term ParseMemberFunction(Token token)
        {
            if (PeekOperator() != Op.Dot)
                SyntaxError(token);
            PopOperator();
            return NewTerm(new Function(PopTerm(), token.Value, ParseParameters()));
        }

        private Term[] ParseParameters()
        {
            AcceptToken("(");
            PushOperator(Op.LParen);
            Term terms = null;
            if (PeekToken().Value != ")")
                terms = NewTerm(ParseCompoundTerm());
            PopOperator();
            AcceptToken(")");
            return MakeArray(terms);
        }

        private Term ParseStaticFunction(string token) => NewTerm(new Function(token, ParseParameters()));

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

        #endregion

        #region ParserState Calls

        private void BeginParse(string text, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.BeginParse(caller, line, text);
        private void EndParse(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.EndParse(caller, line, term);
        private Term NewTerm(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.NewTerm(caller, line, term);
        private object SyntaxError(Token token, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.SyntaxError(caller, line, token);

        #region Operators

        private bool AnyOperators() => _state.AnyOperators();
        private Op PeekOperator([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.PeekOperator(caller, line);
        private Op PopOperator([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.PopOperator(caller, line);
        private void PushOperator(Op op, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.PushOperator(caller, line, op);

        #endregion
        #region Terms

    //  private bool AnyTerms() => _state.AnyTerms();
    //  private Term PeekTerm([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.PeekTerm(caller, line);
        private Term PopTerm([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.PopTerm(caller, line);
        private void PushTerm(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.PushTerm(caller, line, term);

        #endregion
        #region Tokens

        private void AcceptToken(string expected, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.AcceptToken(caller, line, expected);
        private bool AnyTokens() => _state.AnyTokens();
        private Token DequeueToken([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.DequeueToken(caller, line);
    //  private void EnqueueToken(Token token, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.EnqueueToken(caller, line, token);
        private Token PeekToken([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.PeekToken(caller, line);

        #endregion

        #endregion
    }
}
