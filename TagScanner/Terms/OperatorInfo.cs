namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class OperatorInfo
    {
        public OperatorInfo(ExpressionType expType, Rank rank, Type resultType, string format)
        {
            ExpType = expType;
            Format = format;
            Rank = rank;
            ResultType = resultType;
        }

        public ExpressionType ExpType;
        public string Format;
        public Rank Rank;
        public Type ResultType;
    }
}
