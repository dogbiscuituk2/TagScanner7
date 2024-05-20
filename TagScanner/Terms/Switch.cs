namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    public class Switch : Compound
    {
        public Switch(Term valueTerm, Term defaultTerm, IEnumerable<Case> cases) : base(valueTerm, defaultTerm)
        {
            Cases = cases.ToList();
        }

        public override Expression Expression => Expression.Switch(ValueExpression, DefaultExpression, SwitchCases);

        public override string ToString()
        {
            var result = new StringBuilder($"{Keywords.Switch} {ValueTerm} ");
            foreach (var @case in Cases)
            {
                foreach (var value in @case.Values)
                    result.Append($"{Keywords.Case} {value}: ");
                result.Append($"{@case.Body} ");
            }
            if (DefaultTerm != null)
                result.Append($"{DefaultTerm} ");
            return result.Append(Keywords.End).ToString();
        }

        private readonly List<Case> Cases;

        private Term DefaultTerm => Operands[1];
        private Term ValueTerm => Operands[0];

        private SwitchCase[] SwitchCases =>
            Cases.Select(p => Expression.SwitchCase(p.Body.Expression, p.Values.Select(q => q.Expression))).ToArray();

        private Expression DefaultExpression => DefaultTerm.Expression;
        private Expression ValueExpression => ValueTerm.Expression;
    }
}
