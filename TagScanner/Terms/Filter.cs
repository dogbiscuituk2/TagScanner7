namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;
    using Models;

    [Serializable]
    [XmlInclude(typeof(Cast))]
    [XmlInclude(typeof(Concatenation))]
    [XmlInclude(typeof(Conditional))]
    [XmlInclude(typeof(Conjunction))]
    [XmlInclude(typeof(Constant))]
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

        private bool _modified;
        public bool Modified
        {
            get => _modified;
            set => _modified = value;
        }

        public override string ToString() => Terms.Any()
            ? Terms.Select(p => p.ToString()).Aggregate((p, q) => $"{p}{Environment.NewLine}{q}")
            : string.Empty;
    }
}
