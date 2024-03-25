namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using Models;

    [Serializable]
    public class Field : Term
    {
        public Field(Tag tag) { Tag = tag; }

        public override Expression Expression => Expression.Property(Work, Tag.ToString());
        public override Type ResultType => Tag.Type();
        public Tag Tag { get; set; }

        public override string ToString() => Tag.DisplayName();
    }
}
