namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using Models;

    public abstract class Field : Term
    {
        protected Field(Tag tag) { Tag = tag; }

        public override Expression Expression => Expression.Property(Param.Expression, $"{Tag}");

        public override Type ResultType => Tag.Type();
        public Tag Tag { get; private set; }

        protected abstract Variable Param { get; }
    }
}
