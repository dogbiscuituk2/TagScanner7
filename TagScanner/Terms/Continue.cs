namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Continue : Label
    {
        public Continue(LabelTarget labelTarget) : base(labelTarget) { }

        public override Expression Expression => Expression.Continue(LabelTarget);
    }
}
