namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class OperatorInfo
    {
        public OperatorInfo(ExpressionType expType, Type resultType, string format)
        {
            Format = format;
            ExpType = expType;
            ResultType = resultType;
        }

        public ExpressionType ExpType;
        public string Format;
        public Type ResultType;
    }
}
