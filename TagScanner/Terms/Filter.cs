namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
 
    [Serializable]
    public class Filter
    {
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
