namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Models;

    [Serializable]
    public class Field : Term
    {
        public Field() { }
        public Field(Tag tag) { Tag = tag; }

        public Tag Tag { get; set; }

        [JsonIgnore, XmlIgnore] public override Expression Expression => Expression.Property(Work, Tag.ToString());
        [JsonIgnore, XmlIgnore] public override Type ResultType => Tag.Type();

        public override string ToString() => Tag.DisplayName();
    }
}
