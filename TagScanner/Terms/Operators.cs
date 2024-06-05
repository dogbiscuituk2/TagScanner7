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
            Rank
                add = Rank.Additive,
                and = Rank.ConditionalAnd,
                ass = Rank.Assignment,
                ba = Rank.BitwiseAnd,
                bo = Rank.BitwiseOr,
                e = Rank.Equality,
                m = Rank.Multiplicative,
                or = Rank.ConditionalOr,
                r = Rank.Relational,
                sh = Rank.Shift,
                u = Rank.Unary,
                x = Rank.BitwiseXor;
            Type
                b = typeof(bool),
                d = typeof(double),
                L = typeof(long),
                o = typeof(object),
                s = typeof(string);

            _operators = new Dictionary<Op, OpInfo>();

            Add(0, 0, 0, null, "(");
            Add(Op.Assign, ExpressionType.Assign, ass, o, "←", "<-", ":=");
            Add(Op.OrAssign, ExpressionType.OrAssign, ass, o, "|=");
            Add(Op.XorAssign, ExpressionType.ExclusiveOrAssign, ass, o, "^=");
            Add(Op.AndAssign, ExpressionType.AndAssign, ass, o, "&=");
            Add(Op.LeftShiftAssign, ExpressionType.LeftShiftAssign, ass, L, "<<=");
            Add(Op.RightShiftAssign, ExpressionType.RightShiftAssign, ass, L, ">>=");
            Add(Op.AddAssign, ExpressionType.AddAssignChecked, ass, o, "+=");
            Add(Op.SubtractAssign, ExpressionType.SubtractAssignChecked, ass, o, "-=");
            Add(Op.MultiplyAssign, ExpressionType.MultiplyAssignChecked, ass, o, "*=");
            Add(Op.DivideAssign, ExpressionType.DivideAssign, ass, o, "/=");
            Add(Op.ModuloAssign, ExpressionType.ModuloAssign, ass, o, "%=");
            Add(Op.Or, ExpressionType.OrElse, or, b, "||", "OR");
            Add(Op.And, ExpressionType.AndAlso, and, b, "&&", "AND");
            Add(Op.BitwiseOr, ExpressionType.Or, bo, L, "|");
            Add(Op.Xor, ExpressionType.ExclusiveOr, x, b, "^", "XOR");
            Add(Op.BitwiseAnd, ExpressionType.And, ba, L, "&");
            Add(Op.EqualTo, ExpressionType.Equal, e, o, "=", "==");
            Add(Op.NotEqualTo, ExpressionType.NotEqual, e, o, "≠", "!=", "<>", "#");
            Add(Op.LessThan, ExpressionType.LessThan, r, d, "<");
            Add(Op.NotLessThan, ExpressionType.GreaterThanOrEqual, r, d, "≥", ">=", "≮");
            Add(Op.GreaterThan, ExpressionType.GreaterThan, r, d, ">");
            Add(Op.NotGreaterThan, ExpressionType.LessThanOrEqual, r, d, "≤", "<=", "≯");
            Add(Op.LeftShift, ExpressionType.LeftShift, sh, L, "<<");
            Add(Op.RightShift, ExpressionType.RightShift, sh, L, ">>");
            Add(Op.Concatenate, ExpressionType.Add, add, s, "+", "＋");
            Add(Op.Add, ExpressionType.AddChecked, add, d, "+", "＋");
            Add(Op.Subtract, ExpressionType.SubtractChecked, add, d, "-", "－");
            Add(Op.Multiply, ExpressionType.MultiplyChecked, m, d, "×", "*", "✕");
            Add(Op.Divide, ExpressionType.Divide, m, d, "÷", "/", "／");
            Add(Op.Modulo, ExpressionType.Modulo, m, d, "%");
            Add(Op.Positive, ExpressionType.UnaryPlus, u, d, "+", "＋");
            Add(Op.Negative, ExpressionType.NegateChecked, u, d, "-", "－");
            Add(Op.Not, ExpressionType.Not, u, b, "!", "NOT");
            Add(Op.BitwiseNot, ExpressionType.OnesComplement, u, L, "~");

            _symbols.AddRange(_unarySymbols.Union(_binarySymbols).Union(new[] { ".", ",", ";", ":", "(", ")" }));

            void Add(Op op, ExpressionType expressionType, Rank rank, Type operandType, params string[] symbols)
            {
                _operators.Add(op, new OpInfo(op, expressionType, rank, operandType, symbols[0]));
                if (op == Op.Concatenate) // Will be implemented by a function, not an operation.
                    return;
                var unary = rank == Rank.Unary;
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
        public static string GetFormat(this Op op) => _operators[op].Format;
        public static Rank GetRank(this Op op) => _operators[op].Rank;

        public static bool IsAssignment(this Op op) => (op & Op.Assignment) != 0;
        public static bool IsBinary(this Op op) => (op & Op.Binary) != 0;
        public static bool IsInfinitary(this Op op) => op.GetAssociativity() != 0;
        public static bool IsLogical(this Op op) => (op & Op.Logical) != 0;
        public static bool IsUnary(this Op op) => (op & Op.Unary) != 0;
        public static bool IsVisible(this Op op) => (op & Op.Visible) != 0;
        public static Type OperandType(this Op op) => _operators[op].OperandType;
        public static OpInfo OpInfo(this Op op) => _operators[op];
        public static string Symbol(this Op op) => _operators[op].Symbol;

        public static Type ResultType(this Op op) =>
            op.IsLogical() ? typeof(bool) :
            op == Op.Concatenate ? typeof(string) :
            null; // Otherwise determined by arg types at runtime.

        public static Rank GetRank(this Token token, bool unary) => token.ToOperator(unary).GetRank();
        public static bool IsBinaryOperator(this Token token) => _binarySymbols.Contains(token.Key);
        public static bool IsUnaryOperator(this Token token) => _unarySymbols.Contains(token.Key);

        public static Op ToBinaryOperator(this Token token) => ToOperator(token, unary: false);
        public static Op ToOperator(this string symbol, bool unary) => GetDictionary(unary)[symbol.ToUpperInvariant()];
        public static Op ToOperator(this Token token, bool unary) => token.Value.ToOperator(unary);
        public static Op ToUnaryOperator(this Token token) => ToOperator(token, unary: true);

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
