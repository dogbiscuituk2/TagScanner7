namespace TagScanner.Terms
{
    using System;
    using System.Drawing;
    using System.Linq.Expressions;

    public class OpInfo
    {
        public OpInfo(string label, ExpressionType expressionType, Rank rank, Type resultType, string format, Image image, params Type[] paramTypes)
        {
            ExpressionType = expressionType;
            Format = format;
            Image = image;
            ImageIndex = 0;
            Label = label;
            ParamTypes = paramTypes ?? new[] { resultType };
            Rank = rank;
            ResultType = resultType;
        }

        public OpInfo(string label, ExpressionType expressionType, Rank rank, Type resultType, string format, int imageIndex, params Type[] paramTypes)
        {
            ExpressionType = expressionType;
            Format = format;
            Image = null;
            ImageIndex = imageIndex;
            Label = label;
            ParamTypes = paramTypes ?? new[] { resultType };
            Rank = rank;
            ResultType = resultType;
        }

        public ExpressionType ExpressionType;
        public string Format;
        public Image Image;
        public int ImageIndex;
        public string Label;
        public Type[] ParamTypes;
        public Rank Rank;
        public Type ResultType;
    }
}
