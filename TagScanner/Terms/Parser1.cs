namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Utils;

    public class Parser1
    {
        #region Public Methods

        /// <summary>
        /// Parse an arbitrary string into a Term.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <param name="caseSensitive">Matching of data field & function names, type casts, operators and other syntactical elements, is always insensitive to case. 
        /// The caseSensitive value applies only to the user data, such as track titles, album names, performers, and so on.</param>
        /// <returns>The Term obtained from parsing.</returns>
        public Term Parse(string text, bool caseSensitive)
        {
            CaseSensitive = caseSensitive;
            BeginParse(text);
            var term = ParseCompound();
            EndParse(term);
            return term;
        }

        /// <summary>
        ///  Parse an arbitrary string into a Term, catching any exceptions and forwarding their information.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <param name="term">The Term obtained from parsing, assuming no exceptions occurred.</param>
        /// <param name="exception">The exception that did, in fact, occur.</param>
        /// <param name="caseSensitive">Matching of data field & function names, type casts, operators and other syntactical elements,
        /// is always insensitive to case. The caseSensitive value applies only to the user data, such as track titles, album names,
        /// performers, and so on.</param>
        /// <returns>True if the parsing succeeded, and the result is returned in the out term.
        /// False if an exception occurred, and the exception is returned in the out exception.</returns>
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
        private readonly ParserSpy1 Spy = new ParserSpy1();
        private readonly Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();

        #endregion

        #region Private Methods

        private Term ParseArgs(Fn fn, Term self = null)
        {
            var args = new List<Term>();
            if (self != null)
                args.Add(self);
            if (AnyTokens())
                if (PeekToken().Value == "(")
                {
                    AcceptToken("(");
                    PushOperator();
                    var term = PeekToken().Value != ")" ? NewTerm(ParseCompound()) : null;
                    PopOperator();
                    AcceptToken(")");
                    if (term is TermList termList) // Compound, but not Function, Operation, etc.
                        args.AddRange(termList.Operands);
                    else if (term is Term) // ie not null
                        args.Add(term);
                }
                else
                    args.Add(NewTerm(ParseSimpleTerm())); // Parentheses are optional for single args.
            var function = (Function)NewTerm(new Function(fn, args.ToArray()));
            return PrepareCompound(function);
        }

        private Term ParseCast()
        {
            var type = DequeueToken().Value.ToType();
            AcceptToken(")");
            return NewTerm(new Cast(type, ParseSimpleTerm()));
        }

        private Term ParseCompound()
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
                    if (priorRank < tokenRank || priorRank == tokenRank && op.GetAssociativity() == Associativity.Right)
                        break;
                    term = Merge(term);
                }
                PushTerm(term);
                PushOperator(token.ToOperator(unary: false));
                term = ParseSimpleTerm();
            }
            while (AnyOperators())
            {
                var op = PeekOperator();
                if (op == 0) break;
                term = Merge(term);
            }
            if (term is Operation operation)
                PrepareCompound(operation);
            return term;

            Term Merge(Term right) => PrepareCompound(Consolidate(right));
        }

        private Term ParseMemberFunction(Term self) => ParseArgs(DequeueToken().Value.ToFunction(), self);

        private static Term ParseNumber(string token) =>
            token.EndsWith("UL") ? ulong.Parse(token.TrimEnd('U', 'L')) :
            token.EndsWith("D") ? double.Parse(token.TrimEnd('D')) :
            token.EndsWith("F") ? float.Parse(token.TrimEnd('F')) :
            token.EndsWith("L") ? long.Parse(token.TrimEnd('L')) :
            token.EndsWith("M") ? decimal.Parse(token.TrimEnd('M')) :
            token.EndsWith("U") ? uint.Parse(token.TrimEnd('U')) :
            token.Contains(".") ? double.Parse(token) :
            (Term)int.Parse(token);

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
                    var term = NewTerm(ParseCompound());
                    PopOperator();
                    AcceptToken(")");
                    return term;
                }
            if (match.IsBoolean())
                return NewTerm(match == "true");
            if (match.IsChar())
                return NewTerm(char.Parse(match.Substring(1, match.Length - 2)));
            if (match.IsString())
                return NewTerm(match.Substring(1, match.Length - 2));
            if (match.IsTrackField())
                return NewTerm(match.DisplayNameToTagInfo().Tag);
            //return NewTerm(Tags.Values.Single(p => p.DisplayName == match).Tag);
            if (match.IsListField())
                return NewTerm(new ListField(Tags.Values.Single(p => p.DisplayName == match.Substring(1)).Tag));
            if (match.IsUnaryOperator())
                return ParseUnaryOperation(match);
            if (match.IsNumber())
                return NewTerm(ParseNumber(match.ToUpperInvariant()));
            if (match.IsDefault())
                return NewTerm(new Default(match.Substring(1, match.Length - 2).ToType()));
            if (match.IsFunction())
                return ParseStaticFunction(match);
            if (match.IsDateTime())
                return NewTerm(DateTimeParser.ParseDateTime(match));
            if (match.IsTimeSpan())
                return NewTerm(DateTimeParser.ParseTimeSpan(match));
            if (match.IsName())
                return ParseVariableName(match);
            UnexpectedToken(token);
            return null;
        }

        private Term ParseStaticFunction(string token) => ParseArgs(token.ToFunction());
        
        private Term ParseUnaryOperation(string token)
        {
            var term = ParseSimpleTerm();
            switch (token.ToOperator(unary: true))
            {
                case Op.Positive:
                    term = new Positive(term);
                    break;
                case Op.Negative:
                    term =
                        term is Constant<int> cint
                        ? new Constant<int>(-cint.Value)
                        : term is Constant<double> cdouble
                        ? new Constant<double>(-cdouble.Value)
                        : (Term)new Negative(term);
                    break;
                case Op.Not:
                    term = new Negation(term);
                    break;
                default:
                    return null;
            }
            return NewTerm(term);
        }

        private Term ParseVariableName(string name)
        {
            var key = name.ToUpperInvariant();
            if (!_variables.ContainsKey(key))
                _variables.Add(key, (Variable)NewTerm(new Variable(name)));
            return _variables[key];
        }

        private Term PrepareCompound(Compound compound)
        {
            var operands = compound.Operands;
            var count = operands.Count;
            foreach (var term in operands.OfType<Compound>())
                PrepareCompound(term);
            if (compound is Function function)
                PrepareFunction(function);
            else if (compound is Operation operation)
                PrepareOperation(operation);
            return NewTerm(compound);

            void PrepareFunction(Function f)
            {
                var fn = f.Fn;
                var operandTypes = fn.OperandTypes();
                for (var index = count; index < operandTypes.Count(); index++)
                    operands.Add(new Default(operandTypes[index]));
                switch (fn)
                {
                    case Fn.Compare:
                    case Fn.Contains:
                    case Fn.ContainsX:
                    case Fn.Count:
                    case Fn.CountX:
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
                        CheckCase(2);
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
                        CheckCase(3);
                        break;

                    case Fn.Round:
                    case Fn.Sign:
                        Cast(0, typeof(double));
                        break;

                    case Fn.ToString:
                        Cast(0, typeof(object));
                        break;
                }
            }

            void PrepareOperation(Operation operation)
            {
                var op = operation.Op;
                if (op.IsAssignment())
                {
                    if (count < 2)
                        throw new ArgumentException("Missing argument(s)");
                    var type = operands[count - 1].ResultType;
                    foreach (var arg in operands.Take(count - 1))
                    {
                        if (!(arg is Variable variable))
                            throw new ArgumentException("LValue required");
                        variable.ResultType = type;
                    }
                    return;
                }
                var commonType = Utility.GetCompatibleType(operands.Select(p => p.ResultType).ToArray());
                var adjustCase = !CaseSensitive && op.CanChain();
                for (var index = 0; index < count; index++)
                {
                    var operand = operands[index];
                    if (operand.ResultType != commonType)
                        operand = new Cast(commonType, operand);
                    if (adjustCase)
                    {
                        if (operand.ResultType == typeof(string) && !(operand is Function f && f.Fn == Fn.Upper))
                            operand = operand is Constant<string> constantString
                                ? new Constant<string>(constantString.Value.ToUpperInvariant())
                                : (Term)new Function(Fn.Upper, operand);
                    }
                    operands[index] = operand;
                }
            }

            void Cast(int index, Type type)
            {
                var term = operands[index];
                if (term.ResultType != type)
                    operands[index] = new Cast(type, term);
            }

            void CastAll(int first, Type type)
            {
                for (var index = first; index < operands.Count; index++)
                    Cast(index, type);
            }

            void CheckCase(int index)
            {
                if (operands[index] is Default)
                    operands[index] = CaseSensitive;
            }
        }

        #endregion

        #region ParserState Calls

        private void BeginParse(string text, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.BeginParse(caller, line, text);
        private void EndParse(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.EndParse(caller, line, term);
        private Term NewTerm(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.NewTerm(caller, line, term);
        private object UnexpectedToken(Token token, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.UnexpectedToken(caller, line, token);

        #region Operators

        private bool AnyOperators() => Spy.AnyOperators();
        private Op PeekOperator([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.PeekOperator(caller, line);
        private Op PopOperator([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.PopOperator(caller, line);
        private void PushOperator(Op op = 0, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.PushOperator(caller, line, op);

        #endregion
        #region Terms

        private Compound Consolidate(Term right, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.Consolidate(caller, line, right);
        private Term PopTerm([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.PopTerm(caller, line);
        private void PushTerm(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.PushTerm(caller, line, term);

        #endregion
        #region Tokens

        private void AcceptToken(string expected, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.AcceptToken(caller, line, expected);
        private bool AnyTokens() => Spy.AnyTokens();
        private Token DequeueToken([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.DequeueToken(caller, line);
        private Token PeekToken([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => Spy.PeekToken(caller, line);

        #endregion

        #endregion
    }
}
