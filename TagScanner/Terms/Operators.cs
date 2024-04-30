namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Linq.Expressions;
    using Icons = Properties.Resources;

    public static class Operators
    {
        #region Static Constructor

        static Operators()
        {
            Type
                b = typeof(bool),
                d = typeof(double),
                o = typeof(object),
                s = typeof(string);

            OperatorDictionary = new Dictionary<Op, OpInfo>
            {
                { 0, new OpInfo('(', null, 0, 0, null) },
                { Op.Comma, new OpInfo(',', "{0}, {1}", ExpressionType.MemberAccess, Rank.Comma, o) },
                { Op.And, new OpInfo('&', "{0} & {1}", ExpressionType.AndAlso, Rank.ConditionalAnd, b, Icons.Op2_And) },
                { Op.Or, new OpInfo('|', "{0} | {1}", ExpressionType.OrElse, Rank.ConditionalOr, b, Icons.Op2_Or) },
                { Op.Xor, new OpInfo('^', "{0} ^ {1}", ExpressionType.ExclusiveOr, Rank.BitwiseXor, b, Icons.Op2_Xor) },
                { Op.EqualTo, new OpInfo('=', "{0} = {1}", ExpressionType.Equal, Rank.Equality, o, b, Icons.Op2_EqualTo) },
                { Op.NotEqualTo, new OpInfo('≠', "{0} ≠ {1}", ExpressionType.NotEqual, Rank.Equality, o, b, Icons.Op2_NotEqualTo) },
                { Op.LessThan, new OpInfo('<', "{0} < {1}", ExpressionType.LessThan, Rank.Relational, d, b, Icons.Op2_LessThan) },
                { Op.NotLessThan, new OpInfo('≥', "{0} ≥ {1}", ExpressionType.GreaterThanOrEqual, Rank.Relational, d, b, Icons.Op2_NotLessThan) },
                { Op.GreaterThan, new OpInfo('>', "{0} > {1}", ExpressionType.GreaterThan, Rank.Relational, d, b, Icons.Op2_GreaterThan) },
                { Op.NotGreaterThan, new OpInfo('≤', "{0} ≤ {1}", ExpressionType.LessThanOrEqual, Rank.Relational, d, b, Icons.Op2_NotGreaterThan) },
                { Op.Concatenate, new OpInfo('+', "{0} + {1}", ExpressionType.Add, Rank.Additive, s, Icons.Op2_Add) },
                { Op.Add, new OpInfo('+', "{0} + {1}", ExpressionType.Add, Rank.Additive, d, Icons.Op2_Add) },
                { Op.Subtract, new OpInfo('-', "{0} - {1}", ExpressionType.Subtract, Rank.Additive, d, Icons.Op2_Subtract) },
                { Op.Multiply, new OpInfo('×', "{0} × {1}", ExpressionType.Multiply, Rank.Multiplicative, d, Icons.Op2_Multiply) },
                { Op.Divide, new OpInfo('÷', "{0} ÷ {1}", ExpressionType.Divide, Rank.Multiplicative, d, Icons.Op2_Divide) },
                { Op.Modulo, new OpInfo('%', "{0} % {1}", ExpressionType.Modulo, Rank.Multiplicative, d, Icons.Op2_Modulo) },
                { Op.Positive, new OpInfo('+', "+{0}", ExpressionType.UnaryPlus, Rank.Unary, d, Icons.Op2_Add) },
                { Op.Negative, new OpInfo('-', "-{0}", ExpressionType.Negate, Rank.Unary, d, Icons.Op2_Subtract) },
                { Op.Not, new OpInfo('!', "!{0}", ExpressionType.Not, Rank.Unary, b, Icons.Op2_Not) },
                { Op.Dot, new OpInfo('.', "{0}.{1}", ExpressionType.MemberAccess, Rank.Primary, o) },
            };

            Keys = OperatorDictionary.Keys.ToArray();
            Values = OperatorDictionary.Values.ToArray();

            foreach (var entry in OperatorDictionary)
                entry.Value.Op = entry.Key;
        }

        #endregion

        #region Public Properties

        public static Op[] Keys { get; }
        public static OpInfo[] Values { get; }

        #endregion

        #region Public Extension Methods

        public static bool IsAssociative(this Op op) => (op & Op.Associative) != 0;
        public static bool IsLeftAssociative(this Op op) => (op & Op.LeftAssociative) != 0;
        public static bool IsNonAssociative(this Op op) => (op & Op.NonAssociative) != 0;
        public static bool IsRightAssociative(this Op op) => (op & Op.RightAssociative) != 0;

        public static Associativity GetAssociativity(this Op op)
        {
            if (op.IsUnary())
                return Associativity.None;
            switch (op)
            {
                case Op.Subtract:
                case Op.Divide:
                case Op.Modulo:
                    return Associativity.Left;
                default:
                    return Associativity.Full;
            }
        }

        public static bool CanChain(this Op op) => (op & Op.Chains) != 0;
        public static ExpressionType ExpType(this Op op) => OperatorDictionary[op].ExpressionType;
        public static string Format(this Op op) => OperatorDictionary[op].Format;
        public static Rank GetRank(this Op op) => OperatorDictionary[op].Rank;
        public static Image Image(this Op op) => OperatorDictionary[op].Image;
        public static bool IsBinary(this Op op) => (op & Op.Binary) != 0;
        public static bool IsUnary(this Op op) => (op & Op.Unary) != 0;
        public static bool IsVisible(this Op op) => (op & Op.Visible) != 0;
        public static string Label(this Op op) => OperatorDictionary[op].Label;
        public static OpInfo OpInfo(this Op op) => OperatorDictionary[op];
        public static bool ParamArray(this Op op) => (op & Op.ParamArray) != 0;
        public static Type ParamType(this Op op) => OperatorDictionary[op].ParamType;
        public static Type ResultType(this Op op) => OperatorDictionary[op].ResultType;

        public struct OpSymbols
        {
            public OpSymbols(Op op, string[] symbols)
            {
                Op = op;
                Symbols = symbols;
            }

            Op Op;
            string[] Symbols;
        }

        public static Op ToOperator(this string symbol, bool unary)
        {
            switch (symbol.ToUpper())
            {
                case ",": return Op.Comma;
                case "&": case "&&": case "AND": return Op.And;
                case "|": case "||": case "OR": return Op.Or;
                case "^": case "XOR": return Op.Xor;
                case "=": case "==": return Op.EqualTo;
                case "!=": case "<>": case "≠": return Op.NotEqualTo;
                case "<": return Op.LessThan;
                case ">=": case "≥": case "≮": return Op.NotLessThan;
                case ">": return Op.GreaterThan;
                case "<=": case "≤": case "≯": return Op.NotGreaterThan;
                case "+": case "＋": return unary ? Op.Positive : Op.Add;
                case "-": case "－": return unary ? Op.Negative : Op.Subtract;
                case "*": case "×": case "✕": return Op.Multiply;
                case "/": case "÷": case "／": return Op.Divide;
                case "%": return Op.Modulo;
                case "!": case "NOT": return Op.Not;
                case ".": return Op.Dot;
            }
            throw new FormatException($"The symbol '{symbol}' does not represent a known operator.");
        }

        #endregion

        #region Private Fields

        private static readonly Dictionary<Op, OpInfo> OperatorDictionary;

        #endregion
    }
}
