namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public static class Operators
    {
        #region Static Constructor

        static Operators()
        {
            OperatorDictionary = new Dictionary<Op, OpInfo>
            {
                { Op.Conditional, new OpInfo("if-then-else", ExpressionType.Conditional, Rank.Conditional, typeof(object), "if {0} then {1} else {2}", new[] { typeof(bool), typeof(object) }) },
                { Op.And, new OpInfo("and", ExpressionType.AndAlso, Rank.ConditionalAnd, typeof(bool), "{0} and {1}") },
                { Op.Or, new OpInfo("or", ExpressionType.OrElse, Rank.ConditionalOr, typeof(bool), "{0} or {1}") },
                { Op.Xor, new OpInfo("exclusive or", ExpressionType.ExclusiveOr, Rank.BitwiseXor, typeof(bool), "{0} xor {1}") },
                { Op.EqualTo, new OpInfo("=", ExpressionType.Equal, Rank.Equality, typeof(bool), "{0} = {1}", typeof(object)) },
                { Op.NotEqualTo, new OpInfo("≠", ExpressionType.NotEqual, Rank.Equality, typeof(bool), "{0} ≠ {1}", typeof(object)) },
                { Op.LessThan, new OpInfo("<", ExpressionType.LessThan, Rank.Relational, typeof(bool), "{0} < {1}", typeof(double)) },
                { Op.NotLessThan, new OpInfo("≥", ExpressionType.GreaterThanOrEqual, Rank.Relational, typeof(bool), "{0} ≥ {1}", typeof(double)) },
                { Op.GreaterThan, new OpInfo(">", ExpressionType.GreaterThan, Rank.Relational, typeof(bool), "{0} > {1}", typeof(double)) },
                { Op.NotGreaterThan, new OpInfo("≤", ExpressionType.LessThanOrEqual, Rank.Relational, typeof(bool), "{0} ≤ {1}", typeof(double)) },
                { Op.Concatenate, new OpInfo("＋", ExpressionType.Add, Rank.Additive, typeof(string), "{0} ＋ {1}") },
                { Op.Add, new OpInfo("＋", ExpressionType.Add, Rank.Additive, typeof(double), "{0} ＋ {1}") },
                { Op.Subtract, new OpInfo("－", ExpressionType.Subtract, Rank.Additive, typeof(double), "{0} － {1}") },
                { Op.Multiply, new OpInfo("✕", ExpressionType.Multiply, Rank.Multiplicative, typeof(double), "{0} ✕ {1}") },
                { Op.Divide, new OpInfo("／", ExpressionType.Divide, Rank.Multiplicative, typeof(double), "{0} ／ {1}") },
                { Op.Positive, new OpInfo("＋", ExpressionType.UnaryPlus, Rank.Unary, typeof(double), "＋{0}") },
                { Op.Negative, new OpInfo("－", ExpressionType.Negate, Rank.Unary, typeof(double), "－{0}") },
                { Op.Not, new OpInfo("not", ExpressionType.Not, Rank.Unary, typeof(bool), "not {0}") },
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
        public static bool CanChain(this Op op) => op == Op.EqualTo || op.GetRank() == Rank.Relational;
        public static ExpressionType ExpType(this Op op) => OperatorDictionary[op].ExpType;
        public static string Format(this Op op) => OperatorDictionary[op].Format;
        public static Rank GetRank(this Op op) => OperatorDictionary[op].Rank;
        public static Type ResultType(this Op op) => OperatorDictionary[op].ResultType;

        public static OpInfo OpInfo(this Op op) => OperatorDictionary[op];

        #endregion

        #region Private Fields

        private static readonly Dictionary<Op, OpInfo> OperatorDictionary;

        #endregion
    }
}
