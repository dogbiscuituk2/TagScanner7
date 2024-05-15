namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Terms;
    using Utils;
    
    public class Parser
    {
        #region Public Methods

        /// <summary>
        /// Parse an arbitrary string into a Term.
        /// </summary>
        /// <param name="program">The string to parse.</param>
        /// <param name="caseSensitive">Matching of data field & function names, type casts, operators and other syntactical elements, is always insensitive to case. 
        /// The caseSensitive value applies only to the user data, such as track titles, album names, performers, and so on.</param>
        /// <returns>The Term obtained from parsing.</returns>
        public Term Parse(string program, bool caseSensitive)
        {
            _caseSensitive = caseSensitive;
            BeginParse(program);
            var term = ParseBlock();
            -EndParse(term);
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

        #region Fields

        private bool _caseSensitive;
        private readonly ParserSpy _spy = new ParserSpy();
        private readonly Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();

        #endregion

        #region Nonterminals

        private Term ParseBlock()
        {
            Term result = null;
            while (PeekToken().Length > 0)
            {
                var term = ParseCompound();
                if (result == null)
                    result = term;
                else if (result is Block block)
                    block.Operands.Add(term);
                else
                    result = new Block(result, term);
                if (PeekToken().Value == ";")
                    DequeueToken();
                else
                    break;
            }
            return result ?? Term.Nothing;
        }

        private Term ParseCompound()
        {
            Term term;
            if (PeekToken().Value == "(")
            {
                DequeueToken();
                term = ParseCompound();
                AcceptToken(")");
            }
            else
                term = ParseTerm();

            while (PeekToken().Value.IsBinaryOperator())
            {
                var token = DequeueToken();
                var tokenRank = token.Value.Rank(false);

                while (AnyOperators())
                {
                    var op = PeekOperator();
                    if (op == 0)
                        break;
                    var priorRank = op.GetRank();
                    if (priorRank < tokenRank || priorRank == tokenRank && op.GetAssociativity() == Associativity.Right)
                        break;
                    term = Merge(term);
                }

            }
            while (AnyOperators())
            {
                var op = PeekOperator();
                if (op == 0)
                    break;
                term = Merge(term);
            }
            return term;

            Term Merge(Term right) => PrepareCompound(Consolidate(right));
        }

        private Term ParseTerm()
        {
            if (PeekToken().IsUnaryOperator())
                return new Operation(DequeueToken().Value.ToUnaryOperator(), ParseTerm());
            Term term;
            if (PeekToken().Value == "(")
            {
                DequeueToken();
                if (PeekToken().Kind == TokenKind.TypeName)
                {
                    var type = DequeueToken().Value.ToType();
                    AcceptToken(")");
                    return new Cast(type, ParseTerm());
                }
                term = ParseBlock();
                AcceptToken(")");
            }
            else
                term = ParseValue();
            while (true)
            {
                var token = PeekToken();
                if (token.Value == ".")
                {
                    DequeueToken();
                    term = ParseFunction(term);
                }
                else if (token.Kind == TokenKind.Function)
                    term = ParseFunction(term);
                else
                    break;
            }
            return term;
        }

        private Term ParseValue()
        {
            var token = DequeueToken();
            var value = token.Value;
            switch (token.Kind)
            {
                case TokenKind.Boolean: return ParseBoolean(value);
                case TokenKind.Character: return ParseCharacter(value);
                case TokenKind.DateTime: return ParseDateTime(value);
                case TokenKind.Default: return ParseDefault(value);
                case TokenKind.Field: return ParseField(value);
                case TokenKind.Function: return ParseFunction();
                case TokenKind.Number: return ParseNumber(value.ToUpperInvariant());
                case TokenKind.String: return ParseString(value);
                case TokenKind.TimeSpan: return ParseTimeSpan(value);
                case TokenKind.Variable: return ParseVariable(value);
            }
            return SyntaxError(token);
        }

        private Term ParseFunction() => ParseFunction(new List<Term>());
        private Term ParseFunction(Term self) => ParseFunction(new List<Term> { self });
        private Term ParseFunction(List<Term> operands)
        {
            var fn = DequeueToken().Value.ToFunction();
            if (PeekToken().Value == "(")
            {
                DequeueToken();
                if (PeekToken().Value != ")")
                {
                    var term = ParseCompound();
                    if (term is Block block)
                        operands.AddRange(block.Operands);
                    else
                        operands.Add(term);
                }
                AcceptToken(")");
            }
            return new Function(fn, operands.ToArray());
        }

        #endregion

        #region Terminals

        private Term ParseBoolean(string value) => value == "true";

        private Term ParseCharacter(string value) => char.Parse(value.Substring(1, value.Length - 2));

        private Term ParseDateTime(string value) => DateTimeParser.ParseDateTime(value);

        private Term ParseDefault(string value) => new Default(value.Substring(1, value.Length - 2).ToType());

        private Term ParseField(string value) => value.DisplayNameToTag();

        private Term ParseNumber(string value) =>
            value.EndsWith("UL") || value.EndsWith("LU") ? ulong.Parse(value.TrimEnd('U', 'L')) :
            value.EndsWith("D") ? double.Parse(value.TrimEnd('D')) :
            value.EndsWith("F") ? float.Parse(value.TrimEnd('F')) :
            value.EndsWith("L") ? long.Parse(value.TrimEnd('L')) :
            value.EndsWith("M") ? decimal.Parse(value.TrimEnd('M')) :
            value.EndsWith("U") ? uint.Parse(value.TrimEnd('U')) :
            value.Contains(".") ? double.Parse(value) :
            (Term)int.Parse(value);

        private Term ParseString(string value) => value.Substring(1, value.Length - 2);

        private Term ParseTimeSpan(string value) => DateTimeParser.ParseTimeSpan(value);

        private Term ParseVariable(string value)
        {
            var key = value.ToUpperInvariant();
            if (!_variables.ContainsKey(key))
                _variables.Add(key, new Variable(value));
            return _variables[key];
        }

        #endregion

        #region Helpers

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
                var adjustCase = !_caseSensitive && op.CanChain();
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
                    operands[index] = _caseSensitive;
            }
        }


        private Term SyntaxError(Token token) => throw new SyntaxErrorException($"Unexpected Token: {token.Value}");

        #endregion

        #region ParserSpy Calls

        private void BeginParse(string program, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.BeginParse(caller, line, program);
        private void EndParse(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.EndParse(caller, line, term);
        private Term NewTerm(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.NewTerm(caller, line, term);
        private object UnexpectedToken(Token token, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.UnexpectedToken(caller, line, token);

        #region Operators

        private bool AnyOperators() => _spy.AnyOperators();
        private Op PeekOperator([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.PeekOperator(caller, line);
        private Op PopOperator([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.PopOperator(caller, line);
        private void PushOperator(Op op = 0, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.PushOperator(caller, line, op);

        #endregion
        #region Terms

        private Compound Consolidate(Term right, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.Consolidate(caller, line, right);
        private Term PopTerm([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.PopTerm(caller, line);
        private void PushTerm(Term term, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.PushTerm(caller, line, term);

        #endregion
        #region Tokens

        private void AcceptToken(string expected, [CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.AcceptToken(caller, line, expected);
        private Token DequeueToken([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.DequeueToken(caller, line);
        private Token PeekToken([CallerMemberName] string caller = "", [CallerLineNumber] int line = 0) => _spy.PeekToken(caller, line);

        #endregion

        #endregion
    }
}
