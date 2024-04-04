namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Filter : IModel
    {
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
