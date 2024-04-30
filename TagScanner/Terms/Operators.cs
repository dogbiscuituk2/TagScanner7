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

            OperationDictionary = new Dictionary<Op, OpInfo>
            {
                { 0, new OpInfo('(', null, 0, 0, null) },
                { Op.Comma, new OpInfo(',', "{0}, {1}", ExpressionType.MemberAccess, Rank.Comma, o) },
                { Op.And, new OpInfo('&', "{0} & {1}", ExpressionType.AndAlso, Rank.ConditionalAnd, b, Icons.Op2_And) },
                { Op.Or, new OpInfo('|', "{0} | {1}", ExpressionType.OrElse, Rank.ConditionalOr, b, Icons.Op2_Or) },
                { Op.Xor, new OpInfo('^', "{0} ^ {1}", ExpressionType.ExclusiveOr, Rank.BitwiseXor, b, Icons.Op2_Xor) },
                { Op.EqualTo, new OpInfo('=', "{0} = {1}", ExpressionType.Equal, Rank.Equality, o, Icons.Op2_EqualTo) },
                { Op.NotEqualTo, new OpInfo('≠', "{0} ≠ {1}", ExpressionType.NotEqual, Rank.Equality, o, Icons.Op2_NotEqualTo) },
                { Op.LessThan, new OpInfo('<', "{0} < {1}", ExpressionType.LessThan, Rank.Relational, d, Icons.Op2_LessThan) },
                { Op.NotLessThan, new OpInfo('≥', "{0} ≥ {1}", ExpressionType.GreaterThanOrEqual, Rank.Relational, d, Icons.Op2_NotLessThan) },
                { Op.GreaterThan, new OpInfo('>', "{0} > {1}", ExpressionType.GreaterThan, Rank.Relational, d, Icons.Op2_GreaterThan) },
                { Op.NotGreaterThan, new OpInfo('≤', "{0} ≤ {1}", ExpressionType.LessThanOrEqual, Rank.Relational, d, Icons.Op2_NotGreaterThan) },
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

            Keys = OperationDictionary.Keys.ToArray();
            Values = OperationDictionary.Values.ToArray();

            foreach (var entry in OperationDictionary)
                entry.Value.Op = entry.Key;

            OperatorDictionary = new Dictionary<string, Op>();

            Add(Op.Comma, ",");
            Add(Op.And, "&", "&&", "AND");
            Add(Op.Or, "|", "||", "OR");
            Add(Op.Xor, "^", "XOR");
            Add(Op.EqualTo, "=", "==");
            Add(Op.NotEqualTo, "!=", "<>", "≠");
            Add(Op.LessThan, "<");
            Add(Op.NotLessThan, ">=", "≥", "≮");
            Add(Op.GreaterThan, ">");
            Add(Op.NotGreaterThan, "<=", "≤", "≯");
            Add(Op.Add, "+", "＋"); // Op.Positive when Unary.
            Add(Op.Subtract, "-", "－");  // Op.Negative when Unary.
            Add(Op.Multiply, "*", "×", "✕");
            Add(Op.Divide, "/", "÷", "／");
            Add(Op.Modulo, "%");
            Add(Op.Not, "!", "NOT");
            Add(Op.Dot, ".");

            void Add(Op op, params string[] symbols)
            {
                foreach (var symbol in symbols)
                    OperatorDictionary.Add(symbol, op);
            }
        }

        #endregion

        #region Public Properties

        public static Op[] Keys { get; }
        public static OpInfo[] Values { get; }

        #endregion

        #region Public Extension Methods

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
        public static ExpressionType ExpType(this Op op) => OperationDictionary[op].ExpressionType;
        public static string Format(this Op op) => OperationDictionary[op].Format;
        public static Rank GetRank(this Op op) => OperationDictionary[op].Rank;
        public static Image Image(this Op op) => OperationDictionary[op].Image;
        public static bool IsBinary(this Op op) => (op & Op.Binary) != 0;
        public static bool IsLogical(this Op op) => (op & Op.Logical) != 0;
        public static bool IsUnary(this Op op) => (op & Op.Unary) != 0;
        public static bool IsVisible(this Op op) => (op & Op.Visible) != 0;
        public static string Label(this Op op) => OperationDictionary[op].Label;
        public static OpInfo OpInfo(this Op op) => OperationDictionary[op];
        public static bool ParamArray(this Op op) => (op & Op.ParamArray) != 0;
        public static Type ParamType(this Op op) => OperationDictionary[op].ParamType;

        public static Type ResultType(this Op op) =>
            op.IsLogical() ? typeof(bool) :
            op == Op.Concatenate ? typeof(string) :
            null; // Determined by arg types at runtime.

        public static Op ToOperator(this string symbol, bool unary)
        {
            var op = OperatorDictionary[symbol.ToUpperInvariant()];
            if (unary)
                switch (op)
                {
                    case Op.Add:
                        return Op.Positive;
                    case Op.Subtract:
                        return Op.Negative;
                }
            return op;
        }

        #endregion

        #region Private Fields

        private static readonly Dictionary<string, Op> OperatorDictionary;
        private static readonly Dictionary<Op, OpInfo> OperationDictionary;

        #endregion
    }
}
