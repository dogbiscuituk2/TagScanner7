namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Break : Label
    {
        public Break(LabelTarget labelTarget) : base(labelTarget) { }

        public override Expression Expression => Expression.Break(LabelTarget);
    }
}
