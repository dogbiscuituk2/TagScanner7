namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
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
                { Op.Conditional, new OpInfo("if-then-else", ExpressionType.Conditional, Terms.Rank.Conditional, typeof(object), "if {0} then {1} else {2}", Icons.Op_Conditional, typeof(bool), typeof(object)) },
                { Op.And, new OpInfo("and", ExpressionType.AndAlso, Terms.Rank.ConditionalAnd, typeof(bool), "{0} and {1}", Icons.Op_And) },
                { Op.Or, new OpInfo("or", ExpressionType.OrElse, Terms.Rank.ConditionalOr, typeof(bool), "{0} or {1}", Icons.Op_Or) },
                { Op.Xor, new OpInfo("exclusive or", ExpressionType.ExclusiveOr, Terms.Rank.BitwiseXor, typeof(bool), "{0} xor {1}", Icons.Op_Xor) },
                { Op.EqualTo, new OpInfo("=", ExpressionType.Equal, Terms.Rank.Equality, typeof(bool), "{0} = {1}", Icons.Op_EqualTo, typeof(object)) },
                { Op.NotEqualTo, new OpInfo("≠", ExpressionType.NotEqual, Terms.Rank.Equality, typeof(bool), "{0} ≠ {1}", Icons.Op_NotEqualTo, typeof(object)) },
                { Op.LessThan, new OpInfo("<", ExpressionType.LessThan, Terms.Rank.Relational, typeof(bool), "{0} < {1}", Icons.Op_LessThan, typeof(double)) },
                { Op.NotLessThan, new OpInfo("≥", ExpressionType.GreaterThanOrEqual, Terms.Rank.Relational, typeof(bool), "{0} ≥ {1}", Icons.Op_NotLessThan, typeof(double)) },
                { Op.GreaterThan, new OpInfo(">", ExpressionType.GreaterThan, Terms.Rank.Relational, typeof(bool), "{0} > {1}", Icons.Op_GreaterThan, typeof(double)) },
                { Op.NotGreaterThan, new OpInfo("≤", ExpressionType.LessThanOrEqual, Terms.Rank.Relational, typeof(bool), "{0} ≤ {1}", Icons.Op_NotGreaterThan, typeof(double)) },
                { Op.Concatenate, new OpInfo("＋", ExpressionType.Add, Terms.Rank.Additive, typeof(string), "{0} ＋ {1}", Icons.Op_Concatenate) },
                { Op.Add, new OpInfo("＋", ExpressionType.Add, Terms.Rank.Additive, typeof(double), "{0} ＋ {1}", Icons.Op_Add) },
                { Op.Subtract, new OpInfo("－", ExpressionType.Subtract, Terms.Rank.Additive, typeof(double), "{0} － {1}", Icons.Op_Subtract) },
                { Op.Multiply, new OpInfo("✕", ExpressionType.Multiply, Terms.Rank.Multiplicative, typeof(double), "{0} ✕ {1}", Icons.Op_Multiply) },
                { Op.Divide, new OpInfo("／", ExpressionType.Divide, Terms.Rank.Multiplicative, typeof(double), "{0} ／ {1}", Icons.Op_Divide) },
                { Op.Positive, new OpInfo("＋", ExpressionType.UnaryPlus, Terms.Rank.Unary, typeof(double), "＋{0}", Icons.Op_Add) },
                { Op.Negative, new OpInfo("－", ExpressionType.Negate, Terms.Rank.Unary, typeof(double), "－{0}", Icons.Op_Subtract) },
                { Op.Not, new OpInfo("not", ExpressionType.Not, Terms.Rank.Unary, typeof(bool), "not {0}", Icons.Op_Not) },
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
            var format = op.Format();
            for (var result = 0; ; result++)
                if (format.IndexOf($"{{{result}}}") < 0)
                    return result;
        }

        public static bool Associates(this Op op) => op.Arity() == int.MaxValue;
        public static bool CanChain(this Op op) => op == Op.EqualTo || op.Rank() == Terms.Rank.Relational;
        public static ExpressionType ExpType(this Op op) => OperatorDictionary[op].ExpType;
        public static string Format(this Op op) => OperatorDictionary[op].Format;
        public static Rank Rank(this Op op) => OperatorDictionary[op].Rank;
        public static Type ResultType(this Op op) => OperatorDictionary[op].ResultType;

        public static OpInfo OpInfo(this Op op) => OperatorDictionary[op];

        #endregion

        #region Private Fields

        private static readonly Dictionary<Op, OpInfo> OperatorDictionary;

        #endregion
    }
}
