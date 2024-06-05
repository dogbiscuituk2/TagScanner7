namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class OpInfo
    {
        #region Constructor

        public OpInfo(Op op, ExpressionType expressionType, Rank rank, Type operandType, string symbol)
        {
            ExpressionType = expressionType;
            Format = rank == Rank.Unary ? $"{symbol}{{0}}" : $"{{0}} {symbol} {{1}}";
            Op = op;
            OperandType = operandType;
            Rank = rank;
            Symbol = symbol;
        }

        #endregion

        #region Fields

        public ExpressionType ExpressionType;
        public string Format;
        public Op Op;
        public Type OperandType;
        public Rank Rank;
        public string Symbol;

        #endregion
    }
}
