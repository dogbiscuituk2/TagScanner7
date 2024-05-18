namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Continue : LabelBase
    {
        public Continue(LabelTarget labelTarget) : base(labelTarget) { }

        public override Expression Expression => Expression.Continue(LabelTarget);

        public override string ToString() => "continue";
    }
}
