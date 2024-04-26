namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Utils;

    public class Parser
    {
        #region Public Methods

        /// <summary>
        /// Parse an arbitrary string into a Term.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <param name="caseSensitive">Matching of data field & function names, type casts, operators and other syntactical elements, is always insensitive to case. 
        /// The caseSensitive parameter applies only to the user data, such as track titles, album names, performers, and so on.</param>
        /// <returns>The Term obtained from parsing.</returns>
        public Term Parse(string text, bool caseSensitive)
        {
            CaseSensitive = caseSensitive;
            BeginParse(text);
            var term = ParseCompoundTerm();
            EndParse(term);
            return term;
        }

        /// <summary>
        ///  Parse an arbitrary string into a Term,catching any exceptions and forwarding their information.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <param name="term">The Term obtained from parsing, assuming no exceptions occurred.</param>
        /// <param name="exception">The exception that did, in fact, occur.</param>
        /// <param name="caseSensitive">Matching of data field & function names, type casts, operators and other syntactical elements, is always insensitive to case. 
        /// The caseSensitive parameter applies only to the user data, such as track titles, album names, performers, and so on.</param>
        /// <returns>True if the parsing succeeded, and the result is returned in the out parameter term.
        /// False if an exception occurred, and the exception is returned in the out parameter exception.</returns>
        public bool TryParse(string text, out Term term, out Exception exception, bool caseSensitive)
        {
            try
            {
                term = Parse(text, caseSensitive);
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

        private bool CaseSensitive;
        private ParserState State { get; } = new ParserState();

        #endregion

        #region Private Methods

        private void AdjustFunctionParameters(Fn fn, List<Term> parameters)
        {
            switch (fn)
            {
                case Fn.Compare:
                    parameters[2] = !CaseSensitive; // bool ignoreCase
                    break;
                case Fn.EndsWith:
                case Fn.Equals:
                case Fn.IndexOf:
                case Fn.StartsWith:
                    parameters[1] = GetStringComparison();
                    break;
                case Fn.Contains:
                case Fn.ContainsX:
                    parameters[2] = GetRegexOptions();
                    break;
                case Fn.Replace:
                case Fn.ReplaceX:
                    parameters[3] = GetRegexOptions();
                    break;
            }

            Term GetRegexOptions() => (int)CaseSensitive.AsRegexOptions();
            Term GetStringComparison() => (int)CaseSensitive.AsStringComparison();
        }

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
                var token = PeekToken().Value;
                if (token == ")") break;
                if (token.IsOperator()) DequeueToken();
                else token = "."; // The Dot operator is optional & implied where appropriate.
                if (token == ".")
                {
                    term = ParseMemberFunction(term);
                    continue;
                }
                var tokenRank = token.Rank(unary: false);
                while (AnyOperators())
                {
                    var op = PeekOperator();
                    if (op == 0) break;
                    var priorRank = op.GetRank();
                    if (priorRank >= tokenRank) term = Consolidate(term);
                    else break;
                }
                PushTerm(term);
                PushOperator(token.ToOperator(unary: false));
                term = ParseSimpleTerm();
            }
            while (AnyOperators())
            {
                var op = PeekOperator();
                if (op == 0) break;
                term = Consolidate(term);
            }
            return term;
        }

        private Term ParseMemberFunction(Term self)
        {
            var fn = DequeueToken().Value.ToFunction();
            var parameters = ParseParameters(fn, self);
            return NewTerm(new Function(fn, parameters));
        }

        private static Term ParseNumber(string token) =>
            token.EndsWith("L") ? new Constant<long>(long.Parse(token.TrimEnd('L'))) :
            token.EndsWith("D") ? new Constant<double>(double.Parse(token.TrimEnd('D'))) :
            token.Contains(".") ? new Constant<double>(double.Parse(token)) :
            (Term)new Constant<int>(int.Parse(token));

        private Term[] ParseParameters(Fn fn, Term self = null)
        {
            var parameters = new List<Term>();
            if (self != null)
                parameters.Add(self);
            if (AnyTokens() && !PeekToken().Value.IsBinaryOperator())
                if (PeekToken().Value == "(")
                {
                    AcceptToken("(");
                    PushOperator();
                    var term = PeekToken().Value != ")" ? NewTerm(ParseCompoundTerm()) : null;
                    PopOperator();
                    AcceptToken(")");
                    if (term is TermList termList)
                        parameters.AddRange(termList.Operands);
                    else if (term is Term)
                        parameters.Add(term);
                }
                else
                    parameters.Add(NewTerm(ParseSimpleTerm())); // Parentheses are optional for single parameters.
            var paramTypes = fn.ParamTypes();
            for (var index = parameters.Count; index < paramTypes.Count(); index++)
                parameters.Add(new Parameter(paramTypes[index]));
            AdjustFunctionParameters(fn, parameters);
            return parameters.ToArray();
        }

        private Term ParseSimpleTerm()
        {
            var token = DequeueToken();
            var match = token.Value;
            if (match == "(")
                if (PeekToken().Value.IsType()) return ParseCast();
                else
                {
                    PushOperator();
                    var term = NewTerm(ParseCompoundTerm());
                    PopOperator();
                    AcceptToken(")");
                    return term;
                }
            return
                match.IsBoolean() ? NewTerm(match == "true" ? Term.True : Term.False) :
                match.IsChar() ? NewTerm(new Constant<char>(char.Parse(match.Substring(1, match.Length - 2)))) :
                match.IsString() ? NewTerm(new Constant<string>(match.Substring(1, match.Length - 2))) :
                match.IsField() ? NewTerm(new Field(Tags.Values.Single(p => p.DisplayName == match).Tag)) :
                match.IsMonadicOperator() ? ParseUnaryOperation(match) :
                match.IsNumber() ? NewTerm(ParseNumber(match.ToUpperInvariant())) :
                match.IsParameter() ? NewTerm(new Parameter(match.Substring(1, match.Length - 2).ToType())) :
                match.IsStaticFunction() ? ParseStaticFunction(match) :
                match.IsDateTime() ? NewTerm(new Constant<DateTime>(DateTimeParser.ParseDateTime(match))) :
                match.IsTimeSpan() ? NewTerm(new Constant<TimeSpan>(DateTimeParser.ParseTimeSpan(match))) :
                (Term)UnexpectedToken(token);
        }

        private Term ParseStaticFunction(string token)
        {
            var fn = token.ToFunction();
            var parameters = ParseParameters(fn);
            return NewTerm(new Function(fn, parameters));
        }

        private Term ParseUnaryOperation(string token)
        {
            var term = ParseSimpleTerm();
            switch (token)
            {
                case "+": case "＋": return NewTerm(new Positive(term));
                case "-": case "－": return NewTerm(new Negative(term));
                case "!": case "not": return NewTerm(new Negation(term));
            }
            return null;
        }

        #endregion

        #region ParserState Calls

        private void BeginParse(string text, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.BeginParse(caller, line, text);
        private void EndParse(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.EndParse(caller, line, term);
        private Term NewTerm(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.NewTerm(caller, line, term);
        private object UnexpectedToken(Token token, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.UnexpectedToken(caller, line, token);

        #region Operators

        private bool AnyOperators() => State.AnyOperators();
        private Op PeekOperator([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.PeekOperator(caller, line);
        private Op PopOperator([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.PopOperator(caller, line);
        private void PushOperator(Op op = 0, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.PushOperator(caller, line, op);

        #endregion
        #region Terms

        private Operation Consolidate(Term right, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.Consolidate(caller, line, right);
        private Term PopTerm([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.PopTerm(caller, line);
        private void PushTerm(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.PushTerm(caller, line, term);

        #endregion
        #region Tokens

        private void AcceptToken(string expected, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.AcceptToken(caller, line, expected);
        private bool AnyTokens() => State.AnyTokens();
        private Token DequeueToken([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.DequeueToken(caller, line);
        private Token PeekToken([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.PeekToken(caller, line);

        #endregion

        #endregion
    }
}
