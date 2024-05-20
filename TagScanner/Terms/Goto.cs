namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Goto : LabelBase
    {
        public Goto(LabelTarget labelTarget) : base(labelTarget) { }

        public override Expression Expression => Expression.Goto(LabelTarget);

        public override string ToString() => $"{Keywords.Goto} {LabelTarget.Name}";
    }
}
