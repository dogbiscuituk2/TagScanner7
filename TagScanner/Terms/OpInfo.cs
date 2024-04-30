namespace TagScanner.Terms
{
    using System;
    using System.Drawing;
    using System.Linq.Expressions;

    public class OpInfo
    {
        #region Constructor

        public OpInfo(char label, string format, ExpressionType expressionType, Rank rank, Type paramType, Image image = null)
        {
            ExpressionType = expressionType;
            Format = format;
            Image = image;
            Label = label.ToString();
            ParamType = paramType;
            Rank = rank;
        }

        #endregion

        #region Fields

        public ExpressionType ExpressionType;
        public string Format;
        public Image Image;
        public string Label;
        public Op Op;
        public bool ParamArray;
        public Type ParamType;
        public Rank Rank;

        #endregion
    }
}
