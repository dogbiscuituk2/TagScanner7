namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Goto : Label
    {
        public Goto(LabelTarget labelTarget) : base(labelTarget) { }

        public override Expression Expression => Expression.Goto(LabelTarget);

        public override string ToString() => $"Goto #{LabelTarget.Name}";
    }
}
