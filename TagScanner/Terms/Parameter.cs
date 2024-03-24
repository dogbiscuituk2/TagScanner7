namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using System.Xml.Serialization;
    using Utils;

    [Serializable]
    public class Parameter : Term
    {
        public Parameter() : base() { }
        public Parameter(Type type) { _resultType = type; }

        [XmlIgnore]
        public override Expression Expression => Expression.Default(ResultType);

        [XmlIgnore]
        public override Type ResultType => _resultType;

        public override string ToString() => ResultType.Say();

        private readonly Type _resultType;
    }
}
