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
            OperatorDictionary = new Dictionary<Op, OpInfo>
            {
                { Op.LParen, new OpInfo('(', null, 0, 0, null) },
                { Op.Comma, new OpInfo(',', "{0}, {1}", ExpressionType.MemberAccess, Rank.Comma, typeof(object)) },
                { Op.And, new OpInfo('&', "{0} & {1}", ExpressionType.AndAlso, Rank.ConditionalAnd, typeof(bool)) },
                { Op.Or, new OpInfo('|', "{0} | {1}", ExpressionType.OrElse, Rank.ConditionalOr, typeof(bool), Icons.Op2_Or) },
                { Op.Xor, new OpInfo('^', "{0} ^ {1}", ExpressionType.ExclusiveOr, Rank.BitwiseXor, typeof(bool), Icons.Op2_Xor) },
                { Op.EqualTo, new OpInfo('=', "{0} = {1}", ExpressionType.Equal, Rank.Equality, typeof(object), typeof(bool), Icons.Op2_EqualTo) },
                { Op.NotEqualTo, new OpInfo('≠', "{0} ≠ {1}", ExpressionType.NotEqual, Rank.Equality, typeof(object), typeof(bool), Icons.Op2_NotEqualTo) },
                { Op.LessThan, new OpInfo('<', "{0} < {1}", ExpressionType.LessThan, Rank.Relational, typeof(double), typeof(bool), Icons.Op2_LessThan) },
                { Op.NotLessThan, new OpInfo('≥', "{0} ≥ {1}", ExpressionType.GreaterThanOrEqual, Rank.Relational, typeof(double), typeof(bool), Icons.Op2_NotLessThan) },
                { Op.GreaterThan, new OpInfo('>', "{0} > {1}", ExpressionType.GreaterThan, Rank.Relational, typeof(double), typeof(bool), Icons.Op2_GreaterThan) },
                { Op.NotGreaterThan, new OpInfo('≤', "{0} ≤ {1}", ExpressionType.LessThanOrEqual, Rank.Relational, typeof(double), typeof(bool), Icons.Op2_NotGreaterThan) },
                { Op.Concatenate, new OpInfo('＋', "{0} ＋ {1}", ExpressionType.Add, Rank.Additive, typeof(string), Icons.Op2_Add) },
                { Op.Add, new OpInfo('＋', "{0} ＋ {1}", ExpressionType.Add, Rank.Additive, typeof(double), Icons.Op2_Add) },
                { Op.Subtract, new OpInfo('－', "{0} － {1}", ExpressionType.Subtract, Rank.Additive, typeof(double), Icons.Op2_Subtract) },
                { Op.Multiply, new OpInfo('✕', "{0} ✕ {1}", ExpressionType.Multiply, Rank.Multiplicative, typeof(double), Icons.Op2_Multiply) },
                { Op.Divide, new OpInfo('／', "{0} ／ {1}", ExpressionType.Divide, Rank.Multiplicative, typeof(double), Icons.Op2_Divide) },
                { Op.Modulo, new OpInfo('%', "{0} % {1}", ExpressionType.Modulo, Rank.Multiplicative, typeof(double), Icons.Op2_Modulo) },
                { Op.Positive, new OpInfo('＋', "＋{0}", ExpressionType.UnaryPlus, Rank.Unary, typeof(double), Icons.Op2_Add) },
                { Op.Negative, new OpInfo('－', "－{0}", ExpressionType.Negate, Rank.Unary, typeof(double), Icons.Op2_Subtract) },
                { Op.Not, new OpInfo('!', "!{0}", ExpressionType.Not, Rank.Unary, typeof(bool), Icons.Op2_Not) },
                { Op.Dot, new OpInfo('.', "{0}.{1}", ExpressionType.MemberAccess, Rank.Primary, typeof(object)) },
            };
            Keys = OperatorDictionary.Keys.ToArray();
            Values = OperatorDictionary.Values.ToArray();
            AssociativeOperators = new[] { Op.Comma, Op.And, Op.Or, Op.Concatenate, Op.Add, Op.Multiply };
            UnaryOperators = new[] { Op.Positive, Op.Negative, Op.Not };
            BinaryOperators = Keys.Except(UnaryOperators).Except(new[] { Op.LParen }).ToArray();
        }

    #endregion

    #region Public Properties

        public static Op[] Keys { get; }
        public static OpInfo[] Values { get; }
        public static Op[] AssociativeOperators { get; }
        public static Op[] UnaryOperators { get; }
        public static Op[] BinaryOperators { get; }

        #endregion

        #region Public Extension Methods

        public static int Arity(this Op op) => op.Associates() ? int.MaxValue : op.IsBinary() ? 2 : op.IsUnary() ? 1 : 0;
        public static bool Associates(this Op op) => AssociativeOperators.Contains(op);
        public static bool CanChain(this Op op) => op == Op.EqualTo || op.GetRank() == Terms.Rank.Relational;
        public static ExpressionType GetExpType(this Op op) => OperatorDictionary[op].ExpressionType;
        public static string GetFormat(this Op op) => OperatorDictionary[op].Format;
        public static Image GetImage(this Op op) => OperatorDictionary[op].Image;
        public static char GetLabel(this Op op) => OperatorDictionary[op].Label;
        public static OpInfo GetOpInfo(this Op op) => OperatorDictionary[op];
        public static Rank GetRank(this Op op) => OperatorDictionary[op].Rank;
        public static Type GetResultType(this Op op) => OperatorDictionary[op].ResultType;
        public static bool IsBinary(this Op op) => BinaryOperators.Contains(op);
        public static bool IsUnary(this Op op) => UnaryOperators.Contains(op);

        public static Op ToOperator(this string symbol, bool unary)
        {
            switch (symbol.ToLower())
            {
                case ",":
                    return Op.Comma;
                case "&":
                case "&&":
                case "and":
                    return Op.And;
                case "|":
                case "||":
                case "or":
                    return Op.Or;
                case "^":
                case "xor":
                    return Op.Xor;
                case "=":
                case "==":
                    return Op.EqualTo;
                case "!=":
                case "<>":
                case "≠":
                    return Op.NotEqualTo;
                case "<":
                    return Op.LessThan;
                case ">=":
                case "≥":
                case "≮":
                    return Op.NotLessThan;
                case ">":
                    return Op.GreaterThan;
                case "<=":
                case "≤":
                case "≯":
                    return Op.NotGreaterThan;
                case "+":
                case "＋":
                    return unary ? Op.Positive : Op.Add;
                case "-":
                case "－":
                    return unary ? Op.Negative : Op.Subtract;
                case "*":
                case "×":
                case "✕":
                    return Op.Multiply;
                case "/":
                case "÷":
                case "／":
                    return Op.Divide;
                case "%":
                    return Op.Modulo;
                case "!":
                case "not":
                    return Op.Not;
                case ".":
                    return Op.Dot;
            }
            throw new FormatException($"The symbol '{symbol}' does not represent a known operator.");
        }

        #endregion

        #region Private Fields

        private static readonly Dictionary<Op, OpInfo> OperatorDictionary;

        #endregion
    }
}
