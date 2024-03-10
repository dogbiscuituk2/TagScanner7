namespace TagScanner.Terms
{
    using System;

    public class OperatorInfo
    {
        public OperatorInfo(Type resultType, string format, Precedence precedence = Precedence.Unary)
        {
            Format = format;
            Precedence = precedence;
            ResultType = resultType;
        }

        public string Format;
        public Precedence Precedence;
        public Type ResultType;
    }
}
