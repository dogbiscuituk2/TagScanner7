namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class OpInfo
    {
        #region Constructor

        public OpInfo(Op op, ExpressionType expressionType, Rank rank, Associativity associativity, Type operandType, string symbol)
        {
            Associativity = associativity;
            ExpressionType = expressionType;
            Format = rank == Rank.Unary ? $"{symbol}{{0}}" : $"{{0}} {symbol} {{1}}";
            Op = op;
            OperandType = operandType;
            Rank = rank;
            Symbol = symbol;
        }

        #endregion

        #region pROPERTIES

        public Associativity Associativity { get; private set; }
        public ExpressionType ExpressionType { get; private set; }
        public string Format { get; private set; }
        public Op Op { get; private set; }
        public Type OperandType { get; private set; }
        public Rank Rank { get; private set; }
        public string Symbol { get; private set; }

        #endregion
    }
}
