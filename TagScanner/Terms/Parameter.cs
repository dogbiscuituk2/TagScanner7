namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    [Serializable]
    public class Parameter : Term
    {
        public Parameter(Type type) { _resultType = type; }

        public override Expression Expression => Expression.Default(ResultType);
        public override Type ResultType => _resultType;

        public override string ToString() => ResultType.Say();

        private readonly Type _resultType;
    }
}
