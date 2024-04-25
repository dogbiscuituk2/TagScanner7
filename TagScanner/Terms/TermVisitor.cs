namespace TagScanner.Terms
{
    using System;

    public static class TermVisitor
    {
        public static Term IgnoreCase(this Term term) => VisitDepthFirst(term, p => p.NeedsCaseFix() ? new Function(Fn.Uppercase, p) : p);

        public static Term VisitBreadthFirst(this Term term, Func<Term, Term> breadthFirst) => Visit(term, breadthFirst, p => p);
        public static Term VisitDepthFirst(this Term term, Func<Term, Term> depthFirst) => Visit(term, p => p, depthFirst);

        public static Term Visit(Term term, Func<Term, Term> breadthFirst, Func<Term, Term> depthFirst)
        {
            return DoVisit(term);

            Term DoVisit(Term t)
            {
                t = breadthFirst(t);
                if (t is TermList termList)
                {
                    var terms = termList.Operands;
                    for (var index = 0; index < terms.Count; index++)
                        terms[index] = DoVisit(terms[index]);
                }
                return depthFirst(t);
            }
        }

        private static bool NeedsCaseFix(this Term term)
        {
            if (term.ResultType != typeof(string))
                return false;
            if (term is Constant<string> constant)
            {
                var value = constant.Value;
                return value != value?.ToUpperInvariant();
            }
            return !(term is Function function) || function.Fn != Fn.Uppercase;
        }
    }
}
