namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class Parameter : Term
    {
        public Parameter(Type type) { _resultType = type; }

        public override Expression Expression => Expression.Default(ResultType);

        public override Type ResultType
        {
            get => _resultType;
            set => _resultType = value;
        }

        public override string ToString() => $"{{{ResultType.Say()}}}";

        private Type _resultType;
    }
}
