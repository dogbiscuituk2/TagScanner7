namespace TagScanner.Terms
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Parser
    {
        #region Public Methods

        /// <summary>
        /// Parse an arbitrary string into a Term.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <param name="caseSensitive">Matching of data field & function names, type casts, operators and other syntactical elements, is always insensitive to case. 
        /// The caseSensitive parameter applies only to the user data, such as work titles, album names, performers, and so on.</param>
        /// <returns>The Term obtained from parsing.</returns>
        public Term Parse(string text, bool caseSensitive = false)
        {
            BeginParse(text);
            var term = ParseCompoundTerm();
            EndParse(term);
            if (!caseSensitive)
                term = term.IgnoreCase();
            return term;
        }

        /// <summary>
        ///  Parse an arbitrary string into a Term,catching any exceptions and forwarding their information.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <param name="term">The Term obtained from parsing, assuming no exceptions occurred.</param>
        /// <param name="exception">The exception that did, in fact, occur.</param>
        /// <param name="caseSensitive">Matching of data field & function names, type casts, operators and other syntactical elements, is always insensitive to case. 
        /// The caseSensitive parameter applies only to the user data, such as work titles, album names, performers, and so on.</param>
        /// <returns>True if the parsing succeeded, and the result is returned in the out parameter term.
        /// False if an exception occurred, and the exception is returned in the out parameter exception.</returns>
        public bool TryParse(string text, out Term term, out Exception exception, bool caseSensitive = false)
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

        private ParserState State { get; } = new ParserState();

        #endregion

        #region Private Methods

        private static Term[] MakeArray(Term terms) =>
            terms is TermList termList
                ? termList.Operands.ToArray()
                : terms != null
                    ? new[] { terms }
                    : Array.Empty<Term>();

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

        private Term ParseMemberFunction(Token token)
        {
            if (PeekOperator() != Op.Dot) UnexpectedToken(token);
            PopOperator();
            return NewTerm(new Function(PopTerm(), token.Value.ToFunction(), ParseParameters()));
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

        private Term[] ParseParameters()
        {
            if (!AnyTokens())
                return Array.Empty<Term>();
            if (PeekToken().Value == "(")
            {
                AcceptToken("(");
                PushOperator();
                var term = PeekToken().Value != ")" ? NewTerm(ParseCompoundTerm()) : null;
                PopOperator();
                AcceptToken(")");
                return MakeArray(term);
            }
            return MakeArray(NewTerm(ParseSimpleTerm())); // Parentheses are optional for single parameters.
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
                match.IsMemberFunction() ? ParseMemberFunction(token) :
                match.IsMonadicOperator() ? ParseUnaryOperation(match) :
                match.IsNumber() ? NewTerm(ParseNumber(match.ToUpperInvariant())) :
                match.IsParameter() ? NewTerm(new Parameter(match.Substring(1, match.Length - 2).ToType())) :
                match.IsStaticFunction() ? ParseStaticFunction(match) :
                match.IsDateTime() ? NewTerm(new Constant<DateTime>(DateTimeParser.ParseDateTime(match))) :
                match.IsTimeSpan() ? NewTerm(new Constant<TimeSpan>(DateTimeParser.ParseTimeSpan(match))) :
                (Term)UnexpectedToken(token);
        }

        private Term ParseStaticFunction(string token) => NewTerm(new Function(token.ToFunction(), ParseParameters()));

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

        //  private bool AnyTerms() => _state.AnyTerms();
        private Operation Consolidate(Term right, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.Consolidate(caller, line, right);
    //  private Term PeekTerm([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.PeekTerm(caller, line);
        private Term PopTerm([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.PopTerm(caller, line);
        private void PushTerm(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.PushTerm(caller, line, term);

        #endregion
        #region Tokens

        private void AcceptToken(string expected, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.AcceptToken(caller, line, expected);
        private bool AnyTokens() => State.AnyTokens();
        private Token DequeueToken([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.DequeueToken(caller, line);
    //  private void EnqueueToken(Token token, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _state.EnqueueToken(caller, line, token);
        private Token PeekToken([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.PeekToken(caller, line);

        #endregion

        #endregion
    }
}
