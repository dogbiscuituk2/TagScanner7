namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using TagScanner.Models;

    public class Field : Term
    {
        public Field(string tagName) { TagName = tagName; }

        public string TagName { get; set; }

        // https://www.strathweb.com/2018/01/easy-way-to-create-a-c-lambda-expression-from-a-string-with-roslyn/

        public override Expression Expression
        {
            get
            {
                var property = Expression.Property(Work, TagName);
                return property;
            }
        }

        public override Type ResultType => TagName.TagType();

        public override string ToString() => TagName;
    }
}
