namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class EmptyTerm : Term
    {
        public override Expression Expression => Expression.Empty();
        public override string ToString() => string.Empty;
    }
}
