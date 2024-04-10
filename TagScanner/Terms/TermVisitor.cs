namespace TagScanner.Terms
{
    using System;

    public static class TermVisitor
    {
        public static Term IgnoreCase(this Term term) => Visit(term, p =>
            p.ResultType == typeof(string)
                ? new Function(Fn.Uppercase, p)
                : p);

        public static Term Visit(Term term, Func<Term, Term> function)
        {
            return DoVisit(term);

            Term DoVisit(Term t)
            {
                if (t is TermList termList)
                {
                    var terms = termList.Operands;
                    for (var index = 0; index < terms.Count; index++)
                        terms[index] = DoVisit(terms[index]);
                }
                return function(t);
            }
        }
    }
}
