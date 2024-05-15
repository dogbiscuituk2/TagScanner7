namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using Models;

    public class Field : Term
    {
        public Field(Tag tag) { Tag = tag; }

        public override Expression Expression => Expression.Property(Param.Expression, $"{Tag}");
        protected Variable Param => Track;
        public override Type ResultType => Tag.Type();
        public Tag Tag { get; private set; }

        public override string ToString() => Tag.DisplayName();
    }
}
