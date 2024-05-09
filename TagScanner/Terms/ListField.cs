namespace TagScanner.Terms
{
    using System.Linq.Expressions;
    using Models;

    public class ListField : Field
    {
        public ListField(Tag tag) : base(tag) { }

        public override string ToString() => $"${Tag.DisplayName()}";

        protected override Variable Param => List;
    }
}
