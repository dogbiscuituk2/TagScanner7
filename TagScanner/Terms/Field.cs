namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using System.Xml.Serialization;
    using Models;

    [Serializable]
    public class Field : Term
    {
        public Field() : base() { }
        public Field(Tag tag) { Tag = tag; }

        public Tag Tag { get; set; }

        // https://www.strathweb.com/2018/01/easy-way-to-create-a-c-lambda-expression-from-a-string-with-roslyn/

        [XmlIgnore]
        public override Expression Expression
        {
            get
            {
                var property = Expression.Property(Work, Tag.ToString());
                return property;
            }
        }

        [XmlIgnore]
        public override Type ResultType => Tag.Type();

        public override string ToString() => Tag.DisplayName();
    }
}
