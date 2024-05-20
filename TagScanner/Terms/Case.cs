namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Linq;

    public class Case
    {
        public Case(Term body, IEnumerable<Term> values)
        {
            Body = body;
            Values = values.ToList();
        }

        public Term Body { get; private set; }
        public List<Term> Values { get; private set; }
    }
}
