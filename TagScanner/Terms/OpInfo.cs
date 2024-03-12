namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    [Serializable]
    public class OpInfo
    {
        public OpInfo(string label, ExpressionType expType, Rank rank, Type resultType, string format, params Type[] paramTypes)
        {
            ExpType = expType;
            Format = format;
            Label = label;
            ParamTypes = paramTypes ?? new[] { resultType };
            Rank = rank;
            ResultType = resultType;
        }

        public ExpressionType ExpType;
        public string Format;
        public string Label;
        public Type[] ParamTypes;
        public Rank Rank;
        public Type ResultType;
    }
}
