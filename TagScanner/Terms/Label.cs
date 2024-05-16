namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Label : Term
    {
        public Label(LabelTarget labelTarget) { LabelTarget = labelTarget; }

        public override Expression Expression => Expression.Label(LabelTarget);
        public LabelTarget LabelTarget { get; set; }

        public override string ToString() => $"#{LabelTarget.Name}:";
    }
}
