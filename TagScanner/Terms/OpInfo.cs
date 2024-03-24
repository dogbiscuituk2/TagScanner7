namespace TagScanner.Terms
{
    using System;
    using System.Drawing;
    using System.Linq.Expressions;

    public class OpInfo
    {
        public OpInfo(string label, ExpressionType expType, Rank rank, Type resultType, string format, Image image, params Type[] paramTypes)
        {
            ExpType = expType;
            Format = format;
            Image = image;
            Label = label;
            ParamTypes = paramTypes ?? new[] { resultType };
            Rank = rank;
            ResultType = resultType;
        }

        public ExpressionType ExpType;
        public string Format;
        public Image Image;
        public string Label;
        public Type[] ParamTypes;
        public Rank Rank;
        public Type ResultType;
    }
}
