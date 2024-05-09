namespace TagScanner.Terms
{
    using System.Linq.Expressions;
    using Models;

    public class TrackField : Field
    {
        public TrackField(Tag tag) : base(tag) { }

        public override string ToString() => Tag.DisplayName();

        protected override Variable Param => Track;
    }
}
