namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Label : LabelBase
    {
        public Label(LabelTarget labelTarget) : base(labelTarget) { }

        public override Expression Expression => Expression.Label(LabelTarget);

        public override string ToString() => $"{LabelTarget.Name}:";
    }
}
