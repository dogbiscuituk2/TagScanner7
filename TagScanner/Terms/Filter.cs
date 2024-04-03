namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Models;

    [Serializable]
    [XmlInclude(typeof(Cast))]
    [XmlInclude(typeof(Concatenation))]
    [XmlInclude(typeof(Conditional))]
    [XmlInclude(typeof(Conjunction))]
    [XmlInclude(typeof(Constant<bool>))]
    [XmlInclude(typeof(Constant<byte>))]
    [XmlInclude(typeof(Constant<char>))]
    [XmlInclude(typeof(Constant<DateTime>))]
    [XmlInclude(typeof(Constant<decimal>))]
    [XmlInclude(typeof(Constant<double>))]
    [XmlInclude(typeof(Constant<float>))]
    [XmlInclude(typeof(Constant<int>))]
    [XmlInclude(typeof(Constant<long>))]
    [XmlInclude(typeof(Constant<object>))]
    [XmlInclude(typeof(Constant<sbyte>))]
    [XmlInclude(typeof(Constant<short>))]
    [XmlInclude(typeof(Constant<string>))]
    [XmlInclude(typeof(Constant<TimeSpan>))]
    [XmlInclude(typeof(Constant<uint>))]
    [XmlInclude(typeof(Constant<ulong>))]
    [XmlInclude(typeof(Constant<ushort>))]
    [XmlInclude(typeof(Disjunction))]
    [XmlInclude(typeof(Difference))]
    [XmlInclude(typeof(Field))]
    [XmlInclude(typeof(Function))]
    [XmlInclude(typeof(Negation))]
    [XmlInclude(typeof(Negative))]
    [XmlInclude(typeof(Operation))]
    [XmlInclude(typeof(Parameter))]
    [XmlInclude(typeof(ParityOdd))]
    [XmlInclude(typeof(Positive))]
    [XmlInclude(typeof(Product))]
    [XmlInclude(typeof(Quotient))]
    [XmlInclude(typeof(Sum))]
    [XmlInclude(typeof(Term))]
    [XmlInclude(typeof(TermList))]
    public class Filter : IModel
    {
        public Filter() { }

        private List<Term> _terms = new List<Term>();
        public List<Term> Terms
        {
            get => _terms;
            set => _terms = value;
        }

        [NonSerialized] private bool _modified;
        [JsonIgnore, XmlIgnore] public bool Modified
        {
            get => _modified;
            set => _modified = value;
        }

        public void Clear()
        {
            Terms.Clear();
            Modified = false;
        }

        public override string ToString() => Terms.Any()
            ? Terms.Select(p => p.ToString()).Aggregate((p, q) => $"{p}{Environment.NewLine}{q}")
            : string.Empty;
    }
}
