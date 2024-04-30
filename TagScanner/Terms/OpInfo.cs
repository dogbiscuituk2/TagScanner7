namespace TagScanner.Terms
{
    using System;
    using System.Drawing;
    using System.Linq.Expressions;

    public class OpInfo
    {
        public OpInfo(char label, string format, ExpressionType expressionType, Rank rank, Type paramType)
            : this(label, format, expressionType, rank, paramType, null, null) { }

        public OpInfo(char label, string format, ExpressionType expressionType, Rank rank, Type paramType, Type resultType)
            : this(label, format, expressionType, rank, paramType, resultType, null) { }

        public OpInfo(char label, string format, ExpressionType expressionType, Rank rank, Type paramType, Image image)
            : this(label, format, expressionType, rank, paramType, null, image) { }

        public OpInfo(char label, string format, ExpressionType expressionType, Rank rank, Type paramType, Type resultType, Image image)
        {
            ExpressionType = expressionType;
            Format = format;
            Image = image;
            Label = label.ToString();
            ParamType = paramType;
            Rank = rank;
            //ResultType = resultType ?? paramType;
        }

        public ExpressionType ExpressionType;
        public string Format;
        public Image Image;
        public string Label;
        public Op Op;
        public bool ParamArray;
        public Type ParamType;
        public Rank Rank;
        //public Type ResultType;
    }
}
