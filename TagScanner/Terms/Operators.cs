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
                { Op.Let, new OpInfo('←', "{0} ← {1}", ExpressionType.Assign, Rank.Assignment, o) },
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

            foreach (var entry in OperationDictionary)
                entry.Value.Op = entry.Key;

            UnaryOperatorDictionary = new Dictionary<string, Op>();
            BinaryOperatorDictionary = new Dictionary<string, Op>();

            Add(Op.Comma, ",");
            Add(Op.Let, "<-", ":=", "←");
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
            Add(Op.Positive, "+", "＋");
            Add(Op.Negative, "-", "－");
            Add(Op.Not, "!", "NOT");
            Add(Op.Dot, ".");

            Symbols.AddRange(UnarySymbols.Union(BinarySymbols));

            void Add(Op op, params string[] symbols)
            {
                var unary = op.IsUnary();
                var dictionary = unary ? UnaryOperatorDictionary : BinaryOperatorDictionary;
                foreach (var symbol in symbols)
                    dictionary.Add(symbol, op);
                (unary ? UnarySymbols : BinarySymbols).AddRange(symbols);
            }
        }

        #endregion

        #region Public Properties

        public static Op[] Keys => OperationDictionary.Keys.ToArray();
        public static OpInfo[] Values => OperationDictionary.Values.ToArray();

        public static List<string>
            UnarySymbols = new List<string>(),
            BinarySymbols = new List<string>(),
            Symbols = new List<string>();

        #endregion

        #region Private Fields

        #endregion

        #region Public Extension Methods

        public static Associativity GetAssociativity(this Op op)
        {
            if (op.IsUnary())
                return Associativity.None;
            switch (op)
            {
                case Op.Let:
                    return Associativity.Right;
                case Op.Subtract:
                case Op.Divide:
                case Op.Modulo:
                case Op.Dot:
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
        public static bool IsInfinitary(this Op op) => op.GetAssociativity() != 0;
        public static bool IsLogical(this Op op) => (op & Op.Logical) != 0;
        public static bool IsUnary(this Op op) => (op & Op.Unary) != 0;
        public static bool IsVisible(this Op op) => (op & Op.Visible) != 0;
        public static string Label(this Op op) => OperationDictionary[op].Label;
        public static OpInfo OpInfo(this Op op) => OperationDictionary[op];
        public static Type ParamType(this Op op) => OperationDictionary[op].ParamType;

        public static Type ResultType(this Op op) =>
            op.IsLogical() ? typeof(bool) :
            op == Op.Concatenate ? typeof(string) :
            null; // Determined by arg types at runtime.

        public static Op ToOperator(this string symbol, bool unary)
        {
            var dictionary = unary ? UnaryOperatorDictionary : BinaryOperatorDictionary;
            return dictionary[symbol.ToUpperInvariant()];
        }

        #endregion

        #region Private Fields

        private static readonly Dictionary<string, Op>
            UnaryOperatorDictionary,
            BinaryOperatorDictionary;

        private static readonly Dictionary<Op, OpInfo> OperationDictionary;

        #endregion
    }
}
