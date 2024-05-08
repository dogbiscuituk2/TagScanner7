namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using Models;

    public abstract class Field : Term
    {
        protected Field(Tag tag) { Tag = tag; }

        public override Expression Expression => Expression.Property(ParameterExpression, $"{Tag}");

        public override Type ResultType => Tag.Type();
        public Tag Tag { get; private set; }

        protected abstract ParameterExpression ParameterExpression { get; }
    }
}
