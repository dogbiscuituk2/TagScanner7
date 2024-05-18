namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Break : LabelBase
    {
        public Break(LabelTarget labelTarget) : base(labelTarget) { }

        public override Expression Expression => Expression.Break(LabelTarget);

        public override string ToString() => "break";
    }
}
