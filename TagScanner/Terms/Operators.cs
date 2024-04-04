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
                { Op.LParen, new OpInfo("(", 0, 0, null, null, null ) },
                { Op.Comma, new OpInfo(",", ExpressionType.MemberAccess, Rank.Comma, typeof(object), "{0}, {1}", 0) },
                { Op.Conditional, new OpInfo("if-then-else", ExpressionType.Conditional, Rank.Conditional, typeof(object), "{0} ? {1} : {2}", 1, typeof(bool), typeof(object)) },
                { Op.And, new OpInfo("and", ExpressionType.AndAlso, Rank.ConditionalAnd, typeof(bool), "{0} & {1}", 2) },
                { Op.Or, new OpInfo("or", ExpressionType.OrElse, Rank.ConditionalOr, typeof(bool), "{0} | {1}", 3) },
                { Op.Xor, new OpInfo("exclusive or", ExpressionType.ExclusiveOr, Rank.BitwiseXor, typeof(bool), "{0} ^ {1}", 4) },
                { Op.EqualTo, new OpInfo("=", ExpressionType.Equal, Rank.Equality, typeof(bool), "{0} = {1}", 5, typeof(object)) },
                { Op.NotEqualTo, new OpInfo("≠", ExpressionType.NotEqual, Rank.Equality, typeof(bool), "{0} != {1}", 6, typeof(object)) },
                { Op.LessThan, new OpInfo("<", ExpressionType.LessThan, Rank.Relational, typeof(bool), "{0} < {1}", 7, typeof(double)) },
                { Op.NotLessThan, new OpInfo("≥", ExpressionType.GreaterThanOrEqual, Rank.Relational, typeof(bool), "{0} >= {1}", 8, typeof(double)) },
                { Op.GreaterThan, new OpInfo(">", ExpressionType.GreaterThan, Rank.Relational, typeof(bool), "{0} > {1}", 9, typeof(double)) },
                { Op.NotGreaterThan, new OpInfo("≤", ExpressionType.LessThanOrEqual, Rank.Relational, typeof(bool), "{0} <= {1}", 10, typeof(double)) },
                { Op.Concatenate, new OpInfo("＋", ExpressionType.Add, Rank.Additive, typeof(string), "{0} + {1}", 11) },
                { Op.Add, new OpInfo("＋", ExpressionType.Add, Rank.Additive, typeof(double), "{0} + {1}", 11) },
                { Op.Subtract, new OpInfo("－", ExpressionType.Subtract, Rank.Additive, typeof(double), "{0} - {1}", 12) },
                { Op.Multiply, new OpInfo("✕", ExpressionType.Multiply, Rank.Multiplicative, typeof(double), "{0} * {1}", 13) },
                { Op.Divide, new OpInfo("／", ExpressionType.Divide, Rank.Multiplicative, typeof(double), "{0} / {1}", 14) },
                { Op.Modulo, new OpInfo("%", ExpressionType.Modulo, Rank.Multiplicative, typeof(double), "{0} % {1}", 15 ) },
                { Op.Positive, new OpInfo("＋", ExpressionType.UnaryPlus, Rank.Unary, typeof(double), "+{0}", 11) },
                { Op.Negative, new OpInfo("－", ExpressionType.Negate, Rank.Unary, typeof(double), "-{0}", 12) },
                { Op.Not, new OpInfo("not", ExpressionType.Not, Rank.Unary, typeof(bool), "!{0}", 16) },
                { Op.Dot, new OpInfo(".", ExpressionType.MemberAccess, Rank.Primary, typeof(object), "{0}.{1}", 17) },
            };
            Keys = OperatorDictionary.Keys.ToArray();
            Values = OperatorDictionary.Values.ToArray();
        }

        #endregion

        #region Public Properties

        public static Op[] Keys { get; }
        public static OpInfo[] Values { get; }

        #endregion

        #region Public Extension Methods

        public static int Arity(this Op op)
        {
            switch (op)
            {
                case Op.And:
                case Op.Or:
                case Op.Concatenate:
                case Op.Add:
                case Op.Subtract:
                case Op.Multiply:
                case Op.Divide:
                    return int.MaxValue;
            }
            // Otherwise, the Arity value is simply the number of {#} placeholders in the relevant Format string.
            var format = op.GetFormat();
            for (var result = 0; ; result++)
                if (format.IndexOf($"{{{result}}}") < 0)
                    return result;
        }

        public static bool Associates(this Op op) => op.Arity() == int.MaxValue;
        public static bool CanChain(this Op op) => op == Op.EqualTo || op.GetRank() == Terms.Rank.Relational;
        public static ExpressionType GetExpType(this Op op) => OperatorDictionary[op].ExpressionType;
        public static string GetFormat(this Op op) => OperatorDictionary[op].Format;
        public static Image GetImage(this Op op) => OperatorDictionary[op].Image;
        public static OpInfo GetOpInfo(this Op op) => OperatorDictionary[op];
        public static Rank GetRank(this Op op) => OperatorDictionary[op].Rank;
        public static Type GetResultType(this Op op) => OperatorDictionary[op].ResultType;

        public static Op ToOperator(this string symbol, bool unary)
        {
            switch (symbol.ToLower())
            {
                case ",":
                    return Op.Comma;
                case "?":
                case  ":":
                    return Op.Conditional;
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
