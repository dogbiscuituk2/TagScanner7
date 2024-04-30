namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

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

        public bool CaseSensitive
        {
            get => State.CaseSensitive;
            set => State.CaseSensitive = value;
        }

        private ParserState State { get; } = new ParserState();

        #endregion

        #region Private Methods

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
            if (term is Operation operation)
                PrepareOperationArgs(operation);
            return term;
        }

        private Term ParseMemberFunction(Term self) => ParseParameters(DequeueToken().Value.ToFunction(), self);

        private static Term ParseNumber(string token) =>
            token.EndsWith("L") ? new Constant<long>(long.Parse(token.TrimEnd('L'))) :
            token.EndsWith("D") ? new Constant<double>(double.Parse(token.TrimEnd('D'))) :
            token.Contains(".") ? new Constant<double>(double.Parse(token)) :
            (Term)new Constant<int>(int.Parse(token));

        private Term ParseParameters(Fn fn, Term self = null)
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
            PrepareFunctionArgs(fn, parameters);
            return NewTerm(new Function(fn, parameters.ToArray()));
        }

        private Term ParseSimpleTerm()
        {
            var token = DequeueToken();
            var match = token.Value;
            if (match == "(")
                if (PeekToken().Value.IsType())
                    return ParseCast();
                else
                {
                    PushOperator();
                    var term = NewTerm(ParseCompoundTerm());
                    PopOperator();
                    AcceptToken(")");
                    return term;
                }
            if (match.IsBoolean())
                return NewTerm(match == "true" ? Term.True : Term.False);
            if (match.IsString())
                return NewTerm(new Constant<string>(match.Substring(1, match.Length - 2)));
            if (match.IsField())
                return NewTerm(new Field(Tags.Values.Single(p => p.DisplayName == match).Tag));
            if (match.IsMonadicOperator())
                return ParseUnaryOperation(match);
            if (match.IsNumber())
                return NewTerm(ParseNumber(match.ToUpperInvariant()));
            if (match.IsParameter())
                return NewTerm(new Parameter(match.Substring(1, match.Length - 2).ToType()));
            if (match.IsFunction())
                return ParseStaticFunction(match);
            if (match.IsDateTime())
                return NewTerm(new Constant<DateTime>(DateTimeParser.ParseDateTime(match)));
            if (match.IsTimeSpan())
                return NewTerm(new Constant<TimeSpan>(DateTimeParser.ParseTimeSpan(match)));
            UnexpectedToken(token);
            return null;
        }

        private Term ParseStaticFunction(string token) => ParseParameters(token.ToFunction());
        
        private Term ParseUnaryOperation(string token)
        {
            var term = ParseSimpleTerm();
            switch (token)
            {
                case "+": case "＋":
                    term = new Positive(term);
                    break;
                case "-": case "－":
                    term =
                        term is Constant<int> cint
                        ? new Constant<int>(-cint.Value)
                        : term is Constant<double> cdouble
                        ? new Constant<double>(-cdouble.Value)
                        : (Term)new Negative(term);
                    break;
                case "!": case "not":
                    term = new Negation(term);
                    break;
                default:
                    return null;
            }
            return NewTerm(term);
        }

        private void PrepareFunctionArgs(Fn fn, List<Term> parameters)
        {
            var paramTypes = fn.ParamTypes();
            for (var index = parameters.Count; index < paramTypes.Count(); index++)
                parameters.Add(new Parameter(paramTypes[index]));
            switch (fn)
            {
                case Fn.Compare:
                case Fn.Contains:
                case Fn.ContainsX:
                case Fn.EndsWith:
                case Fn.EndsWithX:
                case Fn.Equals:
                case Fn.EqualsX:
                case Fn.IndexOf:
                case Fn.IndexOfX:
                case Fn.LastIndexOf:
                case Fn.LastIndexOfX:
                case Fn.StartsWith:
                case Fn.StartsWithX:
                    parameters[2] = CaseSensitive;
                    break;
                case Fn.Max:
                case Fn.Min:
                case Fn.Pow:
                    Cast(1, typeof(double));
                    goto case Fn.Round;

                case Fn.Concat:
                    CastAll(0, typeof(object));
                    break;

                case Fn.Format:
                case Fn.Join:
                    CastAll(1, typeof(object));
                    break;

                case Fn.Replace:
                case Fn.ReplaceX:
                    parameters[3] = CaseSensitive;
                    break;

                case Fn.Round:
                case Fn.Sign:
                    Cast(0, typeof(double));
                    break;

                case Fn.ToString:
                    Cast(0, typeof(object));
                    break;
            }

            void Cast(int index, Type type)
            {
                var term = parameters[index];
                if (term.ResultType != type)
                    parameters[index] = new Cast(type, term);
            }

            void CastAll(int first, Type type)
            {
                for (var index = first; index < parameters.Count; index++)
                    Cast(index, type);
            }
        }

        private void PrepareOperationArgs(Operation operation)
        {
            var op = operation.Op;
            if (op.IsUnary())
                return;
            var operands = operation.Operands;
            var count = operands.Count;
            var commonType = operation.CommonType;
            var adjustCase = !CaseSensitive && op.CanChain();
            for (var index = 0; index < count; index++)
            {
                var operand = operands[index];
                if (operand.ResultType != commonType)
                    operand = new Cast(commonType, operand);
                if (adjustCase)
                {
                    if (operand.ResultType == typeof(string) && !(operand is Function function && function.Fn == Fn.Upper))
                        operand = operand is Constant<string> constantString
                            ? new Constant<string>(constantString.Value.ToUpperInvariant())
                            : (Term)new Function(Fn.Upper, operand);
                }
                operands[index] = operand;
            }
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

        private TermList Consolidate(Term right, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => State.Consolidate(caller, line, right);
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
