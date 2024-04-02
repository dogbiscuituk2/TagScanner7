namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;

    [Serializable]
    [XmlInclude(typeof(Cast))]
    [XmlInclude(typeof(Constant))]
    [XmlInclude(typeof(Field))]
    [XmlInclude(typeof(Function))]
    [XmlInclude(typeof(Operation))]
    [XmlInclude(typeof(Parameter))]
    [XmlInclude(typeof(Term))]
    [XmlInclude(typeof(TermList))]
    public class Filter
    {
        public Filter() { }

        private List<Term> _terms = new List<Term>();
        public List<Term> Terms
        {
            get => _terms;
            set => _terms = value;
        }

        public override string ToString() => Terms.Any()
            ? Terms.Select(p => p.ToString()).Aggregate((p, q) => $"{p}{Environment.NewLine}{q}")
            : string.Empty;
    }
}
