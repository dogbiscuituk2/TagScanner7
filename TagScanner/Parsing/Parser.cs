﻿namespace TagScanner.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using Models;
    using Terms;

    /// <summary>
    /// Syntactic analyzer.
    /// </summary>
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
        public static Term Parse(string program, bool caseSensitive) => new Parser().DoParse(program, caseSensitive);

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
        public static bool TryParse(string text, out Term term, out Exception exception, bool caseSensitive) =>
            new Parser().DoTryParse(text, out term, out exception, caseSensitive);

        #endregion

        #region Fields

        private bool _caseSensitive;
        private readonly ParserSpy _spy = new ParserSpy();

        #endregion

        #region Nonterminals

        private Term ParseBlock()
        {
            PushOperator();
            PushTerm(new EmptyTerm());
            while (PeekToken() != null)
            {
                while (PeekToken().Kind == TokenKind.Label)
                    Add(ParseLabel());
                if (PeekToken() == null)
                    break;
                Add(ParseStatement());
                var token = PeekToken().Value;
                if (token == "," || token == ";")
                    PopToken();
                else
                    break;
            }
            PopOperator();
            return PopTerm();

            void Add(Term term)
            {
                var pop = PopTerm();
                if (pop is EmptyTerm)
                    PushTerm(term);
                else if (pop is Block block)
                {
                    block.Operands.Add(term);
                    PushTerm(block);
                }
                else
                    PushTerm(new Block(pop, term));
            }
        }

        private Catch ParseCatch()
        {
            AcceptToken(Keywords.Catch);
            AcceptToken("(");
            var type = PopToken().Value.ToType();
            var variable = ParseVariable(PopToken().Value);
            AcceptToken(")");
            var bodyTerm = ParseBlock();
            var catchBlock = new Catch(type, variable, bodyTerm);
            return catchBlock;
        }

        private Term ParseCompound()
        {
            Op op;
            Term term = ParseTerm();
            while (PeekToken().IsBinaryOperator())
            {
                op = PopToken().ToBinaryOperator();
                ApplyOperators(op);
                PushTerm(term);
                PushOperator(op);
                term = ParseTerm();
            }
            ApplyOperators(Op.End);
            return term;

            void ApplyOperators(Op newOp)
            {
                var newRank = newOp.GetRank();
                while (AnyOperators())
                {
                    var oldOp = PeekOperator();
                    var oldRank = oldOp.GetRank();
                    if (oldOp == Op.End || oldOp == Op.Then || oldRank == Rank.Conditional && newOp == Op.Then)
                        break;
                    if (oldRank < newRank || oldRank == newRank && oldOp.GetAssociativity() == Associativity.Right)
                        break;
                    term = Consolidate(term);
                }
            }
        }

        private Loop ParseDo()
        {
            var loop = BeginLoop();
            if (PeekToken().Value == Keywords.While)
            {
                PopToken();
                loop.Operands[0] = ParseBlock();
            }
            AcceptToken(Keywords.Do);
            loop.Operands[1] = ParseBlock();
            if (PeekToken().Value == Keywords.Until)
            {
                PopToken();
                loop.Operands[2] = ParseBlock();
            }
            AcceptToken(Keywords.End);
            return EndLoop();
        }

        private Function ParseFunction(List<Term> operands)
        {
            var fn = PopToken().Value.ToFunction();
            if (PeekToken().Value == "(")
            {
                PopToken();
                if (PeekToken().Value != ")")
                {
                    var term = ParseBlock();
                    if (term is Block block)
                        operands.AddRange(block.Operands);
                    else
                        operands.Add(term);
                }
                AcceptToken(")");
            }
            else
            {
                var term = ParseTerm();
                if (!(term is EmptyTerm))
                    operands.Add(term);
            }
            return new Function(fn, operands.ToArray());
        }

        private Function ParseFunctionAsStatic() => ParseFunction(new List<Term>());
        private Function ParseFunctionAsMember(Term self) => ParseFunction(new List<Term> { self });

        private Goto ParseGoto()
        {
            AcceptToken(Keywords.Goto);
            var label = AddLabel(PopToken().Value);
            return new Goto(label.LabelTarget);
        }

        private IfBlock ParseIf()
        {
            Term condition, consequent, alternative = null;
            AcceptToken(Keywords.If);
            condition = ParseBlock();
            AcceptToken(Keywords.Then);
            consequent = ParseBlock();
            if (PeekToken().Value == Keywords.Else)
            {
                PopToken();
                alternative = ParseBlock();
            }
            AcceptToken(Keywords.End);
            return
                alternative == null
                ? new IfBlock(condition, consequent)
                : new IfBlock(condition, consequent, alternative);
        }

        private Term ParseStatement()
        {
            var token = PeekToken();
            if (token.Kind == TokenKind.Keyword)
                switch (PeekToken().Value)
                {
                    case Keywords.If:
                        return ParseIf();
                    case Keywords.Switch:
                        return ParseSwitch();
                    case Keywords.While:
                    case Keywords.Do:
                        return ParseDo();
                    case Keywords.Break:
                        PopToken();
                        return Break();
                    case Keywords.Continue:
                        PopToken();
                        return Continue();
                    case Keywords.Goto:
                        return ParseGoto();
                    case Keywords.Try:
                        return ParseTry();
                    case Keywords.Stop:
                        return ParseStop();
                }
            return ParseCompound();
        }

        private Term ParseStop()
        {
            AcceptToken(Keywords.Stop);
            return new Stop();
        }

        private Switch ParseSwitch()
        {
            var cases = new List<Case>();
            Term defaultTerm = null;
            AcceptToken(Keywords.Switch);
            var valueTerm = ParseBlock();
            var caseValues = new List<Term>();
            var more = true;
            while (more)
            {
                switch (PopToken().Value)
                {
                    case Keywords.Case:
                        caseValues.Add(ParseTerm());
                        AcceptToken(":");
                        break;
                    case Keywords.Default:
                        AcceptToken(":");
                        defaultTerm = ParseBlock();
                        break;
                    case Keywords.End:
                        more = false;
                        break;
                    default:
                        var block = ParseBlock();
                        cases.Add(new Case(block, caseValues));
                        caseValues.Clear();
                        break;
                }
            }
            AcceptToken(Keywords.End);
            return new Switch(valueTerm, defaultTerm, cases);
        }

        private Term ParseTerm()
        {
            if (PeekToken().IsUnaryOperator())
                return new Operation(PopToken().ToUnaryOperator(), ParseTerm());
            Term term;
            if (PeekToken().Value == "(")
            {
                PopToken();
                if (PeekToken().Kind == TokenKind.TypeName)
                {
                    var type = PopToken().Value.ToType();
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
                    PopToken();
                    term = ParseFunctionAsMember(term);
                }
                else if (token.Kind == TokenKind.Function)
                    term = ParseFunctionAsMember(term);
                else
                    break;
            }
            return term;
        }

        private Term ParseTry()
        {
            Term
                bodyBlock = new EmptyTerm(),
                finallyBlock = new EmptyTerm();
            var catchBlocks = new List<Catch>();
            AcceptToken(Keywords.Try);
            switch (PeekToken().Value)
            {
                case Keywords.Catch:
                case Keywords.Finally:
                case Keywords.End:
                    break;
                default:
                    bodyBlock = ParseBlock();
                    break;
            }
            while (PeekToken().Value == Keywords.Catch)
                catchBlocks.Add(ParseCatch());
            if (PeekToken().Value == Keywords.Finally)
            {
                PopToken();
                finallyBlock = ParseBlock();
            }
            AcceptToken(Keywords.End);
            var tryBlock = new TryBlock(bodyBlock, finallyBlock, catchBlocks.ToArray());
            return tryBlock;
        }

        private Term ParseValue()
        {
            var tokenKind = PeekToken().Kind;
            return tokenKind == TokenKind.Function
                ? ParseFunctionAsStatic()
                : (tokenKind & TokenKind.Value) != 0
                ? ParseValue(tokenKind, PopToken().Value)
                : new EmptyTerm();
        }

        private Term ParseValue(TokenKind tokenKind, string value)
        {
            switch (tokenKind)
            {
                case TokenKind.Boolean: return ParseBoolean(value);
                case TokenKind.Character: return ParseCharacter(value);
                case TokenKind.DateTime: return ParseDateTime(value);
                case TokenKind.Default: return ParseDefault(value);
                case TokenKind.Field: return ParseField(value);
                case TokenKind.Number: return ParseNumber(value.ToUpperInvariant());
                case TokenKind.String: return ParseString(value);
                case TokenKind.TimeSpan: return ParseTimeSpan(value);
                case TokenKind.Variable: return ParseVariable(value);
                default: return null;
            }
        }

        #endregion

        #region Terminals

        private static Term ParseBoolean(string value) => value == "true";
        private static Term ParseCharacter(string value) => char.Parse(value.Substring(1, value.Length - 2));
        private static Term ParseDefault(string value) => new Default(value.Substring(1, value.Length - 2).ToType());
        private static Term ParseField(string value) => value.DisplayNameToTag();
        private Term ParseLabel() => AddLabel(PopToken().Value.TrimEnd(':'));
        private static Term ParseString(string value) => value.Substring(1, value.Length - 2);
        private Variable ParseVariable(string value) => GetVariable(value.ToUpperInvariant());

        private static Term ParseDateTime(string token)
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
            var groups = Regex.Match(token, Lexer.DateTimePattern).Groups;
            int year = int.Parse(groups[1].Value),
                month = int.Parse(groups[2].Value),
                day = int.Parse(groups[3].Value);
            int.TryParse(groups[4].Value, out var hours);
            int.TryParse(groups[5].Value, out var minutes);
            int.TryParse(groups[6].Value, out var seconds);
            double.TryParse(groups[7].Value, out var ms);
            return new DateTime(year, month, day, hours, minutes, seconds, (int)(ms * 1000));
        }

        private static Term ParseTimeSpan(string token)
        {
            // TimeSpan pattern captures 6 Groups.
            // [0] is the full TimeSpan (unused),
            // [1] is days,
            // [2] is hours,
            // [3] is minutes,
            // [4] is seconds,
            // [5] is fraction of a second, including a leading decimal point.
            var groups = Regex.Match(token, Lexer.TimeSpanPattern).Groups;
            int.TryParse(groups[1].Value, out var days);
            int hours = int.Parse(groups[2].Value),
                minutes = int.Parse(groups[3].Value);
            int.TryParse(groups[4].Value, out var seconds);
            double.TryParse(groups[5].Value, out var ms);
            return new TimeSpan(days, hours, minutes, seconds, (int)(ms * 1000));
        }

        private static Term ParseNumber(string value) =>
            value.EndsWith("UL") || value.EndsWith("LU") ? ulong.Parse(value.TrimEnd('U', 'L')) :
            value.EndsWith("D") ? double.Parse(value.TrimEnd('D')) :
            value.EndsWith("F") ? float.Parse(value.TrimEnd('F')) :
            value.EndsWith("L") ? long.Parse(value.TrimEnd('L')) :
            value.EndsWith("M") ? decimal.Parse(value.TrimEnd('M')) :
            value.EndsWith("U") ? uint.Parse(value.TrimEnd('U')) :
            value.Contains(".") ? double.Parse(value) :
            (Term)int.Parse(value);

        #endregion

        #region Helper Methods

        private Term DoParse(string program, bool caseSensitive)
        {
            _caseSensitive = caseSensitive;
            BeginParse(program);
            var term = ParseBlock();
            if (term is Compound compound)
                term = DoAdjustOperands(compound);
            return EndParse(term);
        }

        public bool DoTryParse(string text, out Term term, out Exception exception, bool caseSensitive)
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
                exception = ex is ParserException ? ex : new ParserException("Syntax Error", ex, PeekToken());
                return false;
            }
        }

        private Term DoAdjustOperands(Term term) => Fixer.Fix(term, _caseSensitive);

        #endregion

        #region ParserSpy Calls

        #region Labels

        private Label AddLabel(string labelName, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.AddLabel(caller, line, labelName);
        private LabelTarget GetLabelTarget(string labelName, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.GetLabelTarget(caller, line, labelName);

        #endregion
        #region Loops

        private Loop BeginLoop([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.BeginLoop(caller, line);
        private Break Break([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.Break(caller, line);
        private Continue Continue([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.Continue(caller, line);
        private Loop EndLoop([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.EndLoop(caller, line);

        #endregion
        #region Operators

        private bool AnyOperators() => _spy.AnyOperators();
        private Op PeekOperator([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.PeekOperator(caller, line);
        private Op PopOperator([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.PopOperator(caller, line);
        private void PushOperator(Op op = 0, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.PushOperator(caller, line, op);

        #endregion
        #region Parse

        private void BeginParse(string program, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.BeginParse(caller, line, program);
        private Term EndParse(Term term, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.EndParse(caller, line, term);
        private Term PeekTerm([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.PeekTerm(caller, line);
        private Term NewTerm(Term term, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.NewTerm(caller, line, term);

        #endregion
        #region Scopes

        private void BeginScope([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.BeginScope(caller, line);
        private void EndScope([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.EndScope(caller, line);

        #endregion
        #region Terms

        private Compound Consolidate(Term right, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.Consolidate(caller, line, right);
        private Term PopTerm([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.PopTerm(caller, line);
        private void PushTerm(Term term, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.PushTerm(caller, line, term);

        #endregion
        #region Tokens

        private void AcceptToken(string expected, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.AcceptToken(caller, line, expected);
        private Token PeekToken([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.PeekToken(caller, line);
        private Token PopToken([CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.PopToken(caller, line);
        private bool PopToken(string expected, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.PopToken(caller, line, expected);

        #endregion
        #region Variables

        private Variable GetVariable(string key, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = "") => _spy.GetVariable(caller, line, key);

        #endregion

        #endregion
    }
}
