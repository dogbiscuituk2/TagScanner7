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
            Rank
                add = Rank.Additive,
                and = Rank.ConditionalAnd,
                ass = Rank.Assignment,
                c = Rank.Comma,
                e = Rank.Equality,
                m = Rank.Multiplicative,
                or = Rank.ConditionalOr,
                p = Rank.Primary,
                r = Rank.Relational,
                u = Rank.Unary,
                x = Rank.BitwiseXor;
            Type
                b = typeof(bool),
                d = typeof(double),
                o = typeof(object),
                s = typeof(string);

            _operators = new Dictionary<Op, OpInfo>
            {
                //{ 0, new OpInfo("(", null, 0, 0, null) },
                //{ Op.Comma, new OpInfo(",", "{0}, {1}", ExpressionType.MemberAccess, c, o) },
                { Op.Assign, new OpInfo("←", "{0} ← {1}", ExpressionType.Assign, ass, o) },
                { Op.AndAssign, new OpInfo("&=", "{0} &= {1}", ExpressionType.AndAssign, ass, o) },
                { Op.OrAssign, new OpInfo("|=", "{0} |= {1}", ExpressionType.OrAssign, ass, o) },
                { Op.XorAssign, new OpInfo("^=", "{0} ^= {1}", ExpressionType.ExclusiveOrAssign, ass, o) },
                { Op.AddAssign, new OpInfo("+=", "{0} += {1}", ExpressionType.AddAssign, ass, o) },
                { Op.SubtractAssign, new OpInfo("-=", "{0} -= {1}", ExpressionType.SubtractAssign, ass, o) },
                { Op.MultiplyAssign, new OpInfo("*=", "{0} *= {1}", ExpressionType.MultiplyAssign, ass, o) },
                { Op.DivideAssign, new OpInfo("/=", "{0} /= {1}", ExpressionType.DivideAssign, ass, o) },
                { Op.ModuloAssign, new OpInfo("%=", "{0} %= {1}", ExpressionType.ModuloAssign, ass, o) },
                { Op.And, new OpInfo("&", "{0} & {1}", ExpressionType.AndAlso, and, b, Icons.Op2_And) },
                { Op.Or, new OpInfo("|", "{0} | {1}", ExpressionType.OrElse, or, b, Icons.Op2_Or) },
                { Op.Xor, new OpInfo("^", "{0} ^ {1}", ExpressionType.ExclusiveOr, x, b, Icons.Op2_Xor) },
                { Op.EqualTo, new OpInfo("=", "{0} = {1}", ExpressionType.Equal, e, o, Icons.Op2_EqualTo) },
                { Op.NotEqualTo, new OpInfo("≠", "{0} ≠ {1}", ExpressionType.NotEqual, e, o, Icons.Op2_NotEqualTo) },
                { Op.LessThan, new OpInfo("<", "{0} < {1}", ExpressionType.LessThan, r, d, Icons.Op2_LessThan) },
                { Op.NotLessThan, new OpInfo("≥", "{0} ≥ {1}", ExpressionType.GreaterThanOrEqual, r, d, Icons.Op2_NotLessThan) },
                { Op.GreaterThan, new OpInfo(">", "{0} > {1}", ExpressionType.GreaterThan, r, d, Icons.Op2_GreaterThan) },
                { Op.NotGreaterThan, new OpInfo("≤", "{0} ≤ {1}", ExpressionType.LessThanOrEqual, r, d, Icons.Op2_NotGreaterThan) },
                { Op.Concatenate, new OpInfo("+", "{0} + {1}", ExpressionType.Add, add, s, Icons.Op2_Add) },
                { Op.Add, new OpInfo("+", "{0} + {1}", ExpressionType.Add, add, d, Icons.Op2_Add) },
                { Op.Subtract, new OpInfo("-", "{0} - {1}", ExpressionType.Subtract, add, d, Icons.Op2_Subtract) },
                { Op.Multiply, new OpInfo("×", "{0} × {1}", ExpressionType.Multiply, m, d, Icons.Op2_Multiply) },
                { Op.Divide, new OpInfo("÷", "{0} ÷ {1}", ExpressionType.Divide, m, d, Icons.Op2_Divide) },
                { Op.Modulo, new OpInfo("%", "{0} % {1}", ExpressionType.Modulo, m, d, Icons.Op2_Modulo) },
                { Op.Positive, new OpInfo("+", "+{0}", ExpressionType.UnaryPlus, u, d, Icons.Op2_Add) },
                { Op.Negative, new OpInfo("-", "-{0}", ExpressionType.Negate, u, d, Icons.Op2_Subtract) },
                { Op.Not, new OpInfo("!", "!{0}", ExpressionType.Not, u, b, Icons.Op2_Not) },
                //{ Op.Dot, new OpInfo(".", "{0}.{1}", ExpressionType.MemberAccess, p, o) },
            };

            foreach (var op in _operators)
                op.Value.Op = op.Key;

            //Add(Op.Comma, ",");
            Add(Op.Assign, "<-", ":=", "←");
            Add(Op.AddAssign, "+=");
            Add(Op.SubtractAssign, "-=");
            Add(Op.MultiplyAssign, "*=");
            Add(Op.DivideAssign, "/=");
            Add(Op.ModuloAssign, "%=");
            Add(Op.AndAssign, "&=");
            Add(Op.OrAssign, "|=");
            Add(Op.XorAssign, "^=");
            Add(Op.And, "&", "&&", "AND");
            Add(Op.Or, "|", "||", "OR");
            Add(Op.Xor, "^", "XOR");
            Add(Op.EqualTo, "=", "==");
            Add(Op.NotEqualTo, "!=", "<>", "#", "≠");
            Add(Op.LessThan, "<");
            Add(Op.NotLessThan, ">=", "≥", "≮");
            Add(Op.GreaterThan, ">");
            Add(Op.NotGreaterThan, "<=", "≤", "≯");
            Add(Op.Add, "+", "＋"); // Op.Positive when Unary, Op.Concatenate in string context.
            Add(Op.Subtract, "-", "－");  // Op.Negative when Unary.
            Add(Op.Multiply, "*", "×", "✕");
            Add(Op.Divide, "/", "÷", "／");
            Add(Op.Modulo, "%");
            Add(Op.Positive, "+", "＋");
            Add(Op.Negative, "-", "－");
            Add(Op.Not, "!", "NOT");

            _symbols.AddRange(_unarySymbols.Union(_binarySymbols).Union(new[] { ".", ";", "(", ")" }));

            void Add(Op op, params string[] symbols)
            {
                var unary = op.IsUnary();
                var dictionary = GetDictionary(unary);
                foreach (var symbol in symbols)
                    dictionary.Add(symbol, op);
                (unary ? _unarySymbols : _binarySymbols).AddRange(symbols);
            }
        }

        #endregion

        #region Public Properties

        public static Op[] Keys => _operators.Keys.ToArray();
        public static OpInfo[] Values => _operators.Values.ToArray();
        public static IEnumerable<string> Symbols => _symbols;

        #endregion

        #region Public Methods

        public static bool ContainsBinarySymbol(string token) => _binarySymbols.Contains(token.ToUpperInvariant());
        public static bool ContainsSymbol(string token) => _symbols.Contains(token.ToUpperInvariant());
        public static bool ContainsUnarySymbol(string token) => _unarySymbols.Contains(token.ToUpperInvariant());

        public static bool IsBinaryOperator(this Token token) => _binarySymbols.Contains(token.Key);
        public static bool IsUnaryOperator(this Token token) => _unarySymbols.Contains(token.Key);

        #endregion

        #region Public Extension Methods

        public static Associativity GetAssociativity(this Op op)
        {
            if (op.IsUnary())
                return Associativity.None;
            if (op.IsAssignment())
                return Associativity.Right;
            switch (op)
            {
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
        public static ExpressionType ExpType(this Op op) => _operators[op].ExpressionType;
        public static string Format(this Op op) => _operators[op].Format;
        public static Rank GetRank(this Op op) => _operators[op].Rank;
        public static Image Image(this Op op) => _operators[op].Image;
        public static bool IsAssignment(this Op op) => (op & Op.Assignment) != 0;
        public static bool IsBinary(this Op op) => (op & Op.Binary) != 0;
        public static bool IsInfinitary(this Op op) => op.GetAssociativity() != 0;
        public static bool IsLogical(this Op op) => (op & Op.Logical) != 0;
        public static bool IsUnary(this Op op) => (op & Op.Unary) != 0;
        public static bool IsVisible(this Op op) => (op & Op.Visible) != 0;
        public static string Label(this Op op) => _operators[op].Label;
        public static Type OperandType(this Op op) => _operators[op].OperandType;
        public static OpInfo OpInfo(this Op op) => _operators[op];

        public static Type ResultType(this Op op) =>
            op.IsLogical() ? typeof(bool) :
            op == Op.Concatenate ? typeof(string) :
            null; // Otherwise determined by arg types at runtime.

        public static Op ToBinaryOperator(this string symbol) => ToOperator(symbol, unary: false);
        public static Op ToOperator(this string symbol, bool unary) => GetDictionary(unary)[symbol.ToUpperInvariant()];
        public static Op ToUnaryOperator(this string symbol) => ToOperator(symbol, unary: true);

        #endregion

        #region Private Fields

        private static List<string>
            _unarySymbols = new List<string>(),
            _binarySymbols = new List<string>(),
            _symbols = new List<string>();

        private static readonly Dictionary<string, Op>
            _unaryOperators = new Dictionary<string, Op>(),
            _binaryOperators = new Dictionary<string, Op>();

        private static readonly Dictionary<Op, OpInfo> _operators;

        #endregion

        #region Private Methods

        private static Dictionary<string, Op> GetDictionary(bool unary) => unary ? _unaryOperators : _binaryOperators;

        #endregion
    }
}
