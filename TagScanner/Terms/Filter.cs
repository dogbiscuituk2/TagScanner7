namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable]
    public class Filter
    {
        public Filter() { }

        private List<Term> _terms = new List<Term>();

        [XmlElement(typeof(Cast))]
        [XmlElement(typeof(Concatenation))]
        [XmlElement(typeof(Conditional))]
        [XmlElement(typeof(Conjunction))]
        [XmlElement(typeof(Constant))]
        [XmlElement(typeof(Difference))]
        [XmlElement(typeof(Disjunction))]
        [XmlElement(typeof(Field))]
        [XmlElement(typeof(Function))]
        [XmlElement(typeof(Negation))]
        [XmlElement(typeof(Negative))]
        [XmlElement(typeof(Operation))]
        [XmlElement(typeof(Parameter))]
        [XmlElement(typeof(ParityOdd))]
        [XmlElement(typeof(Positive))]
        [XmlElement(typeof(Product))]
        [XmlElement(typeof(Quotient))]
        [XmlElement(typeof(Sum))]
        [XmlElement(typeof(Term))]
        [XmlElement(typeof(Umptad))]
        public List<Term> Terms
        {
            get => _terms;
            set => _terms = value;
        }
    }
}
