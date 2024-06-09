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
            _operators = new Dictionary<Op, OpInfo>();

            Add(Op.Assign, ExpressionType.Assign, Rank.Assignment, Associativity.Right, typeof(object), "←", "<-", ":=");
            Add(Op.OrAssign, ExpressionType.OrAssign, Rank.Assignment, Associativity.Right, typeof(object), "|=");
            Add(Op.XorAssign, ExpressionType.ExclusiveOrAssign, Rank.Assignment, Associativity.Right, typeof(object), "^=");
            Add(Op.AndAssign, ExpressionType.AndAssign, Rank.Assignment, Associativity.Right, typeof(object), "&=");
            Add(Op.LeftShiftAssign, ExpressionType.LeftShiftAssign, Rank.Assignment, Associativity.Right, typeof(long), "<<=");
            Add(Op.RightShiftAssign, ExpressionType.RightShiftAssign, Rank.Assignment, Associativity.Right, typeof(long), ">>=");
            Add(Op.AddAssign, ExpressionType.AddAssignChecked, Rank.Assignment, Associativity.Right, typeof(object), "+=");
            Add(Op.SubtractAssign, ExpressionType.SubtractAssignChecked, Rank.Assignment, Associativity.Right, typeof(object), "-=");
            Add(Op.MultiplyAssign, ExpressionType.MultiplyAssignChecked, Rank.Assignment, Associativity.Right, typeof(object), "*=");
            Add(Op.DivideAssign, ExpressionType.DivideAssign, Rank.Assignment, Associativity.Right, typeof(object), "/=");
            Add(Op.ModuloAssign, ExpressionType.ModuloAssign, Rank.Assignment, Associativity.Right, typeof(object), "%=");
            Add(Op.Then, ExpressionType.Conditional, Rank.Conditional, Associativity.Right, typeof(object), "?");
            Add(Op.Else, ExpressionType.Conditional, Rank.Conditional, Associativity.Right, typeof(object), ":");
            Add(Op.Or, ExpressionType.OrElse, Rank.ConditionalOr, Associativity.Full, typeof(bool), "||", "OR");
            Add(Op.And, ExpressionType.AndAlso, Rank.ConditionalAnd, Associativity.Full, typeof(bool), "&&", "AND");
            Add(Op.BitwiseOr, ExpressionType.Or, Rank.BitwiseOr, Associativity.Full, typeof(long), "|");
            Add(Op.Xor, ExpressionType.ExclusiveOr, Rank.BitwiseXor, Associativity.Full, typeof(bool), "^", "XOR");
            Add(Op.BitwiseAnd, ExpressionType.And, Rank.BitwiseAnd, Associativity.Full, typeof(long), "&");
            Add(Op.EqualTo, ExpressionType.Equal, Rank.Equality, Associativity.Full, typeof(object), "=", "==");
            Add(Op.NotEqualTo, ExpressionType.NotEqual, Rank.Equality, Associativity.Full, typeof(object), "≠", "!=", "<>", "#");
            Add(Op.LessThan, ExpressionType.LessThan, Rank.Relational, Associativity.Full, typeof(double), "<");
            Add(Op.NotLessThan, ExpressionType.GreaterThanOrEqual, Rank.Relational, Associativity.Full, typeof(double), "≥", ">=", "≮");
            Add(Op.GreaterThan, ExpressionType.GreaterThan, Rank.Relational, Associativity.Full, typeof(double), ">");
            Add(Op.NotGreaterThan, ExpressionType.LessThanOrEqual, Rank.Relational, Associativity.Full, typeof(double), "≤", "<=", "≯");
            Add(Op.LeftShift, ExpressionType.LeftShift, Rank.Shift, Associativity.Full, typeof(long), "<<");
            Add(Op.RightShift, ExpressionType.RightShift, Rank.Shift, Associativity.Full, typeof(long), ">>");
            Add(Op.Concatenate, ExpressionType.Add, Rank.Additive, Associativity.Full, typeof(string), "+", "＋");
            Add(Op.Add, ExpressionType.AddChecked, Rank.Additive, Associativity.Full, typeof(double), "+", "＋");
            Add(Op.Subtract, ExpressionType.SubtractChecked, Rank.Additive, Associativity.Left, typeof(double), "-", "－");
            Add(Op.Multiply, ExpressionType.MultiplyChecked, Rank.Multiplicative, Associativity.Full, typeof(double), "×", "*", "✕");
            Add(Op.Divide, ExpressionType.Divide, Rank.Multiplicative, Associativity.Left, typeof(double), "÷", "/", "／");
            Add(Op.Modulo, ExpressionType.Modulo, Rank.Multiplicative, Associativity.Left, typeof(double), "%");
            Add(Op.Positive, ExpressionType.UnaryPlus, Rank.Unary, Associativity.None, typeof(double), "+", "＋");
            Add(Op.Negative, ExpressionType.NegateChecked, Rank.Unary, Associativity.None, typeof(double), "-", "－");
            Add(Op.Not, ExpressionType.Not, Rank.Unary, Associativity.None, typeof(bool), "!", "NOT");
            Add(Op.BitwiseNot, ExpressionType.OnesComplement, Rank.Unary, Associativity.None, typeof(long), "~");

            _symbols.AddRange(_unarySymbols.Union(_binarySymbols).Union(new[] { ".", ",", ";", ":", "(", ")" }));

            void Add(Op op, ExpressionType expressionType, Rank rank, Associativity associativity, Type operandType, params string[] symbols)
            {
                _operators.Add(op, new OpInfo(op, expressionType, rank, associativity, operandType, symbols[0]));
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

        public static bool CanChain(this Op op) => (op & Op.Chains) != 0;
        public static ExpressionType ExpType(this Op op) => _operators[op].ExpressionType;
        public static Associativity GetAssociativity(this Op op) => _operators[op].Associativity;
        public static string GetFormat(this Op op) => _operators[op].Format;
        public static Rank GetRank(this Op op) => _operators[op].Rank;

        public static bool IsAssignment(this Op op) => (op & Op.Assignment) != 0;
        public static bool IsBinary(this Op op) => (op & Op.Binary) != 0;
        public static bool IsConditional(this Op op) => (op & Op.Conditional) != 0;
        public static bool IsInfinitary(this Op op) => op.GetAssociativity() != 0;
        public static bool IsLogical(this Op op) => (op & Op.Logical) != 0;
        public static bool IsUnary(this Op op) => (op & Op.Unary) != 0;
        public static Type OperandType(this Op op) => _operators[op].OperandType;
        public static OpInfo OpInfo(this Op op) => _operators[op];
        public static string Symbol(this Op op) => op == Op.End ? "(" : _operators[op].Symbol;

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
