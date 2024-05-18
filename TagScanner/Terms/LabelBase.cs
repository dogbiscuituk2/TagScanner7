namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public abstract class LabelBase : Term
    {
        protected LabelBase(LabelTarget labelTarget) { LabelTarget = labelTarget; }

        public LabelTarget LabelTarget { get; set; }
    }
}
