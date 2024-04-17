namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using Models;

    [Serializable]
    public class Field : Term
    {
        public Field(Tag tag) { Tag = tag; }

        public Tag Tag { get; set; }

        public override Expression Expression => Expression.Property(Track, Tag.ToString());
        public override Type ResultType => Tag.Type();

        public override string ToString() => Tag.DisplayName();
    }
}
