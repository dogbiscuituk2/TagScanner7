namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class Parameter : Term
    {
        public Parameter(Type type) { _resultType = type; }

        public override Expression Expression => Expression.Default(ResultType);
        public override Precedence Precedence => Precedence.Unary;
        public override Type ResultType => _resultType;

        public override string ToString()
        {
            if (ResultType == null)
                return "(text/number)";
            switch (Type.GetTypeCode(ResultType))
            {
                /*
                case TypeCode.Boolean:
                    return "(check)";
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return "(number)";
                case TypeCode.Char:
                case TypeCode.String:
                    return "(text)";
                */
                default:
                    return $"({ResultType.Name})";
            }
        }

        private readonly Type _resultType;
    }
}
